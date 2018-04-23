using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[4];
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnRotation = Quaternion.identity;
    [SerializeField] byte spawnlevels;
    [SerializeField] byte unobstructedlevels;
    [SerializeField] float levelheight;
    [SerializeField] int gameleveltime;

    public const int AIRSHIP = 0;
    public const int BIPLANE = 1;
    public const int BOMBER = 2;
    public const int DREADNOUGHT = 3;

    private Lane[] lanes;
    private List<int>[] typequeue;
    private int gamelevel = 0;
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
        if (System.DateTime.Now.Subtract(starttime) >= new System.TimeSpan(0, 0, gameleveltime))
        {
            int enemyType = rnd.Next(AIRSHIP, enemies.Length);
            int spawnlane = (enemyType < 3) ? rnd.Next(0, spawnlevels) : rnd.Next(spawnlevels - unobstructedlevels, spawnlevels);

            typequeue[spawnlane].Add(enemyType);

            for (int I = 0; I < lanes.Length; ++I)
            {
                if (lanes[I].isFree() && typequeue[I].Count > 0)
                {
                    Vector3 specificPosition = spawnPosition;
                    specificPosition.y += I * levelheight;
                    switch((typequeue[I])[0])
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

                    Instantiate(enemies[(typequeue[I])[0]], specificPosition, spawnRotation);
                    lanes[I].reserveLane((typequeue[I])[0]);
                    typequeue[I].RemoveAt(0);
                }
            }
            ++gamelevel;
            starttime = System.DateTime.Now;
        }
    }
}
