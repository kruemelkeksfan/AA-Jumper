using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [Tooltip ("in sec")][SerializeField] int restartTime;

    private Rigidbody rigidBody;
   
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = -transform.right * movementSpeed;
    }

    void Update()
    {
        if (gameObject.transform.position.x <= -5)
        {
            Invoke("Restart", restartTime);
        }
    }

    void Restart()
    {
        gameObject.transform.position = new Vector3 (65, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
