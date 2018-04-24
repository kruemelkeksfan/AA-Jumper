using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapManager : MonoBehaviour
{
    public static int scrapCount = 75;
    Text text;
    System.DateTime starttime = System.DateTime.Now;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        if (System.DateTime.Now.Subtract(starttime) >= new System.TimeSpan(0, 0, 1))
        {
            ++scrapCount;
            starttime = System.DateTime.Now;
        }

        text.text = "Scrap: " + scrapCount;
    }
}
