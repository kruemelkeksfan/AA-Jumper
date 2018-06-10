using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimeSet : MonoBehaviour
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
        textEasy.text = difficultyData.respawnTimeE + " Sec";
        textNormal.text = difficultyData.respawnTimeN + " Sec";
        textHard.text = difficultyData.respawnTimeH + " Sec";
        textDreadnought.text = difficultyData.respawnTimeD + " Sec";
    }

    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.respawnTime = difficultyData.respawnTimeE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.respawnTime = difficultyData.respawnTimeN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.respawnTime = difficultyData.respawnTimeH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.respawnTime = difficultyData.respawnTimeD;
        }
    }
}

