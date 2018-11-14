using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Tag;
    public bool DefaultAction;
    public float InteractionRange;
    public Transform InteractionPoint;
    public PlayerController Character;
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
        if (Character != null && !Interacted)
        {
            if(Vector3.Distance(transform.position,Character.transform.position) <= InteractionRange)
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

    public void SetInteraction(PlayerController _Character)
    {
        Character = _Character;
        Interacted = false;
    }

    public void StopInteraction()
    {
        Character = null;
        Interacted = false;
    }
}