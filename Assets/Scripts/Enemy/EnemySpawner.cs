using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyTypes = new GameObject[4];
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnRotation = Quaternion.identity;
    [SerializeField] byte spawnlevels;
    [SerializeField] byte unobstructedlevels;
    [SerializeField] float levelheight;
    [SerializeField] int difficulty;
    [SerializeField] int difficultyperlevel;
    [SerializeField] int gameleveltime;
    [SerializeField] Text text;

    public const int AIRSHIP = 0;
    public const int BIPLANE = 1;
    public const int BOMBER = 2;
    public const int DREADNOUGHT = 3;

    public static List<GameObject> enemies;

    private Lane[] lanes;
    private List<int>[] typequeue;
    int gameLevel = 0;
    private System.DateTime starttime;
    private System.Random rnd = new System.Random();

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

        enemies = new List<GameObject>();

        lanes = new Lane[spawnlevels];
        typequeue = new List<int>[spawnlevels];
        for (int I = 0; I < lanes.Length; ++I)
        {
            lanes[I] = new Lane();
            typequeue[I] = new List<int>();
        }
        starttime = System.DateTime.Now;
    }


    void Update()
    {
        text.text = "Level: " + gameLevel;
        if (System.DateTime.Now.Subtract(starttime) >= new System.TimeSpan(0, 0, gameleveltime))
        {
            ++gameLevel;

            int wealth = difficulty + gameLevel * difficultyperlevel;
            while (wealth > 0)
            {
                int enemyType = rnd.Next(AIRSHIP, gameLevel % enemyTypes.Length);
                int spawnlane = (enemyType < 3) ? rnd.Next(0, Mathf.Min(spawnlevels, gameLevel)) : rnd.Next(spawnlevels - unobstructedlevels, spawnlevels);

                if (cost(enemyType) <= wealth)
                {
                    typequeue[spawnlane].Add(enemyType);
                    wealth -= cost(enemyType);
                }
            }

            for (int I = 0; I < lanes.Length; ++I)
            {
                if (lanes[I].isFree() && typequeue[I].Count > 0)
                {
                    Vector3 specificPosition = spawnPosition;
                    specificPosition.y += ((I * levelheight) + levelheight / 2);
                    switch ((typequeue[I])[0])
                    {
                        case EnemySpawner.AIRSHIP:
                            {
                                specificPosition.z += 8;
                                break;
                            }
                        case EnemySpawner.BIPLANE:
                            {
                                specificPosition.z += 4;
                                break;
                            }
                        case EnemySpawner.BOMBER:
                            {
                                specificPosition.z += 2;
                                break;
                            }
                        default:
                            {
                                specificPosition.z += 0;
                                break;
                            }
                    }

                    enemies.Add(Instantiate(enemyTypes[(typequeue[I])[0]], specificPosition, spawnRotation));
                    lanes[I].reserveLane((typequeue[I])[0]);
                    typequeue[I].RemoveAt(0);
                }
            }
            starttime = System.DateTime.Now;
        }
    }

    private int cost(int type)
    {
        switch (type)
        {
            case EnemySpawner.AIRSHIP:
                {
                    return 1;
                }
            case EnemySpawner.BIPLANE:
                {
                    return 2;
                }
            case EnemySpawner.BOMBER:
                {
                    return 4;
                }
            default:
                {
                    return 8;
                }
        }
    }

}
