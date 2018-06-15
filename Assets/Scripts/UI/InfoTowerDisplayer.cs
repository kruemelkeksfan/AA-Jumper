using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTowerDisplayer : MonoBehaviour
{
    [SerializeField] string towerType;

    TowerController towerController;
    CollectorTowerController collectorTowerController;
    Text infoText;

	void Start ()
    {
        if (towerType == "Collector Tower")
        {
            collectorTowerController = gameObject.GetComponent<CollectorTowerController>();
        }
        else
        {
            towerController = gameObject.GetComponent<TowerController>();
        }
        
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
	}
	
	void OnMouseOver ()
    {
        string towerInfo = "";
        if (towerType == "Collector Tower")
        {
            towerInfo = collectorTowerController.SetTowerInfo();
        }
        else
        {
            towerInfo = towerController.SetTowerInfo();
        }
        infoText.text = (towerType + "              " + towerInfo);
	}

    void OnMouseExit()
    {
        infoText.text = "";
    }
}
