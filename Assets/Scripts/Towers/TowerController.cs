using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        List<GameObject> enemies = EnemySpawner.enemies;
        GameObject target;
        for(int I = 0; I < enemies.Count; ++I)
        {
            if(enemies[I].transform.position.y > gameObject.transform.position.y && enemies[I].transform.position.x > gameObject.transform.position.x)
            {
                target = enemies[I];
                break;
            }
        }
    }
}
