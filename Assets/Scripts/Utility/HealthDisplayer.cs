using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    string currentHealth;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update ()
    {
        currentHealth = FactoryManager.baseHealth.ToString();
        text.text = "Health " + currentHealth;
    }
}
