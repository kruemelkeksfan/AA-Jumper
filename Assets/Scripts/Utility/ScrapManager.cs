using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapManager : MonoBehaviour
{
    public static float scrapCount = 25;
    [SerializeField] float autoScrapAmount = 2;
    [SerializeField] float autoScrapStartTime = 15;
    [SerializeField] int autoScrapIntervall = 5;
    [SerializeField] float startScrap = 25;
    Text text;

    private void Awake()
    {
        scrapCount = startScrap;
    }
    void Start()
    {
        InvokeRepeating("AutoAddScrap", autoScrapStartTime, autoScrapIntervall);
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = "Scrap: " + scrapCount;
    }

    private void AutoAddScrap()
    {
        scrapCount = scrapCount + autoScrapAmount;
    }
}
