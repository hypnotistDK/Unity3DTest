using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log("test" + hit.collider.tag);

                //IF i click on enemy i want player to stop running and shoot at it
            }
        }
    }
}
