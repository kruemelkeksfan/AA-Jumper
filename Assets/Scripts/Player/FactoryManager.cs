using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static int baseHealth = 1;

    [SerializeField] int health = 1000;
    [SerializeField] GameObject losingScreen;

    private void Awake()
    {
        baseHealth = health;
    }
    public void Update()
    {
        if (baseHealth <= 0)
        {
            PlayerControls.OnGameLost();
            losingScreen.SetActive(true);
        }
    }
}