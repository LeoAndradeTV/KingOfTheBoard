using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float moveSpeed = 20f;
    private float zoomSpeed = 1000f;

    private float maxX = 5;
    private float maxZ = 10;
    private float minX = -5;
    private float minZ = -10;
    private float minZoom = 15;
    private float maxZoom = 20;

    private float xPosition;
    private float zPosition;
    private float zoom;

    private void Start()
    {
        xPosition = transform.position.x;
        zPosition = transform.position.z;
        zoom = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ChangeCamera.CanMoveCamera)
        {
            return;
        }

        HandleCameraPosition();
    }

    private void HandleCameraPosition()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        xPosition += horizontalInput * moveSpeed * Time.deltaTime;
        xPosition = Mathf.Clamp(xPosition, minX, maxX);

        zPosition += verticalInput * moveSpeed * Time.deltaTime;
        zPosition = Mathf.Clamp(zPosition, minZ, maxZ);

        zoom -= zoomInput * zoomSpeed * Time.deltaTime;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        transform.position = new Vector3(xPosition, zoom, zPosition);
    }
}
