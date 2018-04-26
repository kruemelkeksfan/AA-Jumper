using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapManager : MonoBehaviour
{
    public static float scrapCount = 75;
    [SerializeField] float scrapPSec = 1;
    [SerializeField] float scrapStartTime = 1;
    Text text;
  
    void Start()
    {
        InvokeRepeating("ScrapPSec", scrapStartTime, 1);
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = "Scrap: " + scrapCount;
    }

    private void ScrapPSec()
    {
        scrapCount = scrapCount + scrapPSec;
    }
}
