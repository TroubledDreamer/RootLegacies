using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class tree1 : MonoBehaviour
{
    public int resourceHealth = 50;
    public int wood = 5;
    private int tester = 0;
    // Start is called before the first frame update
 
    public float lookRadius = 15f;
    public int hitCounter = 0;
    public float distance;
    public int hp = 120;
    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "oceTree";

        target = PlayerManager.Instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(WaitBeforeShow());

    }

    float timer;
    // Update is called once per frame
    void Update()

    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (Input.GetKeyDown("space"))
            {
                timer = 0;
                attack();
            }
        }

    }


    IEnumerator WaitBeforeShow()
    {

        while (true)
        {
            yield return null;
            distance = Vector3.Distance(target.position, transform.position);
            //healthBar.Instance.SetMaxHealth(100);


            yield return new WaitForSeconds(3);

        }
    }
    void attack()
    {
        print("aattakkinng");
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            resourceHealth -= 5;

            if (resourceHealth <= 0)
            {
                Destroy(gameObject);
                resourceList.wood += 5;
                tester = resourceList.wood;
                Debug.Log(tester);
            }

        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
