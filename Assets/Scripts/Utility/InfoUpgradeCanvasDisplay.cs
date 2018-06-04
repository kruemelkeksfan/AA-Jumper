using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoUpgradeCanvasDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    string towerStatGain;
    string upgradeCost;
    Text infoText;

    public void SetUpgradeInfo(string towerStatGainRef, string upgradeCostRef)
    {
        towerStatGain = towerStatGainRef;
        upgradeCost = upgradeCostRef;
    }
    void Start()
    {
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        infoText.text = "Tower gets " + towerStatGain + " for " + upgradeCost;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        infoText.text = "";
    }
    private void OnDestroy()
    {
        infoText.text = "";
    }
    private void OnDisable()
    {
        infoText.text = "";
    }
}
