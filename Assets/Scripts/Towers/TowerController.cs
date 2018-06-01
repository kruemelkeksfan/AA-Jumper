using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [Header("Canvas Objects")]
    [SerializeField] GameObject amunitionEmptyDisplayer;
    [SerializeField] GameObject amunitionDisplayer;
    [SerializeField] Image amunitionDisplay;
    [SerializeField] Toggle targetFocusBig;
    [SerializeField] Toggle targetFocusSmall;

    [Header ("Atributes")]
    [SerializeField] int range;
    [SerializeField] float maxAmunition;
    [SerializeField] float fireRate;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float amunitionPrice;

    [SerializeField] float amunition;
    float targetingLead = 0.5f;
    float fireCountdown = 0f;
    
    Vector3 targetingRotation;
    Quaternion qRotation;
    GameObject[] enemies;
    Transform Target;

    void Start()
    {
        amunition = maxAmunition;
    }
    public void SetTowerActiv()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void RefillAmunition()
    {
        if (ScrapManager.scrapCount >= Mathf.RoundToInt((maxAmunition - amunition) * amunitionPrice))
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount - Mathf.RoundToInt((maxAmunition - amunition) * amunitionPrice);
            amunition = maxAmunition;
        }
    }
    void UpdateTarget()
    {
        if (amunition < 1)
        {
            return;
        }
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        if (TargetFocus())
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name == FocusNameOne() || enemy.name == FocusNameTwo())
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z));
                    if (distanceToEnemy < shortestDistance && transform.position.y <= enemy.transform.position.y)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
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
            if (Target == null)
            {
                SearchNearestTarget(ref shortestDistance, ref nearestEnemy);
            }
        }
        else
        {
            SearchNearestTarget(ref shortestDistance, ref nearestEnemy);
        }
    }
    void Update()
    {
        if (PlayerControls.amunitionDisplayed)
        {
            amunitionDisplayer.SetActive(true);
            amunitionDisplay.fillAmount = amunition / maxAmunition;
        }
        if (!PlayerControls.amunitionDisplayed)
        {
            amunitionDisplayer.SetActive(false);
        }
        if (amunition < 1)
        {
            amunitionEmptyDisplayer.SetActive(true);
            return;
        }
        amunitionEmptyDisplayer.SetActive(false);
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
                amunition = amunition - 1;
                fireCountdown = 1f / fireRate;
            }
        }
    }
    private void SearchNearestTarget(ref float shortestDistance, ref GameObject nearestEnemy)
    {
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    bool TargetFocus()
    {
        if (targetFocusBig.isOn)
        {
            return true;
        }
        if (targetFocusSmall.isOn)
        {
            return true;
        }
        else return false;
    }
    string FocusNameOne()
    {
        if (targetFocusBig.isOn)
        {
            return "Bomber(Clone)";
        }
        if (targetFocusSmall.isOn)
        {
            return "SmallShip(Clone)";
        }
        else return "";
    }
    string FocusNameTwo()
    {
        if (targetFocusBig.isOn)
        {
            return "Dreadnought(Clone)";
        }
        if (targetFocusSmall.isOn)
        {
            return "Biplane(Clone)";
        }
        else return "";
    }
}
