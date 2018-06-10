using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingScrapSet : MonoBehaviour
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
        textEasy.text = difficultyData.scrapStartAmmountE.ToString();
        textNormal.text = difficultyData.scrapStartAmmountN.ToString();
        textHard.text = difficultyData.scrapStartAmmountH.ToString();
        textDreadnought.text = difficultyData.scrapStartAmmountD.ToString();
    }
    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.scrapStartAmmount = difficultyData.scrapStartAmmountD;
        }
    }
}
