using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorTowerController : MonoBehaviour
{
    public List<Collider> wrecksInRange = new List<Collider>();

    [SerializeField] float collectingIntervall;
    [SerializeField] int generatedScrapAmmount;
    [SerializeField] float baseTurnSpeed;
    [SerializeField] float armTurnSpeed;
    [Header("Tower Parts")]
    [SerializeField] Transform towerBase;
    [SerializeField] Transform baseArm;
    [SerializeField] Transform midArm;
    [SerializeField] Transform topArm;
    [SerializeField] Transform claw;
    [SerializeField] Vector3 baseArmGrab;
    [SerializeField] Vector3 baseArmPull;
    [SerializeField] Vector3 midArmGrab;
    [SerializeField] Vector3 midArmPull;
    [SerializeField] Vector3 topArmGrab;
    [SerializeField] Vector3 topArmPull;
    [SerializeField] Vector3 clawGrab;
    [SerializeField] Vector3 clawPull;

    int scrapCollected;
    float animationDoneTolerance = 0.5f;
    bool nothingCollected;
    bool animationDone = true;

    Quaternion qBaseRotation;
    Vector3 realBaseArmRotation;
    Vector3 realMidArmRotation;
    Vector3 realTopArmRotation;
    Vector3 realClawRotation;
    Transform nearestWreck;

    public void SetTowerActiv()
    {
        InvokeRepeating("Collect", collectingIntervall, collectingIntervall);
    }
    public string SetTowerInfo()
    {
        return ("collects every " + collectingIntervall + " Sec all Wrecks in range or after 2 times without Wrecks in Range " + generatedScrapAmmount + " Scrap" + "                         " +
                "Scrap Collected: " + scrapCollected);
    }
    private void Update()
    {
        if (nearestWreck != null)
        {
            Vector3 dir = nearestWreck.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            qBaseRotation = Quaternion.Lerp(qBaseRotation, lookRotation, Time.deltaTime * baseTurnSpeed);
            Vector3 realBaseRotation = qBaseRotation.eulerAngles;
            towerBase.rotation = Quaternion.Euler(0f, realBaseRotation.y + 90, 0f);

            realBaseArmRotation = Vector3.Lerp(realBaseArmRotation, baseArmGrab, Time.deltaTime * armTurnSpeed);
            baseArm.localRotation = Quaternion.Euler(0f, 0f, realBaseArmRotation.z);
            realMidArmRotation = Vector3.Lerp(realMidArmRotation, midArmGrab, Time.deltaTime * armTurnSpeed);
            midArm.localRotation = Quaternion.Euler(0f, 0f, realMidArmRotation.z);
            realTopArmRotation = Vector3.Lerp(realTopArmRotation, topArmGrab, Time.deltaTime * armTurnSpeed);
            topArm.localRotation = Quaternion.Euler(0f, 0f, realTopArmRotation.z);
            realClawRotation = Vector3.Lerp(realClawRotation, clawGrab, Time.deltaTime * armTurnSpeed);
            claw.localRotation = Quaternion.Euler(0f, 0f, realClawRotation.z);
            
            if (qBaseRotation.y < (lookRotation.y + animationDoneTolerance) && qBaseRotation.y > (lookRotation.y - animationDoneTolerance) && realBaseArmRotation.z > (baseArmGrab.z - animationDoneTolerance))
            {
                CollectWrecks();
                nearestWreck = null;
                animationDone = false;
            }
        }
        if (!animationDone)
        {
            realBaseArmRotation = Vector3.Lerp(realBaseArmRotation, baseArmPull, Time.deltaTime * armTurnSpeed);
            baseArm.localRotation = Quaternion.Euler(0f, 0f, realBaseArmRotation.z);
            realMidArmRotation = Vector3.Lerp(realMidArmRotation, midArmPull, Time.deltaTime * armTurnSpeed);
            midArm.localRotation = Quaternion.Euler(0f, 0f, realMidArmRotation.z);
            realTopArmRotation = Vector3.Lerp(realTopArmRotation, topArmPull, Time.deltaTime * armTurnSpeed);
            topArm.localRotation = Quaternion.Euler(0f, 0f, realTopArmRotation.z);
            realClawRotation = Vector3.Lerp(realClawRotation, clawPull, Time.deltaTime * armTurnSpeed);
            claw.localRotation = Quaternion.Euler(0f, 0f, realClawRotation.z);
            if (realBaseArmRotation.z < (baseArmPull.z + animationDoneTolerance))
            {
                animationDone = true;
            }
        }
    }
    void Collect()
    {
        if (wrecksInRange.Count > 0) //collects all wrecks
        {
            float shortestDistance = Mathf.Infinity;
            nearestWreck = null;
            foreach (Collider wreck in wrecksInRange)
            {
                if (wreck != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, new Vector3(wreck.transform.position.x, transform.position.y, wreck.transform.position.z));
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestWreck = wreck.transform;
                    }
                }
            }
        }
        else if (nothingCollected) // generates scrap every second time no wrecks were in Range
        {
            nothingCollected = false;
            ScrapManager.scrapCount = ScrapManager.scrapCount + generatedScrapAmmount;
            scrapCollected += generatedScrapAmmount;
        }
        else // preperation so that the next fail will generate Scrap
        {
            nothingCollected = true;
            Debug.Log("nothing collected");
        }
    }

    private void CollectWrecks()
    {
        ScrapManager.scrapCount = ScrapManager.scrapCount + (DifficultyData.wreckValue * wrecksInRange.Count);
        scrapCollected = DifficultyData.wreckValue * wrecksInRange.Count;
        for (int I = wrecksInRange.Count - 1; I > -1; --I)
        {
            if (wrecksInRange[I] == null)
            {
                wrecksInRange.Remove(wrecksInRange[I]);
            }
            else
            {
                Destroy(wrecksInRange[I].gameObject);
                wrecksInRange.Remove(wrecksInRange[I]);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scrap")
        {
            wrecksInRange.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scrap")
        {
            wrecksInRange.Remove(other);
        }
    }
}
