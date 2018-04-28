using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header ("Unity Setup")]
    [SerializeField] float yLeadDivisor;
    [SerializeField] float zLeadDivisor;
    [SerializeField] string enemyTag = "Enemy";

    [SerializeField] Transform Guns;
    [SerializeField] Transform Base;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Shell;

    [Header ("Atributes")]
    [SerializeField] int range;
    [SerializeField] float fireRate;
    [SerializeField] float turnSpeed = 1f;

    float targetingLead = 0.5f;
    float fireCountdown = 0f;

    Vector3 targetingRotation;
    Quaternion qRotation;
    GameObject[] enemies;
    Transform Target;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z));
            if (distanceToEnemy < shortestDistance && transform.position.y <= enemy.transform.position.y)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }

    }

    void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (Target != null)
        {
            targetingLead = (Target.position.z / zLeadDivisor) + ((Target.position.y - transform.position.y) / yLeadDivisor);
            Vector3 dir = new Vector3(Target.position.x - targetingLead, Target.position.y, Target.position.z) - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            qRotation = Quaternion.Lerp(qRotation, lookRotation, Time.deltaTime * turnSpeed);
            Vector3 realRotation = qRotation.eulerAngles;
            Base.rotation = Quaternion.Euler(0f, realRotation.y - 90, 0f);
            Guns.localRotation = Quaternion.Euler(0f, 0f, -realRotation.x);

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
    }
    void Shoot()
    {
        if (Shell.name == "Rocket")
        {
            GameObject RocketGo = (GameObject)Instantiate(Shell, FirePoint.position, FirePoint.rotation);
            RocketController Rocket = RocketGo.GetComponent<RocketController>();

            if (Rocket != null)
            {
                Rocket.Seek(Target);
            }
        }
        else
        {
            Instantiate(Shell, FirePoint.position, FirePoint.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
