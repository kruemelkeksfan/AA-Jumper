using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuController : MonoBehaviour
{
    public int towerCost;

    [SerializeField] GameObject Tower;
    [SerializeField] float deconstructionTime = 1;

    bool activated;
    Dissolve dissolve;

    private void Start()
    {
        dissolve = Tower.GetComponent<Dissolve>();
    }
    public void SellTower ()
    {
        if (!activated)
        {
            activated = true;
            Invoke("Destroy", deconstructionTime);
            dissolve.SetDissolveOut(deconstructionTime);
        }
    }
    private void Destroy()
    {
        ScrapManager.scrapCount = ScrapManager.scrapCount + (towerCost / 2);
        Object.Destroy(Tower);
    }
}
