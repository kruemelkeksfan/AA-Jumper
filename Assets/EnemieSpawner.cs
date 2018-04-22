using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour {

    [SerializeField] GameObject Dreadnought;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnRotation = Quaternion.identity;

    void Start ()
    {
        Instantiate(Dreadnought, spawnPosition, spawnRotation);
	}
	
	
	void Update ()
    {
		
	}
}
