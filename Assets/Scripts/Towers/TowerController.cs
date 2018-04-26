using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header ("Unity Setup")]
    [SerializeField] Transform Guns;
    [SerializeField] Transform Base;
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] GameObject Shell;
    [SerializeField] Transform FirePoint;
    [SerializeField] float zLeadDivisor;
    [SerializeField] float yLeadDivisor;

    [Header ("Atributes")]
    public int range;
    public float fireRate;

    float targetingLead = 0.5f;
    float fireCountdown = 0f;
    public GameObject[] enemies;
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
            if (distanceToEnemy < shortestDistance)
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
        if (Target == null)
        {
            return;
        }
        targetingLead = (Target.position.z / zLeadDivisor) + ((Target.position.y - transform.position.y) / yLeadDivisor);
        Vector3 dir = new Vector3(Target.position.x - targetingLead, Target.position.y, Target.position.z) - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        Base.rotation = Quaternion.Euler(0f, rotation.y - 90, 0f);
        Guns.rotation = Quaternion.Euler(0f, rotation.y - 90, -rotation.x);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }
    void Shoot()
    {
        Instantiate(Shell, FirePoint.position, FirePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
