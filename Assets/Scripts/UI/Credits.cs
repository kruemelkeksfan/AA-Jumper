using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject gameName;
    [SerializeField] GameObject credits;

    bool creditsactive;

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            creditsactive = false;
            gameName.SetActive(true);
            credits.SetActive(false);
        }
	}
    public void ToggleCredits()
    {
        creditsactive = !creditsactive;
        gameName.SetActive(!creditsactive);
        credits.SetActive(creditsactive);
    }
}
