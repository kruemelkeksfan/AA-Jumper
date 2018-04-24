using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] GameObject guns;

    private float oldrot = 0;

    public int range;

    void Start()
    {

    }

    void Update()
    {
        List<GameObject> enemies = EnemySpawner.enemies;
        for (int I = 0; I < enemies.Count; ++I)
        {
            if (enemies[I].transform.position.y > gameObject.transform.position.y && enemies[I].transform.position.x > gameObject.transform.position.x)
            {
                float height = enemies[I].transform.position.y - gameObject.transform.position.y;
                float horizontaldistance = enemies[I].transform.position.x - gameObject.transform.position.x;

                if (Mathf.Sqrt(height*height+horizontaldistance*horizontaldistance) < range)
                {
                    GameObject target = enemies[I];

                    if(oldrot != 0)
                    {
                        guns.transform.Rotate(new Vector3(0, 0, -oldrot));
                    }

                    float alpha = height / horizontaldistance;
                    print(alpha + "=" + height + "/" + horizontaldistance);
                    guns.transform.Rotate(new Vector3(0, 0, alpha));
                    oldrot = alpha;

                    break;
                }
            }
        }
    }
}
