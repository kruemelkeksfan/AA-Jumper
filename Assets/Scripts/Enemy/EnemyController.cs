﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] bool dropWreck;
    [SerializeField] float movementSpeed;
    [SerializeField] float despawnPoint = -5.0f;
    [SerializeField] int enemyHealth;
    [SerializeField] int enemyScoreCount;
    [Tooltip("in sec")] [SerializeField] int restartTime;
    [SerializeField] GameObject Wreck;
   

    bool destroyed = false;
    bool gapClear = true;
    bool restarting = false;
    private Rigidbody rigidBody;
    float spawnPoint = EnemySpawner.spawnXPosition + 5;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (gameObject.transform.position.x <= despawnPoint && !restarting)
        {
            restarting = true;
            Invoke("Restart", restartTime);
        }
        if (gapClear)
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    void Restart()
    {
        transform.position = new Vector3 (spawnPoint, transform.position.y, transform.position.z);
        restarting = false;
    }

    void OnTriggerEnter(Collider other) // damage from ammunition Name
    {
        if (other.tag == "Shell")
        {
            Destroy(other.gameObject);
            int sDamage = int.Parse(other.name);
            enemyHealth -= sDamage;
        }
        if (other.tag == "Enemy" && transform.position.x > other.transform.position.x)
        {
            gapClear = false;
        }
        if (enemyHealth <= 0 && !destroyed)
        {
            Displayer.score = Displayer.score + enemyScoreCount;
            destroyed = true; 
            if (dropWreck)
            {
                Vector3 wreckp = new Vector3(transform.position.x, transform.position.y, 1);
                Instantiate(Wreck, wreckp, Quaternion.identity);
            }
            rigidBody.useGravity = true;
            gameObject.tag = "Untagged";
            Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
            Invoke("Destroy", 2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gapClear = true;
        }
    }

    private void Destroy()
    {
        Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
