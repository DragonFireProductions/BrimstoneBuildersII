using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    float ZOffset;
    float Angle;
    [Header("Debug Information (Dont Leave Public)")]
    public bool Targeting;
    public Transform Target;
    Transform FocusPoint;

    [Header("Speed/Sensitivity")]
    public float PanSpeed;
    public float MouseSensitivity;
    [Header("Constraints")]
    public float YOffset;
    public float MinOffset;
    public float MaxOffset;
    public float MinAngle;
    public float MaxAngle;

    void Start()
    {
        if (FocusPoint == null)
        {
            FocusPoint = new GameObject().transform;
        }
    }

    
    void Update()
    {
        // Camera Zoom
        ZOffset += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * MouseSensitivity;
        ZOffset = Mathf.Clamp(ZOffset, MinOffset, MaxOffset);

        // Orbital Camera
        if(Input.GetKey(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;

            Angle += Input.GetAxis("Mouse Y");

            float YRotation = -Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;

            FocusPoint.Rotate(0, YRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

            Angle += Input.GetAxis("RotateX") * Time.deltaTime * MouseSensitivity;

            float YRotation = Input.GetAxis("RotateY") * Time.deltaTime * MouseSensitivity;

            FocusPoint.Rotate(0, YRotation, 0);
        }

        Angle = Mathf.Clamp(Angle, MinAngle, MaxAngle);

        // Check for fallow target
        if (Targeting)
        {
            if (Target == null)
                Targeting = false;
            else
                FocusPoint.position = Target.position;
        }

        // Paning Controll
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Targeting = false;

            float XMovement = Input.GetAxis("Horizontal") * Time.deltaTime * PanSpeed;
            float YMovement = Input.GetAxis("Vertical") * Time.deltaTime * PanSpeed;

            FocusPoint.Translate(XMovement, 0, YMovement);
        }

        // Put Camera in correct spot
        transform.position = FocusPoint.position;
        transform.rotation = FocusPoint.rotation;

        transform.Rotate(Angle, 0, 0);
        transform.Translate(0, YOffset, -ZOffset);
    }

    public void SetTarget(Transform NewTarget)
    {
        Target = NewTarget;
        Targeting = true;
    }
}