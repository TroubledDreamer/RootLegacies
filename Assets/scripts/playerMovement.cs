using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float runSpeed;
    private float moveSpeeds;

    CharacterController ch;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

     
     

        if (Input.GetKeyDown(KeyCode.Z))
        {
            moveSpeeds = runSpeed;
     
        }
        else
        {
            moveSpeeds = moveSpeed;

        }

        float x = Input.GetAxis("Horizontal") * moveSpeeds * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeeds * Time.deltaTime;
        ch.Move(new Vector3(x, 0, z));



    }
}