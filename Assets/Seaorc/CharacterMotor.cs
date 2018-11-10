using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMotor : MonoBehaviour
{
    NavMeshAgent Agent;
    Transform Target;

    void Start()
    {
        if(GetComponent<NavMeshAgent>())
        {
            Agent = GetComponent<NavMeshAgent>();
        }
        else
        {
            gameObject.AddComponent<NavMeshAgent>();
            Agent = GetComponent<NavMeshAgent>();
        }
    }


    void Update()
    {
        if (Target != null)
        {
            Agent.destination = Target.position;
            TurnToTarget();
        }
    }

    void TurnToTarget()
    {
        if(Target != null)
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5);
        }
    }

    public void SetDestination(Vector3 _Destination)
    {
        DropTarget();
        Agent.SetDestination(_Destination);
    }

    public void SetTarget(Interactable _interactable)
    {
        Agent.stoppingDistance = _interactable.InteractionRange * .8f;
        Agent.updateRotation = false;
        Target = _interactable.InteractionPoint;
    }

    public void DropTarget()
    {
        Agent.stoppingDistance = 0;
        Agent.updateRotation = true;
        Target = null;
    }
}