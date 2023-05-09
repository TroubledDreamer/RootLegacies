using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITImer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text countText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Count: " + countText.ToString();
    }
}
