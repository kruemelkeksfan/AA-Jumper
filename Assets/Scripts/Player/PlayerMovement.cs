using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpPower = 100.0f;

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
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    HorizontalMovement();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            movementEnabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Environment")
        {
            movementEnabled = false;
        }
    }

    void HorizontalMovement()
    {
        float xOffset = horizontalThrow * speed * Time.deltaTime;
        float NewXPos = transform.localPosition.x + xOffset;
        transform.localPosition = new Vector3(NewXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
