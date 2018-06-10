using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolOptionsSet : MonoBehaviour {

    [SerializeField] Toggle ammunitionT;
    [SerializeField] Toggle collectorTowerT;
    [SerializeField] Toggle autoCollectT;
    [SerializeField] Toggle flyControlsT;
    [SerializeField] GameObject difficultyDataHolder;
	
	void Update ()
    {
		if (ammunitionT.isOn)
        {
            DifficultyData.ammunitionActiv = true;
        }
        else if (!ammunitionT.isOn)
        {
            DifficultyData.ammunitionActiv = false;
        }
        if (collectorTowerT.isOn)
        {
            DifficultyData.wreckCollecterTowerActive = true;
        }
        else if (!collectorTowerT.isOn)
        {
            DifficultyData.wreckCollecterTowerActive = false;
        }
        if (autoCollectT.isOn)
        {
            DifficultyData.wreckAutoCollectActiv = true;
        }
        else if (!autoCollectT.isOn)
        {
            DifficultyData.wreckAutoCollectActiv = false;
        }
        if (flyControlsT.isOn)
        {
            DifficultyData.controlsWhileFlyingActive = true;
        }
        else if (!flyControlsT.isOn)
        {
            DifficultyData.controlsWhileFlyingActive = false;
        }
    }
}
