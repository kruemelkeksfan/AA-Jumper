using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionDisplayHider : MonoBehaviour
{
	void Awake ()
    {
		if (!DifficultyData.ammunitionActiv)
        {
            Object.Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}

    private void OnEnable()
    {
        if (!DifficultyData.ammunitionActiv)
        {
            gameObject.SetActive(false);
        }
    }
}
