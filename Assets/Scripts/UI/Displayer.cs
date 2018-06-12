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
    [SerializeField] Text infoDisplay;
    [Header("Difficulty Color")]
    [SerializeField] Color easyColor;
    [SerializeField] Color normalColor;
    [SerializeField] Color hardColor;
    [SerializeField] Color dreadnoughtColor;

    string difficultyMultiText;

    float easyMaxMulti = 3;
    float normalMaxMulti = 15;
    float harhMaxMulti = 40;

    private void Start()
    {
        score = 0;
        towerErrorText.text = "";
        infoDisplay.text = "";
        if (DifficultyData.difficultyMultiplicator <= easyMaxMulti)
        {
            difficultyText.color = easyColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > easyMaxMulti && DifficultyData.difficultyMultiplicator <= normalMaxMulti)
        {
            difficultyText.color = normalColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > normalMaxMulti && DifficultyData.difficultyMultiplicator <= harhMaxMulti)
        {
            difficultyText.color = hardColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > harhMaxMulti)
        {
            difficultyText.color = dreadnoughtColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else
        {
            difficultyMultiText = "E";
        }
    }
    void Update ()
    {
        healthText.text = "Health: " + FactoryManager.baseHealth;
        scoreText.text = "Score: " + (score * DifficultyData.difficultyMultiplicator);
        difficultyText.text = difficultyMultiText;
        LevelText.text = "Level: " + EnemySpawner.gameLevel;
    }
}
