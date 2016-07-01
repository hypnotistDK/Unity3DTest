using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public LayerMask mask;
    public bool shooting;

    // Use this for initialization
    void Start () {
        shooting = false;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask.value))
            {
                
                //Debug.Log("test" + hit.collider.tag);
                if (Physics.Raycast(transform.position, hit.point - transform.position, out hit, 100)) {
                    Debug.DrawRay(transform.position, hit.point - transform.position, Color.green, 100f);
                    Debug.Log("HIT");
                    Debug.Log(hit.collider.tag);
                    if(hit.collider.tag == "Enemy") { 
                        SetShooting(true);
                    }
                }
                //IF i click on enemy i want player to stop running and shoot at it
            }
        }
    }

    public void SetShooting(bool value)
    {
        shooting = value;
    }

    public bool GetShooting()
    {
        return shooting;
    }
}
