using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject cameraFocus;

    [Header("Constraints")] 
    [SerializeField] private bool xAxisLock = false;
    [SerializeField] private bool yAxisLock = false;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = GetXAxis();
        newPosition.y = GetYAxis();
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    float GetXAxis()
    {
        if (xAxisLock)
            return transform.position.x;
        return cameraFocus.transform.position.x;
    }

    float GetYAxis()
    {
        if (yAxisLock)
            return transform.position.y;
        return cameraFocus.transform.position.y;
    }
    
}
