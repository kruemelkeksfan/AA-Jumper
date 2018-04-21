using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float xRange = 7.4f;

    float horizontalThrow;
    bool movementEnabled;


    void Update ()
    {
    if (movementEnabled == true)
        {
            horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");

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
