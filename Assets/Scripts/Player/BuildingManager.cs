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
	void Update ()
    {
		
	}
    void OnGUI()
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 20 * i, 170, 30), Towers[i].name))
            {
                towerPlacement.SetItem(Towers[i]);
            }
        }
    }
}
