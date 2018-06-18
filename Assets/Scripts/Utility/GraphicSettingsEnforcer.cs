using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSettingsEnforcer : MonoBehaviour
{
    [Header("Destroy On:")]
    [SerializeField] bool moreLightOff;
    [SerializeField] bool muchMoreLightOff;
    [SerializeField] bool rainOff;
    [SerializeField] bool cloudsOff;
	
	void Start ()
    {
		if ((moreLightOff && !GraphicSettings.moreLight) || (muchMoreLightOff && !GraphicSettings.muchMoreLight) || (rainOff && !GraphicSettings.rain) || (cloudsOff && !GraphicSettings.clouds))
        {
            Object.Destroy(gameObject);
        }
	}
}
