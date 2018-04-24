using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryManager : MonoBehaviour
{
    public static int baseHealth = 1;

    public void Update()
    {
        if (baseHealth <= 0)
        {
            System.Environment.Exit(0);
        }
    }
}