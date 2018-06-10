using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrapSet : MonoBehaviour
{
    [SerializeField] Toggle easyT;
    [SerializeField] Toggle normalT;
    [SerializeField] Toggle hardT;
    [SerializeField] Toggle dreadnoughtT;
    [SerializeField] GameObject difficultyDataHolder;
    [Header("ToggelLabel")]
    [SerializeField] Text textEasy;
    [SerializeField] Text textNormal;
    [SerializeField] Text textHard;
    [SerializeField] Text textDreadnought;

    DifficultyData difficultyData;

    void Start()
    {
        difficultyData = difficultyDataHolder.GetComponent<DifficultyData>();
        textEasy.text = difficultyData.scrapAutoAmmountE + " Scrap per " + difficultyData.scrapAutoTimeE + " Sec";
        textNormal.text = difficultyData.scrapAutoAmmountN + " Scrap per " + difficultyData.scrapAutoTimeN + " Sec";
        textHard.text = difficultyData.scrapAutoAmmountH + " Scrap per " + difficultyData.scrapAutoTimeH + " Sec";
        textDreadnought.text = difficultyData.scrapAutoAmmountD + " Scrap per " + difficultyData.scrapAutoTimeD + " Sec";
    }
    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountE;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountN;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountH;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.scrapAutoAmmount = difficultyData.scrapAutoAmmountD;
            DifficultyData.scrapAutoTime = difficultyData.scrapAutoTimeD;
        }
    }
}