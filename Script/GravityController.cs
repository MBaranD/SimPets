using System;
using System.IO;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public GameObject objectToMove;
    public Camera arCamera;
    public float distanceFromCamera = 1.0f;

    public void MoveObjectToFront()
    {
        if (objectToMove != null)
        {
            objectToMove.transform.position = arCamera.transform.position + arCamera.transform.forward * distanceFromCamera;
            objectToMove.transform.rotation = Quaternion.LookRotation(arCamera.transform.forward);
        }
    }
}