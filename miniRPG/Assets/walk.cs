using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask mask;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask.value))
            {
                Debug.Log(GetComponent<shoot>().GetShooting());

                if(GetComponent<shoot>().GetShooting() == false)
                { 
                    agent.SetDestination(hit.point);
                }
                else
                {
                    //GetComponent<shoot>().SetShooting(false);
                }
                GetComponent<shoot>().SetShooting(false);
            }
        }
    }
}