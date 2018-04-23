using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> hitting = new List<Collider>();
    public int Count;

    private void Update()
    {

        print(hitting.Count);
    }

    void OnTriggerEnter (Collider c)
    {
        print("a");
        if (c.tag == "Tower")
        {
            print("b");
            hitting.Add(c);
            Count = hitting.Count;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tower")
        {
            hitting.Remove(c);
            Count = hitting.Count;
        }
    }
}

