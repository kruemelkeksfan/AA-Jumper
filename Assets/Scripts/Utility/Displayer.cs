﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour
{
    public static int score;

    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text towerErrorText;

    private void Start()
    {
        score = 0;
        towerErrorText.text = "";
    }
    void Update ()
    {
        healthText.text = "Health: " + FactoryManager.baseHealth;
        scoreText.text = "Score: " + score;
    }
}
