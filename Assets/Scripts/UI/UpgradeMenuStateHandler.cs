using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuStateHandler : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    UpgradeDisplayHandler upgradeDisplayHandler;

    private void Start()
    {
        upgradeDisplayHandler = upgradeMenu.GetComponent<UpgradeDisplayHandler>();
    }
    public UpgradeDisplayHandler SetState(bool state)
    {
        upgradeMenu.SetActive(state);
        if (state)
        {
            return upgradeDisplayHandler;
        }
        else
        {
            upgradeDisplayHandler.DisableActiveUpgradeDisplays();
            return null;
        }
        
    }
}
