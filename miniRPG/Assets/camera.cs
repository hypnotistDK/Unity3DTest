using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }
}
