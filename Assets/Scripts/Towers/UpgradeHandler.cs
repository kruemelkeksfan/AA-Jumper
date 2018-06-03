using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour {

    int rangeUpgradeCount;
    int firerateUpgradeCount;
    int damageUpgradeCount;
    int maxAmmunitionUpgradeCount;
    bool autoRefillActive;

    TowerController towerController;

    public void UpdateUpgradeStatus(TowerController towerControllerRef, int rangeUpgrades, int firerateUpgrades, int damageUpgrades, int maxAmmumitionUpgrades, bool autoRefillActiveRef) // updates upgrade display 
    {
        towerController = towerControllerRef;
        rangeUpgradeCount = rangeUpgrades;
        firerateUpgradeCount = firerateUpgrades;
        damageUpgradeCount = damageUpgrades;
        maxAmmunitionUpgradeCount = maxAmmumitionUpgrades;
        autoRefillActive = autoRefillActiveRef;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
