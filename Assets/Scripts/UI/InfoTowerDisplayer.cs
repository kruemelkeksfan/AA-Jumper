using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTowerDisplayer : MonoBehaviour
{

    [SerializeField] string towerType;

    TowerController towerController;
    Text infoText;

	void Start ()
    {
        towerController = gameObject.GetComponent<TowerController>();
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
	}
	
	void OnMouseOver ()
    {
        string towerInfo = towerController.SetTowerInfo();
        infoText.text = (towerType + "              " + towerInfo);
	}

    void OnMouseExit()
    {
        infoText.text = "";
    }
}
