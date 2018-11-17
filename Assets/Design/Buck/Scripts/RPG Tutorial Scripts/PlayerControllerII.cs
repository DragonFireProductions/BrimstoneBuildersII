using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotorII))]
public class PlayerControllerII : MonoBehaviour
{
    //The layer that the player can move on
    public LayerMask movementMask;

    Camera cam;

    PlayerMotorII motor;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotorII>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if right mouse button is pushed
        if (Input.GetMouseButtonDown(1)) //Come back and swap out for input instead of mousebutton
        {
            //Draws a ray from the camera to where the mouse is
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }

        //if left mouse button is pushed
        if (Input.GetMouseButtonDown(0)) //Come back and swap out for input instead of mousebutton
        {
            //Draws a ray from the camera to where the mouse is
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //check for interactable
            }
        }
    }
}
