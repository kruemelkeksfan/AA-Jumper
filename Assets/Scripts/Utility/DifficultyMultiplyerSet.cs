using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMultiplyerSet : MonoBehaviour {

    [HideInInspector] public float multiplierMin;
    [HideInInspector] public float multiplierMax;

    [SerializeField] GameObject difficultyDataHolder;

    [Header("bools")]
    [SerializeField] float ammunitionActivOnMulti;
    [SerializeField] float wreckCollecterTowerActiveOnMulti;
    [SerializeField] float wreckAutoCollectActivOnMulti;
    [SerializeField] float controlsWhileFlyingActiveOnMulti;
    [SerializeField] float ammunitionActivOffMulti;
    [SerializeField] float wreckCollecterTowerActiveOffMulti;
    [SerializeField] float wreckAutoCollectActivOffMulti;
    [SerializeField] float controlsWhileFlyingActiveOffMulti;

    [Header("Easy")]
    [SerializeField] float waveSizeMultiplicatorEMulti;
    [SerializeField] float factoryStartHealthEMulti;
    [SerializeField] float scrapStartAmmountEMulti;
    [SerializeField] float scrapAutoEMulti;
    [SerializeField] float respawnTimeEMulti;

    [Header("Normal")]
    [SerializeField] float waveSizeMultiplicatorNMulti;
    [SerializeField] float factoryStartHealthNMulti;
    [SerializeField] float scrapStartAmmountNMulti;
    [SerializeField] float scrapAutoNMulti;
    [SerializeField] float respawnTimeNMulti;

    [Header("Hard")]
    [SerializeField] float waveSizeMultiplicatorHMulti;
    [SerializeField] float factoryStartHealthHMulti;
    [SerializeField] float scrapStartAmmountHMulti;
    [SerializeField] float scrapAutoHMulti;
    [SerializeField] float respawnTimeHMulti;

    [Header("Dreadnought")]
    [SerializeField] float waveSizeMultiplicatorDMulti;
    [SerializeField] float factoryStartHealthDMulti;
    [SerializeField] float scrapStartAmmountDMulti;
    [SerializeField] float scrapAutoDMulti;
    [SerializeField] float respawnTimeDMulti;

    float waveSizeMultiplicatorMulti;
    float factoryStartHealthMulti;
    float scrapStartAmmountMulti;
    float scrapAutoMulti;
    float respawnTimeMulti;

    float ammunitionActivMulti;
    float wreckCollecterTowerActiveMulti;
    float wreckAutoCollectActivMulti;
    float controlsWhileFlyingActiveMulti;

    DifficultyData difficultyData;

    private void Start()
    {
        difficultyData = difficultyDataHolder.GetComponent<DifficultyData>();
        InvokeRepeating("UpdateMultiplicator", 1, 0.5f);
        multiplierMax = waveSizeMultiplicatorDMulti + factoryStartHealthDMulti + scrapStartAmmountDMulti + scrapAutoDMulti + respawnTimeDMulti + ammunitionActivOnMulti + wreckAutoCollectActivOffMulti + wreckCollecterTowerActiveOffMulti + controlsWhileFlyingActiveOffMulti;
        multiplierMin = waveSizeMultiplicatorEMulti + factoryStartHealthEMulti + scrapStartAmmountEMulti + scrapAutoEMulti + respawnTimeEMulti + ammunitionActivOffMulti + wreckAutoCollectActivOnMulti + wreckCollecterTowerActiveOnMulti + controlsWhileFlyingActiveOnMulti;
}

    void UpdateMultiplicator()
    {
        WaveSizeMulti();
        FactoryHealthMulti();
        ScrapStartAmmountMulti();
        ScrapAutoMulti();
        RespawnTimeMulti();
        BoolMulti();
        DifficultyData.difficultyMultiplicator = waveSizeMultiplicatorMulti + factoryStartHealthMulti + scrapStartAmmountMulti + scrapAutoMulti + respawnTimeMulti + ammunitionActivMulti + wreckCollecterTowerActiveMulti + wreckAutoCollectActivMulti + controlsWhileFlyingActiveMulti;
    }
    private void WaveSizeMulti()
    {
        if (DifficultyData.waveSizeMultiplicator == difficultyData.waveSizeMultiplicatorE)
        {
            waveSizeMultiplicatorMulti = waveSizeMultiplicatorEMulti;
        }
        else if (DifficultyData.waveSizeMultiplicator == difficultyData.waveSizeMultiplicatorN)
        {
            waveSizeMultiplicatorMulti = waveSizeMultiplicatorNMulti;
        }
        else if (DifficultyData.waveSizeMultiplicator == difficultyData.waveSizeMultiplicatorH)
        {
            waveSizeMultiplicatorMulti = waveSizeMultiplicatorHMulti;
        }
        else if (DifficultyData.waveSizeMultiplicator == difficultyData.waveSizeMultiplicatorD)
        {
            waveSizeMultiplicatorMulti = waveSizeMultiplicatorDMulti;
        }
    }
    private void FactoryHealthMulti()
    {
        if (DifficultyData.factoryStartHealth == difficultyData.factoryStartHealthE)
        {
            factoryStartHealthMulti = factoryStartHealthEMulti;
        }
        else if (DifficultyData.factoryStartHealth == difficultyData.factoryStartHealthN)
        {
            factoryStartHealthMulti = factoryStartHealthNMulti;
        }
        else if (DifficultyData.factoryStartHealth == difficultyData.factoryStartHealthH)
        {
            factoryStartHealthMulti = factoryStartHealthHMulti;
        }
        else if (DifficultyData.factoryStartHealth == difficultyData.factoryStartHealthD)
        {
            factoryStartHealthMulti = factoryStartHealthDMulti;
        }
    }
    private void ScrapStartAmmountMulti()
    {
        if (DifficultyData.scrapStartAmmount == difficultyData.scrapStartAmmountE)
        {
            scrapStartAmmountMulti = scrapStartAmmountEMulti;
        }
        else if (DifficultyData.scrapStartAmmount == difficultyData.scrapStartAmmountN)
        {
            scrapStartAmmountMulti = scrapStartAmmountNMulti;
        }
        else if (DifficultyData.scrapStartAmmount == difficultyData.scrapStartAmmountH)
        {
            scrapStartAmmountMulti = scrapStartAmmountHMulti;
        }
        else if (DifficultyData.scrapStartAmmount == difficultyData.scrapStartAmmountD)
        {
            scrapStartAmmountMulti = scrapStartAmmountDMulti;
        }
    }
    private void ScrapAutoMulti()
    {
        if (DifficultyData.scrapAutoAmmount == difficultyData.scrapAutoAmmountE && DifficultyData.scrapAutoTime == difficultyData.scrapAutoTimeE)
        {
            scrapAutoMulti = scrapAutoEMulti;
        }
        else if (DifficultyData.scrapAutoAmmount == difficultyData.scrapAutoAmmountN && DifficultyData.scrapAutoTime == difficultyData.scrapAutoTimeN)
        {
            scrapAutoMulti = scrapAutoNMulti;
        }
        else if (DifficultyData.scrapAutoAmmount == difficultyData.scrapAutoAmmountH && DifficultyData.scrapAutoTime == difficultyData.scrapAutoTimeH)
        {
            scrapAutoMulti = scrapAutoHMulti;
        }
        else if (DifficultyData.scrapAutoAmmount == difficultyData.scrapAutoAmmountD && DifficultyData.scrapAutoTime == difficultyData.scrapAutoTimeD)
        {
            scrapAutoMulti = scrapAutoDMulti;
        }
    }
    private void RespawnTimeMulti()
    {
        if (DifficultyData.respawnTime == difficultyData.respawnTimeE)
        {
            respawnTimeMulti = respawnTimeEMulti;
        }
        else if (DifficultyData.respawnTime == difficultyData.respawnTimeN)
        {
            respawnTimeMulti = respawnTimeNMulti;
        }
        else if (DifficultyData.respawnTime == difficultyData.respawnTimeH)
        {
            respawnTimeMulti = respawnTimeHMulti;
        }
        else if (DifficultyData.respawnTime == difficultyData.respawnTimeD)
        {
            respawnTimeMulti = respawnTimeDMulti;
        }
    }
    private void BoolMulti()
    {
        if (DifficultyData.ammunitionActiv)
        {
            ammunitionActivMulti = ammunitionActivOnMulti;
        }
        else if (!DifficultyData.ammunitionActiv)
        {
            ammunitionActivMulti = ammunitionActivOffMulti;
        }
        if (DifficultyData.wreckCollecterTowerActive)
        {
            wreckCollecterTowerActiveMulti = wreckCollecterTowerActiveOnMulti;
        }
        else if (!DifficultyData.wreckCollecterTowerActive)
        {
            wreckCollecterTowerActiveMulti = wreckCollecterTowerActiveOffMulti;
        }
        if (DifficultyData.wreckAutoCollectActiv)
        {
            wreckAutoCollectActivMulti = wreckAutoCollectActivOnMulti;
        }
        else if (!DifficultyData.wreckAutoCollectActiv)
        {
            wreckAutoCollectActivMulti = wreckAutoCollectActivOffMulti;
        }
        if (DifficultyData.controlsWhileFlyingActive)
        {
            controlsWhileFlyingActiveMulti = controlsWhileFlyingActiveOnMulti;
        }
        else if (!DifficultyData.controlsWhileFlyingActive)
        {
            controlsWhileFlyingActiveMulti = controlsWhileFlyingActiveOffMulti;
        }
    }
}
