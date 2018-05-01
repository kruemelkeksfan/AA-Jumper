using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float spawnPoint = 65.0f;
    [SerializeField] float despawnPoint = -5.0f;
    [SerializeField] int enemyHealth;
    [SerializeField] int enemyScoreCount;
    [Tooltip("in sec")] [SerializeField] int restartTime;
    [SerializeField] GameObject Wreck;

    bool destroyed = false;
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

    void OnTriggerEnter(Collider other) // damage from ammunition Name
    {
        if (other.tag == "Shell")
        {
            Destroy(other.gameObject);
            int sDamage = int.Parse(other.name);
            enemyHealth -= sDamage;
        }
        if (enemyHealth <= 0 && !destroyed)
        {
            Displayer.score = Displayer.score + enemyScoreCount;
            destroyed = true; 
            Vector3 wreckp = new Vector3(transform.position.x, transform.position.y, 1);
            Instantiate(Wreck, wreckp, Quaternion.identity);
            rigidBody.useGravity = true;
            gameObject.tag = "Untagged";
            Invoke("Destroy", 3);
        }


    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
