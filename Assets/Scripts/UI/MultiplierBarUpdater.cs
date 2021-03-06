﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierBarUpdater : MonoBehaviour {

    [SerializeField] Text multiplierText;
    [SerializeField] Image multiplierBar;

    float multiplierFillAmmount;

    DifficultyMultiplyerSet difficultyMultiplyerSet;

	void Start ()
    {
        difficultyMultiplyerSet = gameObject.GetComponent<DifficultyMultiplyerSet>();
	}
	
	void Update ()
    {
        multiplierText.text = "Score Multiplied by " + DifficultyData.difficultyMultiplicator.ToString();
        multiplierFillAmmount = ((DifficultyData.difficultyMultiplicator - difficultyMultiplyerSet.multiplierMin) / ((difficultyMultiplyerSet.multiplierMax - difficultyMultiplyerSet.multiplierMin) / 100)) /100;
        multiplierBar.fillAmount = multiplierFillAmmount;
	}
}
