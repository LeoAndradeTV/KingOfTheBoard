using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckBuildArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Actions.OnPlacementStatusChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Actions.OnPlacementStatusChanged?.Invoke(false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("BuiltObject"))
        {
            Actions.OnPlacementStatusChanged?.Invoke(false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BuiltObject"))
        {
            Actions.OnPlacementStatusChanged?.Invoke(true);
        }
    }
}
