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
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 20f;
        //Debug.DrawRay(transform.position, forward, Color.green, 100f);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if(hit.collider.tag == "Ground")
                {
                    GetComponent<shoot>().SetShooting(false);
                }
                if (hit.collider.tag == "Ground" && GetComponent<shoot>().GetShooting() == false)
                {
                    agent.Resume();
                    agent.SetDestination(hit.point);
                    //Set stopping distance back to normal
                    GetComponent<NavMeshAgent>().stoppingDistance = 1f;
                }

                //GetComponent<shoot>().SetShooting(false);
            }
        }
    }
}