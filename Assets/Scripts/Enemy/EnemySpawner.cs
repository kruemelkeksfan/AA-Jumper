using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static float spawnXPosition;
    public static int gameLevel;
    public static float difficulty;

    public static List<GameObject> enemies;

    public const int AIRSHIP = 0;
    public const int BIPLANE = 1;
    public const int BOMBER = 2;
    public const int DREADNOUGHT = 3;

    [SerializeField] GameObject[] enemyTypes = new GameObject[4];
    [SerializeField] Vector3 spawnPosition;
    [Header("Spawn parameters")]
    [SerializeField] byte spawnLevels;
    [SerializeField] byte unobstructedLevels;
    [SerializeField] float levelHeight;
    [SerializeField] float spawnIntervall;
    [SerializeField] int biplaneMinLevel;
    [SerializeField] int bomberMinLevel;
    [SerializeField] int dreadnoughtMinLevel;
    [SerializeField] [Tooltip("every x level")] int dreadnoughtSpawnIntervall;
    [SerializeField] [Tooltip("every x level")] int bomberSpawnIntervall;
    [Header("Game level parameters")]
    [SerializeField] int startTime;
    [SerializeField] int difficultyPerLevel;
    [SerializeField] int minGameLevelTime;
    [SerializeField] float enemyCountTimeMultiplier;
    [Header("Difficulty Multiplier")]
    [SerializeField] float easyMultiplier;
    [SerializeField] float normalMultiplier;
    [SerializeField] float hardMultiplier;
    [SerializeField] float dreadnoughtMultiplier;

    System.Random rnd = new System.Random();

    bool gameStart = true;
    float nextUpdateTime;
    int availableEnemyTypes;

    Lane[] lanes;
    List<int>[] typequeue;

    void Start()
    {
        spawnXPosition = spawnPosition.x;
        gameLevel = 0;
        SetMultiplier();

        enemies = new List<GameObject>();

        lanes = new Lane[spawnLevels];
        typequeue = new List<int>[spawnLevels];
        for (int I = 0; I < lanes.Length; ++I)
        {
            lanes[I] = new Lane();
            typequeue[I] = new List<int>();
        }
        InvokeRepeating("UpdateLevel", startTime - 1, 1);
        InvokeRepeating("SpawnEnemy", startTime, spawnIntervall);
    }

    void Update()
    {
        /*Debug.Log("Lane 0: " + typequeue[0].Count);
        Debug.Log("Lane 1: " + typequeue[1].Count);
        Debug.Log("Lane 2: " + typequeue[2].Count);
        Debug.Log("Lane 3: " + typequeue[3].Count);
        Debug.Log("Lane 4: " + typequeue[4].Count);
        Debug.Log("Lane 5: " + typequeue[5].Count);*/
    }
    private void SetMultiplier()
    {
        if (DifficultySet.easy)
        {
            difficulty = easyMultiplier;
        }
        else if (DifficultySet.normal)
        {
            difficulty = normalMultiplier;
        }
        else if (DifficultySet.hard)
        {
            difficulty = hardMultiplier;
        }
        else if (DifficultySet.dreadnought)
        {
            difficulty = dreadnoughtMultiplier;
        }
        else
        {
            Debug.Log("No difficulty level found");
            DifficultySet.normal = true;
            difficulty = normalMultiplier;
        }
    }
    void UpdateLevel()
    {
        if (gameStart)
        {
            gameStart = false;
            Invoke("NextLevel", 0.5f);
        }
        else if (nextUpdateTime < Time.time)
        {
            int enemyCount = 0;
            for (int I = 0; I < lanes.Length; ++I)
            {
                enemyCount += typequeue[I].Count;
            }
            float nextLevelTime = enemyCount * enemyCountTimeMultiplier;
            if (nextLevelTime < minGameLevelTime)
            {
                nextLevelTime = minGameLevelTime;
            }
            //Debug.Log(nextLevelTime);
            nextUpdateTime = nextLevelTime + Time.time + 1;
            Invoke("NextLevel", nextLevelTime);
        }    
    }
    private void NextLevel()
    {
        ++gameLevel;
        int spawnlevel = (gameLevel / 3) + 1;
        int wealth = Mathf.RoundToInt(difficulty * (gameLevel * difficultyPerLevel));
        GetAvailableEnemyTypes();
        //Debug.Log("types :" + availableEnemyTypes);
        while (wealth > 0)
        {
            int enemyType = rnd.Next(0, availableEnemyTypes);
            int spawnlane = (enemyType < 3) ? rnd.Next(0, Mathf.Min(spawnLevels, spawnlevel)) : rnd.Next(spawnLevels - unobstructedLevels, spawnLevels);

            if (cost(enemyType) <= wealth)
            {
                typequeue[spawnlane].Add(enemyType);
                wealth -= cost(enemyType);
            }
        }
    }
    private void SpawnEnemy()
    {
        for (int I = 0; I < lanes.Length; ++I)
        {
            if (lanes[I].isFree() && typequeue[I].Count > 0)
            {
                Vector3 specificPosition = spawnPosition;
                specificPosition.y += ((I * levelHeight) + ((levelHeight / 2) - 0.8f));
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
                enemies.Add(Instantiate(enemyTypes[(typequeue[I])[0]], specificPosition, Quaternion.identity));
                lanes[I].reserveLane((typequeue[I])[0]);
                typequeue[I].RemoveAt(0);
            }
        }
    }



    private void GetAvailableEnemyTypes()
    {
        if (gameLevel % dreadnoughtSpawnIntervall == 0 && gameLevel > dreadnoughtMinLevel)
        {
            availableEnemyTypes = enemyTypes.Length;
        }
        else if (gameLevel % bomberSpawnIntervall == 0 && gameLevel > bomberMinLevel)
        {
            availableEnemyTypes = enemyTypes.Length - 1;
        }
        else if (gameLevel > biplaneMinLevel)
        {
            availableEnemyTypes = enemyTypes.Length - 2;
        }
        else
        {
            availableEnemyTypes = enemyTypes.Length - 3;
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
                    return 4;
                }
            case EnemySpawner.BOMBER:
                {
                    return 10;
                }
            default:
                {
                    return 18;
                }
        }
    }
}
