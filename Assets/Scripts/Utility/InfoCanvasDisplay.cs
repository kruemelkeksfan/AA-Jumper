using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoCanvasDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] string info;

    Text infoText;

    void Start()
    {
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
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
}
