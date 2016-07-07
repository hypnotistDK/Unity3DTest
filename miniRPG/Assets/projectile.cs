using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //Destroy(gameObject, 0.2f);

        //Debugger for raycast
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 0.1f;
        //Debug.DrawRay(transform.position, forward, Color.green, 100f);

        //Raycast if hit then destour bullet
        RaycastHit hit;
        if(Physics.Raycast(transform.position,(forward), out hit, 1f))
        {
           //Debug.Log(hit.collider.tag);
           Destroy(gameObject);
        }else
        {
            Destroy(gameObject, 1.5f);
        }

    }
}
