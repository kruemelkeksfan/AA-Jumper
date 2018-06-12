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
    [SerializeField] GameObject autoRefillDisplay;
    [SerializeField] Image ammunitionDisplay;
    [SerializeField] Toggle targetFocusBig;
    [SerializeField] Toggle targetFocusSmall;

    [Header ("Atributes")]
    [SerializeField] int baseRange;
    [SerializeField] float baseMaxAmmunition;
    [SerializeField] float baseFireRate;
    [SerializeField] float baseDamage;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float ammunitionPrice;
    [Header("UpgradeingStats")]
    [SerializeField] int upgradeRange;
    [SerializeField] float upgradeFirerate;
    [SerializeField] float upgradeDamage;
    [SerializeField] float upgradeMaxAmmunition;

    float ammunition;
    float targetingLead = 0.5f;
    float fireCountdown = 0f;

    int range;
    float fireRate;
    float damage;
    float maxAmmunition;

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
    public string SetTowerInfo()
    {
        if (DifficultyData.ammunitionActiv)
        {
            if (autoRefillActive)
            {
                return ("Range: " + range + "                                        " +
                        "Fire Rate: " + fireRate + "                                 " +
                        "Damage: " + damage + "                                      " +
                        "max Ammunition: " + maxAmmunition + "                       " +
                        "auto refill enabled");
            }
            else
            {
                return ("Range: " + range + "                                        " +
                        "Fire Rate: " + fireRate + "                                 " +
                        "Damage: " + damage + "                                      " +
                        "max Ammunition: " + maxAmmunition + "                       " +
                        "auto refill disabled");
            }
        }
        else
        {
            if (autoRefillActive)
            {
                return ("Range: " + range + "                                        " +
                        "Fire Rate: " + fireRate + "                                 " +
                        "Damage: " + damage);
            }
            else
            {
                return ("Range: " + range + "                                        " +
                        "Fire Rate: " + fireRate + "                                 " +
                        "Damage: " + damage);
            }
        }
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
    public void SetUpgradeState(UpgradeDisplayHandler upgradeDisplayHandler, TowerMenuController towerMenuController)
    {
        upgradeDisplayHandler.UpdateUpgradeStatus(towerController, towerMenuController, upgradeRange, upgradeFirerate, upgradeDamage, upgradeMaxAmmunition);
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
        ammunition = baseMaxAmmunition;
        towerController = gameObject.GetComponent<TowerController>();
        GameObject towerErrorTextGameObject = GameObject.FindGameObjectWithTag("TowerErrorText");
        towerErrorMassageHandler = towerErrorTextGameObject.GetComponent<TowerErrorMassageHandler>();
        InvokeRepeating("UpdateStats", 1, 1);
    }
    void Update()
    {
        if (PlayerControls.ammunitionDisplayed && DifficultyData.ammunitionActiv)
        {
            ammunitionDisplayer.SetActive(true);
            ammunitionDisplay.fillAmount = ammunition / maxAmmunition;
            if (autoRefillActive)
            {
                autoRefillDisplay.SetActive(true);
            }
            else autoRefillDisplay.SetActive(false);
        }
        if (!PlayerControls.ammunitionDisplayed && DifficultyData.ammunitionActiv)
        {
            ammunitionDisplayer.SetActive(false);
        }
        if (ammunition < 1)
        {
            if (autoRefillActive)
            {
                if (ScrapManager.scrapCount >= AmmunitonRefillCost())
                {
                    ScrapManager.scrapCount = ScrapManager.scrapCount - AmmunitonRefillCost();
                    ammunition = maxAmmunition;
                }
                else
                {
                    ammunitionEmptyDisplayer.SetActive(true);
                    return;
                }
            }
            else
            {
                ammunitionEmptyDisplayer.SetActive(true);
                return;
            }
        }
        if (DifficultyData.ammunitionActiv)
        {
            ammunitionEmptyDisplayer.SetActive(false);
        }
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
                if (DifficultyData.ammunitionActiv)
                {
                    ammunition = ammunition - 1;
                }
                fireCountdown = 1f / fireRate;
            }
        }
    }
    void UpdateStats()
    {
        range = baseRange + (upgradeRange * rangeUpgradeCount);
        fireRate = baseFireRate + (upgradeFirerate * firerateUpgradeCount);
        damage = baseDamage + (upgradeDamage * damageUpgradeCount);
        maxAmmunition = baseMaxAmmunition + (upgradeMaxAmmunition * maxAmmunitionUpgradeCount);
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
            RocketGo.name = damage.ToString();
            RocketController Rocket = RocketGo.GetComponent<RocketController>();

            if (Rocket != null)
            {
                Rocket.Seek(Target);
            }
        }
        else
        {
            GameObject currentShell = Instantiate(Shell, FirePoint.position, FirePoint.rotation);
            currentShell.name = damage.ToString();
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
