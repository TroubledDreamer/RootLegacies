using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public float maxHealth = 100;
    public float regenRate = 10f;

    private float currentHealth;

    void Start()
    {
        maxHealth = healthBar.Instance.health;
    }

    void Update()
    {
        if (healthBar.Instance.health < maxHealth)
        {

            healthBar.Instance.health += regenRate * Time.deltaTime;
        }
    }
}




