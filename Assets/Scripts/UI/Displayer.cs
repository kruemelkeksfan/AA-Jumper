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

    private void Start()
    {
        score = 0;
        towerErrorText.text = "";
        infoDisplay.text = "";
        if (DifficultyData.difficultyMultiplicator <= 1.75f)
        {
            difficultyText.color = easyColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > 1.75f && DifficultyData.difficultyMultiplicator <= 4f)
        {
            difficultyText.color = normalColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > 4f && DifficultyData.difficultyMultiplicator <= 6.5f)
        {
            difficultyText.color = hardColor;
            difficultyMultiText = DifficultyData.difficultyMultiplicator.ToString();
        }
        else if (DifficultyData.difficultyMultiplicator > 6.5f)
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
