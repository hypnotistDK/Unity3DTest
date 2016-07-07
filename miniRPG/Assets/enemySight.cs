using UnityEngine;
using System.Collections;

public class enemySight : MonoBehaviour
{

    private SphereCollider col;
    private GameObject[] players;
    private NavMeshAgent agent;
    private bool stopped;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            //Debug.Log("Hit this one: " + other.gameObject.transform.position);
            agent.SetDestination(other.gameObject.transform.position);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            //Debug.Log("please stop: ");
            agent.SetDestination(other.gameObject.transform.position);
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
