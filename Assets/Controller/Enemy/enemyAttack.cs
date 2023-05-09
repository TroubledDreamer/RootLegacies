using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttack : MonoBehaviour
{
    public float lookRadius = 10f;
    public int hitCounter = 0;
    public float distance;
    public int health;
    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(WaitBeforeShow());

    }


    // Update is called once per frame
    void Update()

    {


    }
    

    IEnumerator WaitBeforeShow()
    {

        while (true)
        {
            yield return null;
            distance = Vector3.Distance(target.position, transform.position);
            //healthBar.Instance.SetMaxHealth(100);

            if (distance <= lookRadius)
            {
                yield return new WaitForSeconds(3);
                healthBar.Instance.health -= 10;

                //healthBar.Instance.SetMaxHealth(100);


                if (healthBar.Instance.health <= 0)
                {
                    PlayerManager.Instance.KillPlayer();
                }
                //SetMaxHealth(health);


            }   
            yield return new WaitForSeconds(3);

        }
    }


    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}