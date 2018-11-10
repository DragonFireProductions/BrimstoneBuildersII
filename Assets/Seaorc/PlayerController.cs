using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    CharacterMotor agent;
    public LayerMask MovementMask;
    Interactable Focus;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<CharacterMotor>())
        {
            agent = GetComponent<CharacterMotor>();
        }
        else
        {
            gameObject.AddComponent<CharacterMotor>();
            agent = GetComponent<CharacterMotor>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
            {
                agent.SetDestination(hit.point);
                DropFocus();
            }
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.GetComponent<Interactable>())
                {
                    SetFocus(hit.collider.GetComponent<Interactable>());
                }
            }

        }
    }

    void SetFocus (Interactable _Focus)
    {
        if (Focus != _Focus)
        {
            if (Focus != null)
                _Focus.StopInteraction();
            Focus = _Focus;
            agent.SetTarget(_Focus);
        }

        _Focus.SetInteraction(transform);
    }

    void DropFocus ()
    {
        if (Focus != null)
        {
            Focus.StopInteraction();
            agent.DropTarget();
        }
    }
}