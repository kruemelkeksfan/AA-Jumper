using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuController : MonoBehaviour
{
    [SerializeField] GameObject Tower;
    [SerializeField] int towerCost;

	public void SellTower ()
    {
        ScrapManager.scrapCount = ScrapManager.scrapCount + (towerCost / 2);
        Object.Destroy(Tower);
	}
}
