using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{ 
    [SerializeField] float bombDropLocation = 4.0f;
    [SerializeField] float rearmPoint = 60.0f;
    [SerializeField] GameObject Bomb;

    bool bombDropped;

    void Update ()
    {
        if (bombDropped == true && gameObject.transform.position.x >= rearmPoint)
        {
            bombDropped = false;
        }
        else if (bombDropped == false && gameObject.transform.position.x <= bombDropLocation)
        {
            bombDropped = true;
            Instantiate (Bomb, gameObject.transform.position, Quaternion.identity);
        }
    }
}
