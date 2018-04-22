using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float spawnPoint = 65.0f;
    [SerializeField] float despawnPoint = -5.0f;
    [Tooltip ("in sec")][SerializeField] int restartTime;

    private Rigidbody rigidBody;
   
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = -transform.right * movementSpeed;
    }

    void Update()
    {
        if (gameObject.transform.position.x <= despawnPoint)
        {
            Invoke("Restart", restartTime);
        }
    }

    void Restart()
    {
        gameObject.transform.position = new Vector3 (spawnPoint, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
