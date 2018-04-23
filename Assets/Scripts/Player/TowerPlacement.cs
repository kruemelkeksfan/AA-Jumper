using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] GameObject Player;

    float playerHight;
    float towerLaneDepth = -1.5f;
    float cameraDistance = 63.5f;
    bool hasPlaced;
    Transform currentTower;

    void Update()
    {
        if (currentTower != null && !hasPlaced)
        {
            playerHight = Player.transform.position.y;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = cameraDistance;
            Vector3 mouseRPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentTower.position = new Vector3(mouseRPosition.x, playerHight, towerLaneDepth);

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
