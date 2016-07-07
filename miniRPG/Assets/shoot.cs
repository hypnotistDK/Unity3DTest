using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class shoot : MonoBehaviour {

    public LayerMask mask;
    public Rigidbody projectilePrefab;
    public Transform barrelEnd;
    public bool shooting;

    private float rotateSpeed;
    private GameObject enemy; //enemey object
    private float timestamp = 0f; //var to make some time bestween shots
    private float shootDelay = 0.5f; //delays first shot after moving
    private float moving; //check if we are moving or stading still
    private float facingEnemy; //do we face the enemy?
    private List<GameObject> targets = new List<GameObject>(); //list all gameobject in the player sphere

    // Use this for initialization
    void Start () {
        shooting = false;
        rotateSpeed = 1000f;
	}

    // Update is called once per frame
    void Update()
    {
        //if shoot state is true and timestamp is reached then call shoot
        if (GetShooting() == true && Time.time >= timestamp)
        {
            Shoot();
            timestamp = Time.time + 1.0f;
        }
        
        //if no enemy is selected and we have some targets in range calculate the closest and set that as the enemy
        if(enemy == null && targets.Any()) { 
            float count = 15f;
            for (int i = 0; i < targets.Count; i++) // Loop with for.
            {
                float dist = Vector3.Distance(targets[i].transform.position, transform.position);
                if (dist < count)
                {
                    enemy = targets[i];
                    count = dist;
                }
            }
        }

        moving = GetComponent<NavMeshAgent>().velocity.magnitude;

        if (enemy != null && Time.time >= shootDelay && moving < 0.1f)
        {

            facingEnemy = Vector3.Dot(transform.forward, (enemy.transform.position - transform.position).normalized);
            if (facingEnemy < 0.7f)
            {
                //Facing the enemy
                Vector3 newDir = enemy.transform.position - transform.position;
                transform.LookAt(enemy.transform);
            }
            else
            {
                //Set state shooting
                SetShooting(true);
                //Shoot();
            }

            shootDelay = Time.time + 0.5f;
        }



        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, mask.value))
            {
                GetComponent<NavMeshAgent>().Stop();

                //Is the enemy in range (20)
                if (Physics.Raycast(transform.position, hit.transform.position - transform.position, out hit, 50)) {

                    if (hit.collider.tag == "Enemy") {
                        enemy = hit.collider.gameObject; //save enemy in var

                        //Facing the enemy
                        Vector3 newDir = hit.transform.position - transform.position;
                        //transform.rotation = Quaternion.LookRotation(newDir);
                        transform.LookAt(hit.transform);

                        //Debug.Log(hit.distance);
                        if (hit.distance > 10f)
                        {
                            GetComponent<NavMeshAgent>().Resume();
                            GetComponent<NavMeshAgent>().SetDestination(hit.transform.position);
                            GetComponent<NavMeshAgent>().stoppingDistance = 10f;
                        }
                    }
                }    
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        moving = GetComponent<NavMeshAgent>().velocity.magnitude;

        if (other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider) && !targets.Contains(other.gameObject))
        {
            targets.Add(other.gameObject);

        }
    }

 

    void OnTriggerExit(Collider other)
    {
        SetShooting(false);
        enemy = null;
        targets.Clear();
    }


    //THis method will stop shoot and set shoot state to false if the enemy is dead
    //it will instantiate projectile and sent it flying, and it will sent dmg to the enemy
    private void Shoot()
    {
        if (GetShooting() == true && enemy != null) {
            if (enemy.GetComponent<enemy>().GetHealth() <= 0)
            {
                //CancelInvoke("ShootWait"); //delete
                SetShooting(false);
                enemy = null;
                targets.Clear();
            }

            if (facingEnemy > 0.7f)
            {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                projectileInstance.AddForce(transform.forward * 3000);

                //apply damage
                enemy.GetComponent<enemy>().Damage(10f);

                Debug.Log(enemy.GetComponent<enemy>().GetHealth());
            }
        }
    }

    void Damage()
    {
        enemy.GetComponent<enemy>().Damage(10f);
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
