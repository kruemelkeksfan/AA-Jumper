using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDisplayHandler : MonoBehaviour
{
    [SerializeField] GameObject[] activeUpgradesDisplayerRange;
    [SerializeField] GameObject[] activeUpgradesDisplayerFirerate;
    [SerializeField] GameObject[] activeUpgradesDisplayerDamage;
    [SerializeField] GameObject[] activeUpgradesDisplayerMaxAmmunition;
    [SerializeField] GameObject activeUpgradeDisplayerAutoRefill;
    [Header("Buttons")]
    [SerializeField] GameObject rangeButton;
    [SerializeField] GameObject firerateButton;
    [SerializeField] GameObject damageButton;
    [SerializeField] GameObject maxAmmunitionButton;
    [SerializeField] GameObject autoRefillButton;

    int rangeUpgradeBaseCost;
    int firerateUpgradeBaseCost;
    int damageUpgradeBaseCost;
    int maxAmmunitionUpgradeBaseCost;
    int autoRefillUpgradeCost;

    int upgradeRange;
    float upgradeFirerate;
    float upgradeDamage;
    float upgradeMaxAmmunition;

    UpgradeHandler upgradeHandler;
    TowerController towerController = null;

    InfoUpgradeCanvasDisplay rangeUpgradeInfo;
    InfoUpgradeCanvasDisplay firerateUpgradeInfo;
    InfoUpgradeCanvasDisplay damageUpgradeInfo;
    InfoUpgradeCanvasDisplay maxAmmunitionUpgradeInfo;
    InfoUpgradeCanvasDisplay autoRefillUpgradeInfo;

    public void UpdateUpgradeStatus(TowerController towerControllerRef, TowerMenuController towerMenuControllerRef, int upgradeRangeRef, float upgradeFirerateRef, float upgradeDamageRef, float upgradeMaxAmmunitionRef) // updates upgrade display 
    {
        towerController = towerControllerRef;

        upgradeRange = upgradeRangeRef;
        upgradeFirerate = upgradeFirerateRef;
        upgradeDamage = upgradeDamageRef;
        upgradeMaxAmmunition = upgradeMaxAmmunitionRef;

        upgradeHandler.UpdateUpgradeMenuData(towerControllerRef, towerMenuControllerRef, activeUpgradesDisplayerRange.Length, activeUpgradesDisplayerFirerate.Length, activeUpgradesDisplayerDamage.Length, activeUpgradesDisplayerMaxAmmunition.Length);
    }
    public void SetUpgradeInfo(int rangeBaseCost, int firerateBaseCost, int damageBaseCost,int maxAmmunitionBaseCost, int autoRefillCost)
    {
        rangeUpgradeBaseCost = rangeBaseCost;
        firerateUpgradeBaseCost = firerateBaseCost;
        damageUpgradeBaseCost = damageBaseCost;
        maxAmmunitionUpgradeBaseCost = maxAmmunitionBaseCost;
        autoRefillUpgradeCost = autoRefillCost;

        UpdateRangeDisplay();
        UpdateFirerateDisplay();
        UpdateDamageDisplay();
        UpdateMaxAmmunitionDisplay();
        UpdateAutoRefillDisplay();
    }
    public void UpdateRangeDisplay()
    {
        if (towerController == null) { return; }
        for (int I = 0; I < towerController.rangeUpgradeCount; ++I)
        {
            activeUpgradesDisplayerRange[I].SetActive(true);
        }
        if (towerController.rangeUpgradeCount < activeUpgradesDisplayerRange.Length)
        {
            rangeUpgradeInfo.SetUpgradeInfo("Tower gets + " + upgradeRange + " Range for " + (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1)) + " Scrap");
        }
        else
        {
            rangeUpgradeInfo.SetUpgradeInfo("No more upgrades available");
        }
    }
    public void UpdateFirerateDisplay()
    {
        if (towerController == null) { return; }
        for (int I = 0; I < towerController.firerateUpgradeCount; ++I)
        {
            activeUpgradesDisplayerFirerate[I].SetActive(true);
        }
        if (towerController.firerateUpgradeCount < activeUpgradesDisplayerFirerate.Length)
        {
            firerateUpgradeInfo.SetUpgradeInfo("Tower gets + " + upgradeFirerate + " Fire Rate for " + (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1)) + " Scrap");
        }
        else
        {
            firerateUpgradeInfo.SetUpgradeInfo("No more upgrades available");
        }
    }
    public void UpdateDamageDisplay()
    {
        if (towerController == null) { return; }
        for (int I = 0; I < towerController.damageUpgradeCount; ++I)
        {
            activeUpgradesDisplayerDamage[I].SetActive(true);
        }
        if (towerController.damageUpgradeCount < activeUpgradesDisplayerDamage.Length)
        {
            damageUpgradeInfo.SetUpgradeInfo("Tower gets + " + upgradeDamage + " Damage for " + (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1)) + " Scrap");
        }
        else
        {
            damageUpgradeInfo.SetUpgradeInfo("No more upgrades available");
        }
    }
    public void UpdateMaxAmmunitionDisplay()
    {
        if (towerController == null) { return; }
        for (int I = 0; I < towerController.maxAmmunitionUpgradeCount; ++I)
        {
            activeUpgradesDisplayerMaxAmmunition[I].SetActive(true);
        }
        if (towerController.maxAmmunitionUpgradeCount < activeUpgradesDisplayerMaxAmmunition.Length)
        {
            maxAmmunitionUpgradeInfo.SetUpgradeInfo("Tower gets + " + upgradeMaxAmmunition + " max Ammunition for " + (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1)) + " Scrap");
        }
        else
        {
            maxAmmunitionUpgradeInfo.SetUpgradeInfo("No more upgrades available");
        }
    }
    public void UpdateAutoRefillDisplay()
    {
        if (towerController == null) { return; }
        if (towerController.autoRefillActive)
        {
            activeUpgradeDisplayerAutoRefill.SetActive(true);
            autoRefillUpgradeInfo.SetUpgradeInfo("Auto refill is already enabled");
        }
        else
        {
            autoRefillUpgradeInfo.SetUpgradeInfo("Tower gets automatic ammunition refill for " + autoRefillUpgradeCost + " Scrap");
        }
    }
    public void DisableActiveUpgradeDisplays()
    {
        foreach (GameObject upgradeDisplay in activeUpgradesDisplayerRange)
        {
            upgradeDisplay.SetActive(false);
        }
        foreach (GameObject upgradeDisplay in activeUpgradesDisplayerFirerate)
        {
            upgradeDisplay.SetActive(false);
        }
        foreach (GameObject upgradeDisplay in activeUpgradesDisplayerDamage)
        {
            upgradeDisplay.SetActive(false);
        }
        foreach (GameObject upgradeDisplay in activeUpgradesDisplayerMaxAmmunition)
        {
            upgradeDisplay.SetActive(false);
        }
        activeUpgradeDisplayerAutoRefill.SetActive(false);
    }
    void Start()
    {
        upgradeHandler = gameObject.GetComponent<UpgradeHandler>();
        rangeUpgradeInfo = rangeButton.GetComponent<InfoUpgradeCanvasDisplay>();
        firerateUpgradeInfo = firerateButton.GetComponent<InfoUpgradeCanvasDisplay>();
        damageUpgradeInfo = damageButton.GetComponent<InfoUpgradeCanvasDisplay>();
        maxAmmunitionUpgradeInfo = maxAmmunitionButton.GetComponent<InfoUpgradeCanvasDisplay>();
        autoRefillUpgradeInfo = autoRefillButton.GetComponent<InfoUpgradeCanvasDisplay>();
        gameObject.SetActive(false);
    }
}
