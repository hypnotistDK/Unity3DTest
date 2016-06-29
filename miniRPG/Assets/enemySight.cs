using UnityEngine;
using System.Collections;

public class enemySight : MonoBehaviour {

    private SphereCollider col;
    private GameObject[] players;

    void Awake ()
    {

        col = GetComponent<SphereCollider>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hit this one: " + other.gameObject.name);
        }
    }
}
