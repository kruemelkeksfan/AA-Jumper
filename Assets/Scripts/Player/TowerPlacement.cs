using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    int CCount;
    [SerializeField] GameObject Player;

    float playerHight;
    float towerLaneDepth = -1.5f;
    float cameraDistance = 63.5f;
    bool hasPlaced;
    Transform currentTower;
    PlacableTower placableTower;

    void Update()
    {
        CCount = placableTower.Count;
        print(CCount);

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
                    print("Legal");
                    hasPlaced = true;
                }
            }
        }
    }
    bool IsLegalPosition()
    {
        print(CCount);
        if (CCount > 0)
        {
            print("false");
            return false;
        }
        print("true");
        return true;
    }

    public void SetItem(GameObject T)
    {
        hasPlaced = false;
        currentTower = ((GameObject)Instantiate(T)).transform;
        placableTower = T.GetComponent<PlacableTower>();
        
    }
}
