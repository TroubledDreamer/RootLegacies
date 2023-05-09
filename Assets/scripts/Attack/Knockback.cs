using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rd3d;

    [SerializeField]
    public float knockbackForce = 16, knockbackDuration = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public GameObject targetObject;

    private Rigidbody targetRigidbody;


    public void PlayerFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector3 direction = (transform.position - sender.transform.position).normalized;
        rd3d.AddForce(direction[0] * knockbackForce, direction[1] * knockbackForce, direction[2] * knockbackForce, ForceMode.Impulse);
        rd3d.useGravity = true;
        StartCoroutine(Reset());
        print((direction[0] * knockbackForce, direction[1] * knockbackForce, direction[2] * knockbackForce) + "1");
        print(direction);





    }


    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rd3d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

    /*

    void Start()
    {
        targetRigidbody = targetObject.GetComponent<Rigidbody>();
    }

    public void ApplyKnockback()
    {
        Vector3 knockbackDirection = -transform.forward;
        targetRigidbody.AddForce(knockbackDirection * knockbackForce);

        StartCoroutine(KnockbackDuration());
    }

    IEnumerator KnockbackDuration()
    {
        yield return new WaitForSeconds(knockbackDuration);
        targetRigidbody.velocity = Vector3.zero;
    }
    */
}