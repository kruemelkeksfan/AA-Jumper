using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour {

    [SerializeField] GameObject towerErrorDisplay;
    [SerializeField] GameObject[] activeUpgradesDisplayerRange;
    [SerializeField] GameObject[] activeUpgradesDisplayerFirerate;
    [SerializeField] GameObject[] activeUpgradesDisplayerDamage;
    [SerializeField] GameObject[] activeUpgradesDisplayerMaxAmmunition;
    [SerializeField] GameObject activeUpgradeDisplayerAutoRefill;
    [Header("Upgrade Base Cost")]
    [SerializeField] int rangeUpgradeBaseCost;
    [SerializeField] int firerateUpgradeBaseCost;
    [SerializeField] int damageUpgradeBaseCost;
    [SerializeField] int maxAmmunitionUpgradeBaseCost;
    [SerializeField] int autoRefillUpgradeCost;
    [Header("Buttons")]
    [SerializeField] GameObject rangeButton;
    [SerializeField] GameObject firerateButton;
    [SerializeField] GameObject damageButton;
    [SerializeField] GameObject maxAmmunitionButton;
    [SerializeField] GameObject autoRefillButton;

    string towerNameRef;

    int upgradeRange;
    float upgradeFirerate;
    float upgradeDamage;
    float upgradeMaxAmmunition;

    TowerErrorMassageHandler towerErrorMassageHandler;
    TowerMenuController towerMenuController;
    TowerController towerController;

    InfoUpgradeCanvasDisplay rangeUpgradeInfo;
    InfoUpgradeCanvasDisplay firerateUpgradeInfo;
    InfoUpgradeCanvasDisplay damageUpgradeInfo;
    InfoUpgradeCanvasDisplay maxAmmunitionUpgradeInfo;
    InfoUpgradeCanvasDisplay autoRefillUpgradeInfo;

    public void UpdateUpgradeStatus(TowerController towerControllerRef,TowerMenuController towerMenuControllerRef, int upgradeRangeRef, float upgradeFirerateRef, float upgradeDamageRef, float upgradeMaxAmmunitionRef) // updates upgrade display 
    {
        towerController = towerControllerRef;
        towerMenuController = towerMenuControllerRef;

        upgradeRange = upgradeRangeRef;
        upgradeFirerate = upgradeFirerateRef;
        upgradeDamage = upgradeDamageRef;
        upgradeMaxAmmunition = upgradeMaxAmmunitionRef;

        rangeUpgradeInfo.SetUpgradeInfo((" + " + upgradeRange + " Range"), ((rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1)) + " Scrap"));
        firerateUpgradeInfo.SetUpgradeInfo((" + " + upgradeFirerate + " Fire Rate"), ((firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1)) + " Scrap"));
        damageUpgradeInfo.SetUpgradeInfo((" + " + upgradeDamage + " Damage"), ((damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1)) + " Scrap"));
        maxAmmunitionUpgradeInfo.SetUpgradeInfo((" + " + upgradeMaxAmmunition + " max Ammunition"), ((maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1)) + " Scrap"));
        autoRefillUpgradeInfo.SetUpgradeInfo((" automatic ammunition refill"), (autoRefillUpgradeCost + " Scrap"));

        for (int I = 0; I < towerController.rangeUpgradeCount; ++I)
        {
            activeUpgradesDisplayerRange[I].SetActive(true);
        }
        for (int I = 0; I < towerController.firerateUpgradeCount; ++I)
        {
            activeUpgradesDisplayerRange[I].SetActive(true);
        }
        for (int I = 0; I < towerController.damageUpgradeCount; ++I)
        {
            activeUpgradesDisplayerRange[I].SetActive(true);
        }
        for (int I = 0; I < towerController.maxAmmunitionUpgradeCount; ++I)
        {
            activeUpgradesDisplayerRange[I].SetActive(true);
        }
        if (towerController.autoRefillActive)
        {
            activeUpgradeDisplayerAutoRefill.SetActive(true);
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
    public void RangeUpgrade()
    {
        if (towerController.rangeUpgradeCount >= activeUpgradesDisplayerRange.Length)
        {
            towerErrorMassageHandler.SetTowerError(towerController.rangeUpgradeCount + "/" + activeUpgradesDisplayerRange.Length + " Upgrades");
        }
        else if (towerController.rangeUpgradeCount < activeUpgradesDisplayerRange.Length)
        {
            if (ScrapManager.scrapCount >= rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1));
                towerController.rangeUpgradeCount = towerController.rangeUpgradeCount + 1;
                rangeUpgradeInfo.SetUpgradeInfo((" + " + upgradeRange + " Range"), ((rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1)) + " Scrap"));
                for (int I = 0; I < towerController.rangeUpgradeCount; ++I)
                {
                    activeUpgradesDisplayerRange[I].SetActive(true);
                }
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void FirerateUpgrade()
    {
        if (towerController.firerateUpgradeCount >= activeUpgradesDisplayerFirerate.Length)
        {
            towerErrorMassageHandler.SetTowerError(towerController.firerateUpgradeCount + "/" + activeUpgradesDisplayerFirerate.Length + " Upgrades");
        }
        else if (towerController.firerateUpgradeCount < activeUpgradesDisplayerFirerate.Length)
        {
            if (ScrapManager.scrapCount >= firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1));
                towerController.firerateUpgradeCount = towerController.firerateUpgradeCount + 1;
                firerateUpgradeInfo.SetUpgradeInfo((" + " + upgradeFirerate + " Fire Rate"), ((firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1)) + " Scrap"));
                for (int I = 0; I < towerController.firerateUpgradeCount; ++I)
                {
                    activeUpgradesDisplayerFirerate[I].SetActive(true);
                }
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void DamageUpgrade()
    {
        if (towerController.damageUpgradeCount >= activeUpgradesDisplayerDamage.Length)
        {
            towerErrorMassageHandler.SetTowerError(towerController.damageUpgradeCount + " / " + activeUpgradesDisplayerDamage.Length + " Upgrades");
        }
        else if (towerController.damageUpgradeCount < activeUpgradesDisplayerDamage.Length)
        {
            if (ScrapManager.scrapCount >= damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1));
                towerController.damageUpgradeCount = towerController.damageUpgradeCount + 1;
                damageUpgradeInfo.SetUpgradeInfo((" + " + upgradeDamage + " Damage"), ((damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1)) + " Scrap"));
                for (int I = 0; I < towerController.damageUpgradeCount; ++I)
                {
                    activeUpgradesDisplayerDamage[I].SetActive(true);
                }
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void MaxAmmunitionUpgrade()
    {
        if (towerController.maxAmmunitionUpgradeCount >= activeUpgradesDisplayerMaxAmmunition.Length)
        {
            towerErrorMassageHandler.SetTowerError(towerController.maxAmmunitionUpgradeCount + "/" + activeUpgradesDisplayerMaxAmmunition.Length + " Upgrades");
        }
        else if (towerController.maxAmmunitionUpgradeCount < activeUpgradesDisplayerMaxAmmunition.Length)
        {
            if (ScrapManager.scrapCount >= maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1));
                towerController.maxAmmunitionUpgradeCount = towerController.maxAmmunitionUpgradeCount + 1;
                maxAmmunitionUpgradeInfo.SetUpgradeInfo((" + " + upgradeMaxAmmunition + " max Ammunition"), ((maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1)) + " Scrap"));
                for (int I = 0; I < towerController.maxAmmunitionUpgradeCount; ++I)
                {
                    activeUpgradesDisplayerMaxAmmunition[I].SetActive(true);
                }
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void AutoRefillUpgrade()
    {
        if (towerController.autoRefillActive)
        {
            towerErrorMassageHandler.SetTowerError("Auto refill is already Enabled");
        }
        else
        {
            if (ScrapManager.scrapCount >= autoRefillUpgradeCost)
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - autoRefillUpgradeCost;
                towerMenuController.towerCost = towerMenuController.towerCost + autoRefillUpgradeCost;
                towerController.autoRefillActive = true;
                activeUpgradeDisplayerAutoRefill.SetActive(true);
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (autoRefillUpgradeCost - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }

    void Start ()
    {
        towerErrorMassageHandler = towerErrorDisplay.GetComponent<TowerErrorMassageHandler>();
        rangeUpgradeInfo = rangeButton.GetComponent<InfoUpgradeCanvasDisplay>();
        firerateUpgradeInfo = firerateButton.GetComponent<InfoUpgradeCanvasDisplay>();
        damageUpgradeInfo = damageButton.GetComponent<InfoUpgradeCanvasDisplay>();
        maxAmmunitionUpgradeInfo = maxAmmunitionButton.GetComponent<InfoUpgradeCanvasDisplay>();
        autoRefillUpgradeInfo = autoRefillButton.GetComponent<InfoUpgradeCanvasDisplay>();
        gameObject.SetActive(false);
    }
}
