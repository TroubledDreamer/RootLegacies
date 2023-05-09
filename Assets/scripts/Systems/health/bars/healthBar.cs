using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public static healthBar Instance; 
    // Start is called before the first frame update
    public Slider slider;
    public float health;

    void Awake()
    {
        Instance = this;
        healthBar.Instance.SetMaxHealth(100);
    }


 
    
    public void SetMaxHealth(int health)
    {
        this.health = health;
        slider.maxValue = health;
        slider.value = health;
    }


    void Update ()
    {
        if (slider != null)
        {
            slider.value = health;
        }
    }
}
