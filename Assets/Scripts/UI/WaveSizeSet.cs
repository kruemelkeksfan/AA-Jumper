using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSizeSet : MonoBehaviour
{
    [SerializeField] Toggle easyT;
    [SerializeField] Toggle normalT;
    [SerializeField] Toggle hardT;
    [SerializeField] Toggle dreadnoughtT;
    [SerializeField] GameObject difficultyDataHolder;

    DifficultyData difficultyData;

    void Start()
    {
        difficultyData = difficultyDataHolder.GetComponent<DifficultyData>();
	}
    private void Update()
    {
        if (easyT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorE;
        }
        else if (normalT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorN;
        }
        else if (hardT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorH;
        }
        else if (dreadnoughtT.isOn)
        {
            DifficultyData.waveSizeMultiplicator = difficultyData.waveSizeMultiplicatorD;
        }
    }
}
