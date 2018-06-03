using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableTower : MonoBehaviour
{
    public static int TowerCCount;
    public static int EnvironmentCCount;

    [SerializeField] List<Collider> hittingTower = new List<Collider>();
    [SerializeField] List<Collider> hittingEnvironment = new List<Collider>();
    [SerializeField] GameObject towerCanvas;

    int platformWidth = 5;
    float irregularityCompensation = 0.1f;
    bool canvasActive = false;

    TowerErrorMassageHandler towerErrorMassageHandler;
    UpgradeMenuStateHandler upgradeMenuStateHandler;
    TowerController towerController;
    Transform Player;

    public void SetCanvasActive()
    {
        canvasActive = true;
    }
    public void SetUpgradeMenuActive()
    {
        UpgradeHandler upgradeHandler = upgradeMenuStateHandler.SetState(true);
        towerController.SetUpgradeState(upgradeHandler);
    }
    void Start()
    {
        TowerCCount = 0;
        EnvironmentCCount = 0;

        towerController = gameObject.GetComponent<TowerController>();
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Player = playerGameObject.GetComponent<Transform>();
        GameObject towerErrorTextGameObject = GameObject.FindGameObjectWithTag("TowerErrorText");
        towerErrorMassageHandler = towerErrorTextGameObject.GetComponent<TowerErrorMassageHandler>();
        GameObject upgradeCanvasHolder = GameObject.FindGameObjectWithTag("UpgradeMenuHolder");
        upgradeMenuStateHandler = upgradeCanvasHolder.GetComponent<UpgradeMenuStateHandler>();

        InvokeRepeating("AutoDeactivateCanvas", 1, 2); //controlls every 2 secs that canvases are not active while player is away
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DisableCanvases();
        }
    }
    void OnTriggerEnter (Collider c)
    {
        
        if (c.tag == "Tower")
        {
            hittingTower.Add(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Add(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Remove(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Remove(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
    void OnMouseDown()
    {
        if (PlayerNearby() && canvasActive)
        {
            towerCanvas.SetActive(true);
        }
        else if (canvasActive)
        {
            towerErrorMassageHandler.SetTowerError("player to far away");
        }
    }
    void AutoDeactivateCanvas() //controlls every 2 secs that canvases are not active while player is away
    {
        if (!towerCanvas.activeSelf)
        {
            return;
        }
        else if (!PlayerNearby())
        {
            DisableCanvases();
        }
    }
    void DisableCanvases()
    {
        towerCanvas.SetActive(false);
        upgradeMenuStateHandler.SetState(false);
        Debug.Log("colsed Canvases");
    }//disables both canvases if called
    bool PlayerNearby()
    {
        if (transform.position.y - irregularityCompensation < Player.position.y && Player.position.y < transform.position.y + irregularityCompensation)
        {
            if (transform.position.x - platformWidth < Player.position.x && Player.position.x < transform.position.x + platformWidth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }//checks if player is near enough to interact
}


