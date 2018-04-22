using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Transform currentTower;
    [SerializeField] GameObject Player;
    float playerHight;
    float towerLaneDepth = -1.5f;

    void Update()
    {
        
        
        if (currentTower != null)
        {
            playerHight = Player.transform.position.y;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 63.5f;
            Vector3 mouseRPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
            currentTower.position = new Vector3(mouseRPosition.x, playerHight, towerLaneDepth);
        }
    }
    public void SetItem(GameObject T)
    {
        currentTower = ((GameObject)Instantiate(T)).transform;
    }
}
