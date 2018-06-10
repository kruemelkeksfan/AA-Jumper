using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryHealthSet : MonoBehaviour
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
        textEasy.text = difficultyData.factoryStartHealthE.ToString();
        textNormal.text = difficultyData.factoryStartHealthN.ToString();
        textHard.text = difficultyData.factoryStartHealthH.ToString();
        textDreadnought.text = difficultyData.factoryStartHealthD.ToString();
    }
    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.factoryStartHealth = difficultyData.factoryStartHealthD;
        }
    }
}

