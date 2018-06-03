using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerErrorMassageHandler : MonoBehaviour {

    [SerializeField] float errorDisplayTime = 3;
    [SerializeField] Text TowerErrorText;

    float errorDisplayStartTime;

    void Start ()
    {
        TowerErrorText.text = "";
	}
	
	void Update ()
    {
        if (errorDisplayStartTime + errorDisplayTime < Time.time)
        {
            TowerErrorText.text = "";
        }
    }
    public void SetTowerError(string errorText)
    {
        TowerErrorText.text = errorText;
        errorDisplayStartTime = Time.time;
    }
}
