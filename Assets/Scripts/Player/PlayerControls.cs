using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpPower = 100.0f;
    [SerializeField] int wreckValue = 10;

    float horizontalThrow;
    bool movementEnabled, verticalThrow, collectable;
    Rigidbody rigidBody;

    [SerializeField]List<Collider> hittingWreck = new List<Collider>();

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
        if (hittingWreck.Count > 0 && Input.GetKeyDown("e"))
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount + wreckValue * hittingWreck.Count;
            for (int I = hittingWreck.Count - 1; I > -1; --I)
            {
                Debug.Log("for");
                Destroy(hittingWreck[I].gameObject);
                hittingWreck.Remove(hittingWreck[I]);
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
        if (other.tag == "Scrap")
        {
            hittingWreck.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Environment")
        {
            movementEnabled = false;
        }
        if (other.tag == "Scrap")
        {
            hittingWreck.Remove(other);
        }
    }

    void HorizontalMovement()
    {
        float xOffset = horizontalThrow * speed * Time.deltaTime;
        float NewXPos = transform.localPosition.x + xOffset;
        transform.localPosition = new Vector3(NewXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
