﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public static bool hasPlaced = true;
    public static float rangeXPosition;

    [Tooltip("Machine Cannon")][SerializeField] int prizeTower1 = 25;
    [Tooltip("Quadruple Machine Cannon")][SerializeField] int prizeTower2 = 100;
    [Tooltip("Heavy Anti Air Artillery")][SerializeField] int prizeTower3 = 125;
    [Tooltip("Mine Launcher")][SerializeField] int prizeTower4 = 50;
    [Tooltip("Rocket Launcher")][SerializeField] int prizeTower5 = 75;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject RangeDisplay;
    
    [SerializeField] Text text;

    float towerLaneDepth = -1.5f;
    float cameraZPosition = 63.5f;
    float halfPlatformRange = 1.75f;
    float textDisplayTime = 5;
    
    float playerXPosition;
    float buildArea;
    float textDeleteTime;

    GameObject T;
    Transform currentTower;
    TowerController towerController;

    private void Start()
    {
        text.text = "";
    }
    void FixedUpdate()
    {
        if (currentTower != null && !hasPlaced)
        {
            Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cameraZPosition + towerLaneDepth);
            Vector3 mouseRPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            playerXPosition = Player.transform.position.x;
            buildArea = Mathf.Clamp(mouseRPosition.x, playerXPosition - halfPlatformRange, playerXPosition + halfPlatformRange);
            currentTower.position = new Vector3(buildArea, Player.transform.position.y, towerLaneDepth);
        }
    }
    void Update()
    {
        if (currentTower != null && !hasPlaced)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    switch (currentTower.name)
                    {
                        case "Machine Cannon(25)(Clone)":
                            {
                                if (prizeTower1 <= ScrapManager.scrapCount)
                                {
                                    ScrapManager.scrapCount -= prizeTower1;
                                    TowerPlaced();
                                }
                                else
                                {
                                    SetText("not enough Scrap, Missing: " + (prizeTower1 - ScrapManager.scrapCount));
                                }
                                break;
                            }
                        case "Quadruple Machine Cannon(100)(Clone)":
                            {
                                if (prizeTower2 <= ScrapManager.scrapCount)
                                {
                                    ScrapManager.scrapCount -= prizeTower2;
                                    TowerPlaced();
                                }
                                else
                                {
                                    SetText("not enough Scrap, Missing: " + (prizeTower2 - ScrapManager.scrapCount));
                                }
                                break;
                            }
                        case "Heavy Anti Air Artillery(125)(Clone)":
                            {
                                if (prizeTower3 <= ScrapManager.scrapCount)
                                {
                                    ScrapManager.scrapCount -= prizeTower3;
                                    TowerPlaced();
                                }
                                else
                                {
                                    SetText("not enough Scrap, Missing: " + (prizeTower3 - ScrapManager.scrapCount));
                                }
                                break;
                            }
                        case "Mine Launcher(50)(Clone)":
                            {
                                if (prizeTower4 <= ScrapManager.scrapCount)
                                {
                                    ScrapManager.scrapCount -= prizeTower4;
                                    TowerPlaced();
                                }
                                else
                                {
                                    SetText ("not enough Scrap, Missing: " + (prizeTower4 - ScrapManager.scrapCount));
                                }
                                break;
                            }
                        case "Rocket Launcher(75)(Clone)":
                            {
                                if (prizeTower5 < ScrapManager.scrapCount)
                                {
                                    ScrapManager.scrapCount -= prizeTower5;
                                    TowerPlaced();
                                }
                                else
                                {
                                    SetText ("not enough Scrap, Missing: " + (prizeTower5 - ScrapManager.scrapCount));
                                }
                                break;
                            }
                        default:
                            {
                                Debug.Log("no Name found");
                                break;
                            }
                    }
                    
                }
                else
                {
                    SetText("not enough space");
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentTower.gameObject);
                hasPlaced = true;
            }
        }
        if (Time.time >= textDeleteTime)
        {
            text.text = "";
        }
        
    }

    private void SetText(string displayedText)
    {
        text.text = displayedText;
        textDeleteTime = Time.time + textDisplayTime;
    }

    private void TowerPlaced()
    {
        TowerController towerController = currentTower.GetComponent<TowerController>();
        towerController.SetActiv();
        hasPlaced = true;
    }

    bool IsLegalPosition()
    {
        if (PlacableTower.TowerCCount == 0 && PlacableTower.EnvironmentCCount == 3)
        {
            return true;
        }
        return false;
    }
    public void SetItem(GameObject T)
    {
        {
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(T)).transform;
        }
        
    }
}
