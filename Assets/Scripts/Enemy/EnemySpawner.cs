using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Airship;
    [SerializeField] GameObject Biplane;
    [SerializeField] GameObject Bomber;
    [SerializeField] GameObject Dreadnought;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnRotation = Quaternion.identity;
    [SerializeField] byte spawnlevels;
    [SerializeField] byte unobstructedlevels;
    [SerializeField] float levelheight;
    [SerializeField] int gameleveltime;

    GameObject[] enemies = new GameObject[4];
    int gamelevel = 0;
    System.DateTime starttime;
    System.Random rnd = new System.Random();

    void Start()
    {
        if (spawnlevels <= 0)
        {
            print("No spawn-level? Thats sooo sad...");
        }
        if (unobstructedlevels <= 0)
        {
            print("No unobstructed spawnlevel? Dreadnought is very, very angry!");
        }
        if (unobstructedlevels >= spawnlevels)
        {
            print("meh, this map is pretty unobstructed...");
        }

        enemies[0] = Airship;
        enemies[1] = Biplane;
        enemies[2] = Bomber;
        enemies[3] = Dreadnought;

        starttime = System.DateTime.UtcNow;
    }


    void Update()
    {
        if (System.DateTime.UtcNow.Subtract(starttime) >= new System.TimeSpan(0, 0, gameleveltime))
        {
            Vector3 specificPosition = spawnPosition;
            specificPosition.y += rnd.Next(0, spawnlevels) * levelheight;

            Instantiate(enemies[rnd.Next(0, enemies.Length)], specificPosition, spawnRotation);

            ++gamelevel;
            starttime = System.DateTime.UtcNow;
        }
    }
}
