using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapManager : MonoBehaviour
{
    public static float scrapCount = 25;
    
    [SerializeField] float autoScrapStartTime = 15;
    float autoScrapAmount = 2;
    int autoScrapIntervall = 5;

    Text text;

    private void Awake()
    {
        scrapCount = DifficultyData.scrapStartAmmount;
        autoScrapAmount = DifficultyData.scrapAutoAmmount;
        autoScrapIntervall = DifficultyData.scrapAutoTime;
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
