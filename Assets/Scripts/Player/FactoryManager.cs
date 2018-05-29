using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static int baseHealth = 1;

    [SerializeField] bool kill = false;
    [SerializeField] int easyHealth = 1000;
    [SerializeField] int normalHealth = 750;
    [SerializeField] int hardHealth = 500;
    [SerializeField] int dreadnoughtHealth = 250;
    [SerializeField] GameObject losingScreen;

    private void Awake()
    {
        if (DifficultySet.easy)
        {
            baseHealth = easyHealth;
        }
        else if (DifficultySet.normal)
        {
            baseHealth = normalHealth;
        }
        else if (DifficultySet.hard)
        {
            baseHealth = hardHealth;
        }
        else if (DifficultySet.dreadnought)
        {
            baseHealth = dreadnoughtHealth;
        }
        else
        {
            baseHealth = 747;
        }
    }
    public void Update()
    {
        if (baseHealth <= 0 || kill)
        {
            PlayerControls.OnGameLost();
            losingScreen.SetActive(true);
        }
    }
}