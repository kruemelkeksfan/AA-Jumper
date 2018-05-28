using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour
{
    public static int score;

    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text towerErrorText;
    [SerializeField] Text difficultyText;
    [SerializeField] Text LevelText;
    [Header("Difficulty Color")]
    [SerializeField] Color easyColor;
    [SerializeField] Color normalColor;
    [SerializeField] Color hardColor;
    [SerializeField] Color dreadnoughtColor;

    string difficultyLetter;

    private void Start()
    {
        score = 0;
        towerErrorText.text = "";
        if (DifficultySet.easy)
        {
            difficultyText.color = easyColor;
            difficultyLetter = "E";
        }
        else if (DifficultySet.normal)
        {
            difficultyText.color = normalColor;
            difficultyLetter = "N";
        }
        else if (DifficultySet.hard)
        {
            difficultyText.color = hardColor;
            difficultyLetter = "H";
        }
        else if (DifficultySet.dreadnought)
        {
            difficultyText.color = dreadnoughtColor;
            difficultyLetter = "D";
        }
        else
        {
            difficultyLetter = "E";
        }
    }
    void Update ()
    {
        healthText.text = "Health: " + FactoryManager.baseHealth;
        scoreText.text = "Score: " + score;
        difficultyText.text = difficultyLetter;
        LevelText.text = "Level: " + EnemySpawner.gameLevel;
    }
}
