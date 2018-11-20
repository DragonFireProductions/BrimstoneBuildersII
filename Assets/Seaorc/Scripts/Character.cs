using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    CharacterMotor agent;
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

        PlayerController.Units.Add(this);
    }

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    void SetFocus(Interactable _Focus)
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

    void DropFocus()
    {
        if (Focus != null)
        {
            Focus.StopInteraction();
            agent.DropTarget();
        }
    }
}
