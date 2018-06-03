using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RefillInfoCanvasDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] string info = "Refill ammunition, scrap cost: ";
    [SerializeField] GameObject tower;

    TowerController towerController;
    Text infoText;

    void Start()
    {
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
        towerController = tower.GetComponent<TowerController>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        infoText.text = info + towerController.AmmunitonRefillCost();
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
