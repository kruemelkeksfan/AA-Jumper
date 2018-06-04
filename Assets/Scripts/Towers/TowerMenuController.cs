using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuController : MonoBehaviour
{
    public int towerCost;

    [SerializeField] GameObject Tower;

	public void SellTower ()
    {
        ScrapManager.scrapCount = ScrapManager.scrapCount + (towerCost / 2);
        Object.Destroy(Tower);
	}
}
