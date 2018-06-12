using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static int baseHealth = 1;

    [SerializeField] bool kill = false;
    [SerializeField] GameObject losingScreen;

    private void Awake()
    {
        {
            baseHealth = DifficultyData.factoryStartHealth;
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