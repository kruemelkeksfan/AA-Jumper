using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDisplayHandler : MonoBehaviour
{
    private void Update()
    {
        if (TowerPlacement.hasPlaced)
        {
            Destroy(gameObject);
        }
    }
    
}
