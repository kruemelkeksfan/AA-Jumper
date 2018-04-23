using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] Towers;

    TowerPlacement towerPlacement;

	void Start ()
    {
        towerPlacement = GetComponent<TowerPlacement>();
	}
    void OnGUI()
    {
        if (TowerPlacement.hasPlaced == true && PlayerControls.buildingButtons == true)
        {
            for (int i = 0; i < Towers.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 1.3f, Screen.height / 18 + Screen.height / 20 * i, 200, 30), Towers[i].name) && TowerPlacement.hasPlaced == true)
                {
                    towerPlacement.SetItem(Towers[i]);
                }
            }
        }
    }
}
