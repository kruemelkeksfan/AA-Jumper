using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    public static bool moreLight;
    public static bool muchMoreLight;
    public static bool rain = true;
    public static bool clouds = true;

    [SerializeField] Toggle moreLightT;
    [SerializeField] Toggle muchMoreLightT;
    [SerializeField] Toggle rainT;
    [SerializeField] Toggle cloudsT;

	void Update ()
    {
        moreLight = moreLightT.isOn;
        muchMoreLight = muchMoreLightT.isOn;
        rain = rainT.isOn;
        clouds = cloudsT.isOn;
    }
}
