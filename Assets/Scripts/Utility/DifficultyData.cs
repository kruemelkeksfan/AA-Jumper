using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyData : MonoBehaviour
{
    public static float waveSizeMultiplicator = 1;
    public static float difficultyMultiplicator = 3;
    public static int factoryStartHealth = 750;
    public static int scrapStartAmmount = 60;
    public static int scrapAutoAmmount = 2;
    public static int scrapAutoTime = 5;
    public static int respawnTime = 4;

    public static bool ammunitionActiv = true;
    public static bool wreckCollecterTowerActive = true;
    public static bool wreckAutoCollectActiv = false;
    public static bool controlsWhileFlyingActive = false;

    [Header("General")]
    public static int wreckValue = 15;

    [Header("Easy")]
    public float waveSizeMultiplicatorE;
    public float difficultyMultiplicatorE;
    public int factoryStartHealthE;
    public int scrapStartAmmountE;
    public int scrapAutoAmmountE;
    public int scrapAutoTimeE;
    public int respawnTimeE;
    public bool ammunitionActivE;
    public bool wreckCollecterTowerActiveE;
    public bool wreckAutoCollectActivE;
    public bool controlsWhileFlyingActiveE;

    [Header("Normal")]
    public float waveSizeMultiplicatorN;
    public float difficultyMultiplicatorN;
    public int factoryStartHealthN;
    public int scrapStartAmmountN;
    public int scrapAutoAmmountN;
    public int scrapAutoTimeN;
    public int respawnTimeN;
    public bool ammunitionActivN;
    public bool wreckCollecterTowerActiveN;
    public bool wreckAutoCollectActivN;
    public bool controlsWhileFlyingActiveN;

    [Header("Hard")]
    public float waveSizeMultiplicatorH;
    public float difficultyMultiplicatorH;
    public int factoryStartHealthH;
    public int scrapStartAmmountH;
    public int scrapAutoAmmountH;
    public int scrapAutoTimeH;
    public int respawnTimeH;
    public bool ammunitionActivH;
    public bool wreckCollecterTowerActiveH;
    public bool wreckAutoCollectActivH;
    public bool controlsWhileFlyingActiveH;

    [Header("Dreadnought")]
    public float waveSizeMultiplicatorD;
    public float difficultyMultiplicatorD;
    public int factoryStartHealthD;
    public int scrapStartAmmountD;
    public int scrapAutoAmmountD;
    public int scrapAutoTimeD;
    public int respawnTimeD;
    public bool ammunitionActivD;
    public bool wreckCollecterTowerActiveD;
    public bool wreckAutoCollectActivD;
    public bool controlsWhileFlyingActiveD;
}
