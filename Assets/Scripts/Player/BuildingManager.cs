using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] GameObject[] Towers;

    TowerPlacement towerPlacement;

	void Start ()
    {
        towerPlacement = GetComponent<TowerPlacement>();
	}
    public void SelectTower(int i)
    {
        if (TowerPlacement.hasPlaced == true)
        {
            towerPlacement.SetItem(Towers[i]);
        }
    }
}
