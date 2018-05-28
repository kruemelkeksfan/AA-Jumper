using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySet : MonoBehaviour {

    public bool easy;
    public static bool normal;
    public static bool hard;
    public static bool dreadnought;

    [SerializeField] Toggle easyT;
    [SerializeField] Toggle normalT;
    [SerializeField] Toggle hardT;
    [SerializeField] Toggle dreadnoughtT;


    void Start ()
    {
        easy = false;
        normal = true;
        hard = false;
        dreadnought = false;
       
    }
    private void Update()
    {
        if (easyT.isOn)
        {
            easy = true;
            normal = false;
            hard = false;
            dreadnought = false;
        }
        else if (normalT.isOn)
        {
            easy = false;
            normal = true;
            hard = false;
            dreadnought = false;
        }
        else if (hardT.isOn)
        {
            easy = false;
            normal = false;
            hard = true;
            dreadnought = false;
        }
        else if (dreadnoughtT.isOn)
        {
            easy = false;
            normal = false;
            hard = false;
            dreadnought = true;
        }
    }
}
