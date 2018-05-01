using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane
{
    private System.DateTime reserveduntil;

    public Lane()
    {
        reserveduntil = System.DateTime.Now;
    }

    public void reserveLane(int type)
    {
        System.TimeSpan reserve;
        switch (type)
        {
            case EnemySpawner.AIRSHIP:
                {
                    reserve = new System.TimeSpan(0, 0, 5);
                    break;
                }
            case EnemySpawner.BIPLANE:
                {
                    reserve = new System.TimeSpan(0, 0, 3);
                    break;
                }
            case EnemySpawner.BOMBER:
                {
                    reserve = new System.TimeSpan(0, 0, 10);
                    break;
                }
            case EnemySpawner.DREADNOUGHT:
                {
                    reserve = new System.TimeSpan(0, 0, 25);
                    break;
                }
            default:
                {
                    reserve = new System.TimeSpan(0, 0, 0);
                    break;
                }
        }
        reserveduntil = System.DateTime.Now.Add(reserve);
    }

    public bool isFree()
    {
        return System.DateTime.Now.Subtract(reserveduntil).TotalSeconds > 0;
    }
}
