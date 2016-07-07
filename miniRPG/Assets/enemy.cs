using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    private float health; 

	// Use this for initialization
	void Start () {
        health = 100f;	
	}
	
	// Update is called once per frame
	void Update () {

        if (health == 0)
        {
            Destroy(gameObject);
        }
	}

    public float GetHealth()
    {
        return health;
    }

    public float Damage(float dmg)
    {
        health -= dmg;
        return GetHealth();
    }
}
