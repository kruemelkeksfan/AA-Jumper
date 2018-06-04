using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    
    [HideInInspector] public int rangeUpgradeCount = 0;
    [HideInInspector] public int firerateUpgradeCount = 0;
    [HideInInspector] public int damageUpgradeCount = 0;
    [HideInInspector] public int maxAmmunitionUpgradeCount = 0;
    [HideInInspector] public bool autoRefillActive = false;

    [Header ("Unity Setup")]
    [SerializeField] float yLeadDivisor;
    [SerializeField] float zLeadDivisor;
    [SerializeField] string enemyTag = "Enemy";

    [SerializeField] Transform Guns;
    [SerializeField] Transform Base;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Shell;
    [Header("Canvas Objects")]
    [SerializeField] GameObject ammunitionEmptyDisplayer;
    [SerializeField] GameObject ammunitionDisplayer;
    [SerializeField] Image ammunitionDisplay;
    [SerializeField] Toggle targetFocusBig;
    [SerializeField] Toggle targetFocusSmall;

    [Header ("Atributes")]
    [SerializeField] int range;
    [SerializeField] float maxAmmunition;
    [SerializeField] float fireRate;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float ammunitionPrice;

    float ammunition;
    float targetingLead = 0.5f;
    float fireCountdown = 0f;

    TowerErrorMassageHandler towerErrorMassageHandler;
    TowerController towerController;
    Vector3 targetingRotation;
    Quaternion qRotation;
    GameObject[] enemies;
    Transform Target;
   
    public void SetTowerActiv()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void RefillAmunition()
    {
        if (ScrapManager.scrapCount >= AmmunitonRefillCost())
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount - AmmunitonRefillCost();
            ammunition = maxAmmunition;
        }
        else
        {
            towerErrorMassageHandler.SetTowerError("not enough scrap");
        }
    }
    public void SetUpgradeState(UpgradeHandler upgradeHandler, TowerMenuController towerMenuController)
    {
        upgradeHandler.UpdateUpgradeStatus(towerController,towerMenuController, gameObject.name);
    }
    public int AmmunitonRefillCost()
    {
        int refillCost = Mathf.RoundToInt((maxAmmunition - ammunition) * ammunitionPrice);
        if (refillCost < 1)
        {
            return 1;
        }
        else
        {
            return refillCost;
        }
    }
    void Start()
    {
        ammunition = maxAmmunition;
        towerController = gameObject.GetComponent<TowerController>();
        GameObject towerErrorTextGameObject = GameObject.FindGameObjectWithTag("TowerErrorText");
        towerErrorMassageHandler = towerErrorTextGameObject.GetComponent<TowerErrorMassageHandler>();
    }
    void Update()
    {
        if (PlayerControls.ammunitionDisplayed)
        {
            ammunitionDisplayer.SetActive(true);
            ammunitionDisplay.fillAmount = ammunition / maxAmmunition;
        }
        if (!PlayerControls.ammunitionDisplayed)
        {
            ammunitionDisplayer.SetActive(false);
        }
        if (ammunition < 1)
        {
            ammunitionEmptyDisplayer.SetActive(true);
            return;
        }
        ammunitionEmptyDisplayer.SetActive(false);
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
                ammunition = ammunition - 1;
                fireCountdown = 1f / fireRate;
            }
        }
    }
    void UpdateTarget()
    {
        if (ammunition < 1)
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
    void SearchNearestTarget(ref float shortestDistance, ref GameObject nearestEnemy)
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
