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
    Transform Player;

    private void Start()
    {
        TowerCCount = 0;
        EnvironmentCCount = 0;
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Player = playerGameObject.GetComponent<Transform>();
        GameObject towerErrorTextGameObject = GameObject.FindGameObjectWithTag("TowerErrorText");
        towerErrorMassageHandler = towerErrorTextGameObject.GetComponent<TowerErrorMassageHandler>();
        InvokeRepeating("AutoDeactivateCanvas", 1, 2); //deactivates Canvas every 2 sec if player is not nearby
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            towerCanvas.SetActive(false);
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
    private void OnMouseDown()
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
    private void AutoDeactivateCanvas() //deactivates Canvas every 2 sec if player is not nearby
    {
        if (!PlayerNearby())
        {
            towerCanvas.SetActive(false);
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
    }
    public void SetCanvasActive()
    {
        canvasActive = true;
    }
}


