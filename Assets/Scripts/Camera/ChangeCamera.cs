using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Button changeCamButton;
    [SerializeField] private Vector3 camOnBoardLocation;
    [SerializeField] private Vector3 camOnTableLocation;
    [SerializeField] private Vector3 camOnBoardRotation;
    [SerializeField] private Vector3 camOnTableRotation;

    public static bool CanMoveCamera {  get; private set; }

    private bool isCamOnBoard = true;

    private void Awake()
    {
        changeCamButton.onClick.RemoveAllListeners();
        SetCamButton(true);
    }

    private void OnEnable()
    {
        Actions.OnBuildingSelected += ChangeToTableView;
        Actions.OnUnitsDeployed += ChangeToTableView;
    }

    private void OnDisable()
    {
        Actions.OnBuildingSelected -= ChangeToTableView;
        Actions.OnUnitsDeployed -= ChangeToTableView;
    }

    private async void LerpCamera(Vector3 location, Vector3 rotation, bool isCamOnBoard)
    {
        Quaternion finalRotation = Quaternion.Euler(rotation);
        Vector3 startPos = cam.transform.position;
        Quaternion startRot = cam.transform.localRotation;

        this.isCamOnBoard = isCamOnBoard;
        SetCamButton(this.isCamOnBoard);

        float factor = 0;
        while (factor < 1f)
        {
            cam.transform.position = Vector3.Lerp(startPos, location, factor);
            cam.transform.localRotation = Quaternion.Lerp(startRot, finalRotation, factor);
            factor += Time.deltaTime * 2;
            await Task.Yield();
        }

        cam.transform.position = location;
        cam.transform.localRotation = finalRotation;
    }

    private void ChangeToTableView()
    {
        LerpCamera(camOnTableLocation, camOnTableRotation, false);
        changeCamButton.GetComponentInChildren<TMP_Text>().text = "View Board";
        CanMoveCamera = true;
    }

    private void ChangeToBoardView()
    {
        LerpCamera(camOnBoardLocation, camOnBoardRotation, true); 
        changeCamButton.GetComponentInChildren<TMP_Text>().text = "View Table";
        CanMoveCamera = false;
    }

    private void SetCamButton(bool isCamOnBoard)
    {
        if (isCamOnBoard)
        {
            changeCamButton.onClick.RemoveAllListeners();
            changeCamButton.onClick.AddListener(() => ChangeToTableView());
        } else
        {
            changeCamButton.onClick.RemoveAllListeners();
            changeCamButton.onClick.AddListener(() => ChangeToBoardView());
        }
    }
}
