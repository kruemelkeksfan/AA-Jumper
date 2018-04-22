using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{ 

    [SerializeField] float bombDropLocation = 4f;
    [SerializeField] GameObject Bomb;

    bool bombeDropped = false;


    void Update ()
    {
        if (bombeDropped == false && gameObject.transform.position.x <= bombDropLocation)
        {
            bombeDropped = true;
            Instantiate (Bomb, gameObject.transform.position, Quaternion.identity);
        }
	}
}
