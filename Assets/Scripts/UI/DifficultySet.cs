using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySet : MonoBehaviour {

    public static bool easy;
    public static bool normal;
    public static bool hard;
    public static bool dreadnought;

    [SerializeField] Toggle easyT;
    [SerializeField] Toggle normalT;
    [SerializeField] Toggle hardT;
    [SerializeField] Toggle dreadnoughtT;
    [SerializeField] GameObject difficultyDataHolder;

    DifficultyData difficultyData;

    void Start ()
    {
        difficultyData = difficultyDataHolder.GetComponent<DifficultyData>();
        DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorN;
        DifficultyData.difficultyMultiplicator = difficultyData.difficultyMultiplicatorN;
        DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthN;
        DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountN;
        DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountN;
        DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeN;
        DifficultyData.respawnTime = difficultyData.respawnTimeN;
        DifficultyData.ammunitionActiv = difficultyData.ammunitionActivN;
        DifficultyData.wreckCollecterTowerActive = difficultyData.wreckCollecterTowerActiveN;
        DifficultyData.wreckAutoCollectActiv = difficultyData.wreckAutoCollectActivN;
        DifficultyData.controlsWhileFlyingActive = difficultyData.controlsWhileFlyingActiveN;
    }
    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorE;
            DifficultyData.difficultyMultiplicator = difficultyData.difficultyMultiplicatorE;
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthE;
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountE;
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountE;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeE;
            DifficultyData.respawnTime = difficultyData.respawnTimeE;
            DifficultyData.ammunitionActiv = difficultyData.ammunitionActivE;
            DifficultyData.wreckCollecterTowerActive = difficultyData.wreckCollecterTowerActiveE;
            DifficultyData.wreckAutoCollectActiv = difficultyData.wreckAutoCollectActivE;
            DifficultyData.controlsWhileFlyingActive = difficultyData.controlsWhileFlyingActiveE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorN;
            DifficultyData.difficultyMultiplicator = difficultyData.difficultyMultiplicatorN;
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthN;
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountN;
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountN;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeN;
            DifficultyData.respawnTime = difficultyData.respawnTimeN;
            DifficultyData.ammunitionActiv = difficultyData.ammunitionActivN;
            DifficultyData.wreckCollecterTowerActive = difficultyData.wreckCollecterTowerActiveN;
            DifficultyData.wreckAutoCollectActiv = difficultyData.wreckAutoCollectActivN;
            DifficultyData.controlsWhileFlyingActive = difficultyData.controlsWhileFlyingActiveN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorH;
            DifficultyData.difficultyMultiplicator = difficultyData.difficultyMultiplicatorH;
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthH;
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountH;
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountH;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeH;
            DifficultyData.respawnTime = difficultyData.respawnTimeH;
            DifficultyData.ammunitionActiv = difficultyData.ammunitionActivH;
            DifficultyData.wreckCollecterTowerActive = difficultyData.wreckCollecterTowerActiveH;
            DifficultyData.wreckAutoCollectActiv = difficultyData.wreckAutoCollectActivH;
            DifficultyData.controlsWhileFlyingActive = difficultyData.controlsWhileFlyingActiveH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorD;
            DifficultyData.difficultyMultiplicator = difficultyData.difficultyMultiplicatorD;
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthD;
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountD;
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountD;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeD;
            DifficultyData.respawnTime = difficultyData.respawnTimeD;
            DifficultyData.ammunitionActiv = difficultyData.ammunitionActivD;
            DifficultyData.wreckCollecterTowerActive = difficultyData.wreckCollecterTowerActiveD;
            DifficultyData.wreckAutoCollectActiv = difficultyData.wreckAutoCollectActivD;
            DifficultyData.controlsWhileFlyingActive = difficultyData.controlsWhileFlyingActiveD;
        }
    }
}
