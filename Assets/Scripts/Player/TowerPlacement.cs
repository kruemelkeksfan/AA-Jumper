using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] GameObject Player;

    float towerLaneDepth = -1.5f;
    float cameraZPosition = 63.5f;
    float halfPlatformRange = 1.75f;

    float playerXPosition;
    float buildArea;
    bool hasPlaced;
    Transform currentTower;

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
    void LateUpdate()
    {
        if (currentTower != null && !hasPlaced)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    hasPlaced = true;
                }
            }
        }
        
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
        hasPlaced = false;
        currentTower = ((GameObject)Instantiate(T)).transform;
    }
}
