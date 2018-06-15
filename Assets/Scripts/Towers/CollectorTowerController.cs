using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorTowerController : MonoBehaviour
{
    [SerializeField] float collectingIntervall;
    [SerializeField] int generatedScrapAmmount;

    int scrapCollected;
    bool nothingCollected;

    List<Collider> wrecksInRange = new List<Collider>();

    public void SetTowerActiv()
    {
        InvokeRepeating("CollectWrecks", collectingIntervall, collectingIntervall);
    }
    public string SetTowerInfo()
    {
        return ("collects every " + collectingIntervall + " Sec all Wrecks in range or after 2 times without Wrecks in Range " + generatedScrapAmmount + " Scrap" + "                         " +
                "Scrap Collected: " + scrapCollected);
    }
    void CollectWrecks()
    {
        if (wrecksInRange.Count > 0) //collects all wrecks
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount + (DifficultyData.wreckValue * wrecksInRange.Count);
            scrapCollected = DifficultyData.wreckValue * wrecksInRange.Count;
            for (int I = wrecksInRange.Count - 1; I > -1; --I)
            {
                Destroy(wrecksInRange[I].gameObject);
                wrecksInRange.Remove(wrecksInRange[I]);
            }
            Debug.Log("Wrecks collected");
        }
        else if (nothingCollected) // generates scrap every second time no wrecks were in Range
        {
            nothingCollected = false;
            ScrapManager.scrapCount = ScrapManager.scrapCount + generatedScrapAmmount;
            scrapCollected += generatedScrapAmmount;
            Debug.Log("Scrap collected");
        }
        else // preperation so that the next fail will generate Scrap
        {
            nothingCollected = true;
            Debug.Log("nothing collected");
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
