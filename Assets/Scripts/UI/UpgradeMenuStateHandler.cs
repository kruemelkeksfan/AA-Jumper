using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuStateHandler : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    UpgradeHandler upgradeHandler;

    private void Start()
    {
        upgradeHandler = upgradeMenu.GetComponent<UpgradeHandler>();
    }
    public UpgradeHandler SetState(bool state)
    {
        upgradeMenu.SetActive(state);
        if (state)
        {
            return upgradeHandler;
        }
        else
        {
            upgradeHandler.DisableActiveUpgradeDisplays();
            return null;
        }
        
    }
}
