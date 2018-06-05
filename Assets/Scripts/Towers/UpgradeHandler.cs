using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour {

    [SerializeField] GameObject towerErrorDisplay;
    [Header("Upgrade Base Cost")]
    [SerializeField] int rangeUpgradeBaseCost;
    [SerializeField] int firerateUpgradeBaseCost;
    [SerializeField] int damageUpgradeBaseCost;
    [SerializeField] int maxAmmunitionUpgradeBaseCost;
    [SerializeField] int autoRefillUpgradeCost;

    int maxRangeUpgrades;
    int maxFirerateUpgrades;
    int maxDamageUpgrades;
    int maxMaxAmmunitionUpgrades;

    TowerErrorMassageHandler towerErrorMassageHandler;
    UpgradeDisplayHandler upgradeDisplayHandler;
    TowerMenuController towerMenuController;
    TowerController towerController;

    public void UpdateUpgradeMenuData(TowerController towerControllerRef, TowerMenuController towerMenuControllerRef, int rangeDisplayerLength, int firerateDisplayerLength, int damageDisplayerLength, int maxAmmunitionDisplayerLength)
    {
        towerController = towerControllerRef;
        towerMenuController = towerMenuControllerRef;

        maxRangeUpgrades = rangeDisplayerLength;
        maxFirerateUpgrades = firerateDisplayerLength;
        maxDamageUpgrades = damageDisplayerLength;
        maxMaxAmmunitionUpgrades = maxAmmunitionDisplayerLength;

        upgradeDisplayHandler.SetUpgradeInfo(rangeUpgradeBaseCost, firerateUpgradeBaseCost, damageUpgradeBaseCost, maxAmmunitionUpgradeBaseCost, autoRefillUpgradeCost);
    }
    public void RangeUpgrade()
    {
        if (towerController.rangeUpgradeCount >= maxRangeUpgrades)
        {
            towerErrorMassageHandler.SetTowerError(towerController.rangeUpgradeCount + "/" + maxRangeUpgrades + " Upgrades");
        }
        else if (towerController.rangeUpgradeCount < maxRangeUpgrades)
        {
            if (ScrapManager.scrapCount >= rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1));
                towerController.rangeUpgradeCount = towerController.rangeUpgradeCount + 1;
                upgradeDisplayHandler.UpdateRangeDisplay();
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (rangeUpgradeBaseCost * (towerController.rangeUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void FirerateUpgrade()
    {
        if (towerController.firerateUpgradeCount >= maxFirerateUpgrades)
        {
            towerErrorMassageHandler.SetTowerError(towerController.firerateUpgradeCount + "/" + maxFirerateUpgrades + " Upgrades");
        }
        else if (towerController.firerateUpgradeCount < maxFirerateUpgrades)
        {
            if (ScrapManager.scrapCount >= firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1));
                towerController.firerateUpgradeCount = towerController.firerateUpgradeCount + 1;
                upgradeDisplayHandler.UpdateFirerateDisplay();
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (firerateUpgradeBaseCost * (towerController.firerateUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void DamageUpgrade()
    {
        if (towerController.damageUpgradeCount >= maxDamageUpgrades)
        {
            towerErrorMassageHandler.SetTowerError(towerController.damageUpgradeCount + " / " + maxDamageUpgrades + " Upgrades");
        }
        else if (towerController.damageUpgradeCount < maxDamageUpgrades)
        {
            if (ScrapManager.scrapCount >= damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1));
                towerController.damageUpgradeCount = towerController.damageUpgradeCount + 1;
                upgradeDisplayHandler.UpdateDamageDisplay();
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (damageUpgradeBaseCost * (towerController.damageUpgradeCount + 1) - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    public void MaxAmmunitionUpgrade()
    {
        if (towerController.maxAmmunitionUpgradeCount >= maxMaxAmmunitionUpgrades)
        {
            towerErrorMassageHandler.SetTowerError(towerController.maxAmmunitionUpgradeCount + "/" + maxMaxAmmunitionUpgrades + " Upgrades");
        }
        else if (towerController.maxAmmunitionUpgradeCount < maxMaxAmmunitionUpgrades)
        {
            if (ScrapManager.scrapCount >= maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1))
            {
                ScrapManager.scrapCount = ScrapManager.scrapCount - (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1));
                towerMenuController.towerCost = towerMenuController.towerCost + (maxAmmunitionUpgradeBaseCost * (towerController.maxAmmunitionUpgradeCount + 1));
                towerController.maxAmmunitionUpgradeCount = towerController.maxAmmunitionUpgradeCount + 1;
                upgradeDisplayHandler.UpdateMaxAmmunitionDisplay();
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
                upgradeDisplayHandler.UpdateAutoRefillDisplay();
            }
            else
            {
                towerErrorMassageHandler.SetTowerError("needs " + (autoRefillUpgradeCost - ScrapManager.scrapCount) + " more Scrap");
            }
        }
    }
    private void Start()
    {
        upgradeDisplayHandler = gameObject.GetComponent<UpgradeDisplayHandler>();
        towerErrorMassageHandler = towerErrorDisplay.GetComponent<TowerErrorMassageHandler>();
    }
}
