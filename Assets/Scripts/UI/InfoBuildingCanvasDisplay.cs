using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoBuildingCanvasDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] string info;
    [SerializeField] string noAmmoInfo;

    Text infoText;

    void Start()
    {
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (DifficultyData.ammunitionActiv)
        {
            infoText.text = info;
        }
        else
        {
            infoText.text = noAmmoInfo;
        }
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
