﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{

    [SerializeField] float destroyTimer = 2f;

	void Start ()
    {
        Destroy(gameObject, destroyTimer);
	}

}
