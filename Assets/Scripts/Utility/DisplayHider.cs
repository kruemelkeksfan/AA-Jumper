using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHider : MonoBehaviour
{
    [SerializeField] bool hideIfAmmunitionDisabled = true;
    [SerializeField] bool hideIfCollectorTowerDisabled = false;
	void Awake ()
    {
		if ((!DifficultyData.ammunitionActiv && hideIfAmmunitionDisabled) || (!DifficultyData.wreckCollecterTowerActive && hideIfCollectorTowerDisabled))
        {
            Object.Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}

    private void OnEnable()
    {
        if ((!DifficultyData.ammunitionActiv && hideIfAmmunitionDisabled) || (!DifficultyData.wreckCollecterTowerActive && hideIfCollectorTowerDisabled))
        {
            gameObject.SetActive(false);
        }
    }
}
