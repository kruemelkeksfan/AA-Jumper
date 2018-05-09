using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float turnSpeed = 2f;
    [SerializeField] float jumpPower = 100.0f;
    [SerializeField] int wreckValue = 10;
    [SerializeField] int respawnTime = 10;
    [SerializeField] Transform respawnPoint;

    float horizontalThrow;
    bool movementEnabled, verticalThrow, collectable;
    bool pause = false;
    bool controllsEnabled = true;
    public static bool buildingButtons = false;
    Rigidbody rigidBody;

    List<Collider> hittingWreck = new List<Collider>();

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("p"))
        {
            if (!pause)
            {
                pause = true;
                controllsEnabled = false;
                Time.timeScale = 0;
            }
            else if (pause)
            {
                pause = false;
                controllsEnabled = true;
                Time.timeScale = 1;
            }
        }
        if (controllsEnabled)
        {

            if (Input.GetKeyDown("b"))
            {
                buildingButtons = !buildingButtons;
            }
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
                    Destroy(hittingWreck[I].gameObject);
                    hittingWreck.Remove(hittingWreck[I]);
                }
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
        if (other.tag == "Ground")
        {
            Invoke("Respawn", respawnTime);
        }
        if (other.tag == "Factory")
        {
            transform.position = new Vector3(2.2f, transform.position.y, transform.position.z);
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

    void Respawn()
    {
        gameObject.transform.position = respawnPoint.position;
        rigidBody.velocity = new Vector3(0, 0, 0);
    }
    void HorizontalMovement()
    {
        float xOffset = horizontalThrow * speed * Time.deltaTime;
        float newXPos = transform.position.x + xOffset;
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
        if (xOffset < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * turnSpeed);
        }
        else if (xOffset > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnSpeed);
        }
    }
}
