using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoObjectDisplayer : MonoBehaviour
{

    [SerializeField] string info;

    Text infoText;

	void Start ()
    {
        GameObject infoDisplay = GameObject.FindGameObjectWithTag("InfoDisplay");
        infoText = infoDisplay.GetComponent<Text>();
	}
	
	void OnMouseOver ()
    {
        infoText.text = info;
	}

    void OnMouseExit()
    {
        infoText.text = "";
    }
}
