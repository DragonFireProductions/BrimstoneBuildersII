using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    static List<PlayerController> SelectedUnits;

    CharacterMotor agent;
    public LayerMask MovementMask;
    Interactable Focus;
    public bool Selected;

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

        if (SelectedUnits == null)
            SelectedUnits = new List<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   

        if (Selected)
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
                if (SelectedUnits[0] == this)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.GetComponent<Interactable>())
                        {
                            SetFocus(hit.collider.GetComponent<Interactable>());
                        }
                    }
                }
            }
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Input.GetKey(KeyCode.LeftShift) && Selected)
            {
                Selected = false;
                SelectedUnits.Remove(this);
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    Selected = true;
                    SelectedUnits.Add(this);
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

        _Focus.SetInteraction(this);
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