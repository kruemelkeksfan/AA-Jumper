using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoUpgradeCanvasDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text infoText;

    string info;

    public void SetUpgradeInfo(string infoRef)
    {
        info = infoRef;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        infoText.text = info;
    }

    public void OnClick()
    {
        infoText.text = info;
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
