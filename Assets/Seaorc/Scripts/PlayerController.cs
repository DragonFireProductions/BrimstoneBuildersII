using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static List<Character> Units;
    List<Character> SelectedUnits;


    public LayerMask MovementMask;

    // Use this for initialization
    void Start()
    {

        if (Units == null)
            Units = new List<Character>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Fire2"))
        {
            if (SelectedUnits != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, MovementMask))
                {
                    foreach (Character Unit in SelectedUnits)
                    {
                        Unit.SetDestination(hit.point);
                    }
                }

            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                    SelectedUnits = new List<Character>();

                foreach (Character Unit in Units)
                {
                    if (hit.collider.gameObject == Unit.gameObject)
                    {
                        SelectedUnits.Add(Unit);
                        break;
                    }
                }
            }
        }

    }
}