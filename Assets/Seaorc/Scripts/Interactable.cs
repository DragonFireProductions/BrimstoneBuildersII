using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Tag;
    public bool DefaultAction;
    public float InteractionRange;
    public Transform InteractionPoint;
    public Character Unit;
    public bool Interacted;
    

    // Use this for initialization
    void Start()
    {
        if (InteractionPoint == null)
            InteractionPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Unit != null && !Interacted)
        {
            if(Vector3.Distance(transform.position,Unit.transform.position) <= InteractionRange)
            {
                Interact();
                Interacted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Performing Interaction: " + Tag);
    }

    public void SetInteraction(Character _Character)
    {
        Unit = _Character;
        Interacted = false;
    }

    public void StopInteraction()
    {
        Unit = null;
        Interacted = false;
    }
}