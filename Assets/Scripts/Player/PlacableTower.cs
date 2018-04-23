using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableTower : MonoBehaviour
{
    //[HideInInspector]
    public List<Collider> hittingTower = new List<Collider>();
    public List <Collider> hittingEnvironment = new List<Collider>();
    public static int TowerCCount;
    public static int EnvironmentCCount;

    void OnTriggerEnter (Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Add(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Add(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Remove(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Remove(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
}

