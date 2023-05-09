using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kbacktester : MonoBehaviour
{

    [SerializeField]
    public GameObject hitBy;

    public float lookRadius = 15f;
    public int hitCounter = 0;
    public float distance;
    public int hp = 120;


    public Knockback kback;
    Transform target;
    NavMeshAgent agent;





    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(WaitBeforeShow());

        //kback = hitBy.GetComponents<Knockback>().PlayerFeedback(hitBy);


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
            hp -= 10;
            print("aattakkinngKnoeck");
            kback.PlayerFeedback(hitBy);

            if (hp <= 0)
            {
                Destroy(gameObject);
            }




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
