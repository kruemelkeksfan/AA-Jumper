using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float jumpPower = 100f;

    float horizontalThrow;
    bool movementEnabled, verticalThrow;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    void Update ()
    {
    if (movementEnabled == true)
        {
            horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            if (CrossPlatformInputManager.GetButtonDown("Jump") == true)
            {
                print("ja");
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
                

        }

    HorizontalMovement();
            

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            movementEnabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            movementEnabled = false;
        }
    }


    void HorizontalMovement()
    {
        
        float xOffset = horizontalThrow * Speed * Time.deltaTime;
        float NewXPos = transform.localPosition.x + xOffset;
        transform.localPosition = new Vector3(NewXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
