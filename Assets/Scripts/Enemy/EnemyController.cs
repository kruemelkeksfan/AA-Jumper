using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject EnemyCanvas;
    [SerializeField] Image HealthBar;
    [SerializeField] bool dropWreck;
    [SerializeField] float movementSpeed;
    [SerializeField] float despawnPoint = -5.0f;
    [SerializeField] float enemyHealth;
    [SerializeField] float enemyHealthMultiplyer;
    [SerializeField] int enemyScoreCount;
    [Tooltip("in sec")] [SerializeField] int restartTime;
    [SerializeField] GameObject Wreck;
    [SerializeField] bool destroyOnMapEnd = false;
    [SerializeField] bool dropWreckOnDestroy = false;

    bool displayed = false;
    bool destroyed = false;
    bool gapClear = true;
    bool restarting = false;
    float spawnPoint = EnemySpawner.spawnXPosition + 5;


    int enemyMultipliedHealth;
    float onePercentHealth;

    Rigidbody rigidBody;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
       enemyMultipliedHealth = Mathf.RoundToInt(EnemySpawner.gameLevel * enemyHealthMultiplyer);
        if (enemyMultipliedHealth > enemyHealth)
        {
            enemyHealth = enemyMultipliedHealth;
        }
        onePercentHealth = enemyHealth / 100;
    }
    void Update()
    {
        if (displayed)
        {
            HealthBar.fillAmount = (enemyHealth / onePercentHealth) / 100;
        }
        if (gameObject.transform.position.x <= despawnPoint && !restarting)
        {
            restarting = true;
            Invoke("Restart", restartTime);
        }
        if (gapClear)
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (destroyOnMapEnd && transform.position.x < 5)
        {
            Object.Destroy(gameObject);
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
            float sDamage = float.Parse(other.name);
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
    private void OnMouseEnter()
    {
        EnemyCanvas.SetActive(true);
        displayed = true;
    }

    private void OnMouseExit()
    {
        EnemyCanvas.SetActive(false);
        displayed = false;
    }

    private void Destroy()
    {
        Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
        if (dropWreckOnDestroy)
        {
            Vector3 wreckp = new Vector3(transform.position.x, transform.position.y, 1);
            Instantiate(Wreck, wreckp, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
