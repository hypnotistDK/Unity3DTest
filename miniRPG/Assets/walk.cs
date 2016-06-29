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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask.value))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}