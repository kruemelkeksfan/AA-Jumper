using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableCollectorTower : MonoBehaviour
{

    public static int TowerColCount;
    public static int EnvironmentColCount;

    [SerializeField] List<Collider> hittingTower = new List<Collider>();
    [SerializeField] List<Collider> hittingEnvironment = new List<Collider>();
    [SerializeField] GameObject towerCanvas;

    TowerErrorMassageHandler towerErrorMassageHandler;
    Transform Player;

    int platformWidth = 5;
    float irregularityCompensation = 0.1f;
    bool canvasvailable = false;

    public void SetCanvasAvailable()
    {
        canvasvailable = true;
    }
    public void DisableCanvas()
    {
        towerErrorMassageHandler.towerCanvasActive = false;
        towerCanvas.SetActive(false);
    }//disables canvas if called
    void Start()
    {
        TowerColCount = 0;
        EnvironmentColCount = 0;

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Player = playerGameObject.GetComponent<Transform>();
        GameObject towerErrorTextGameObject = GameObject.FindGameObjectWithTag("TowerErrorText");
        towerErrorMassageHandler = towerErrorTextGameObject.GetComponent<TowerErrorMassageHandler>();

        InvokeRepeating("AutoDeactivateCanvas", 1, 2); //controls every 2 secs that canvas is not active while player is away
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DisableCanvas();
        }
    }
    void OnMouseDown()
    {
        if (PlayerNearby() && canvasvailable && !towerErrorMassageHandler.towerCanvasActive)
        {
            towerCanvas.SetActive(true);
            towerErrorMassageHandler.towerCanvasActive = true;
        }
        else if (canvasvailable && !towerErrorMassageHandler.towerCanvasActive)
        {
            towerErrorMassageHandler.SetTowerError("player to far away");
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Add(c);
            TowerColCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Add(c);
            EnvironmentColCount = hittingEnvironment.Count;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Remove(c);
            TowerColCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Remove(c);
            EnvironmentColCount = hittingEnvironment.Count;
        }
    }
    void AutoDeactivateCanvas() //controls every 2 secs that canvas is not active while player is away
    {
        if (!towerCanvas.activeSelf)
        {
            return;
        }
        else if (!PlayerNearby())
        {
            DisableCanvas();
        }
    }
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
