﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckCollector : MonoBehaviour
{
    [SerializeField] int wreckDumpValue = 5;

    float wakableMapEndX = 2;
    float wreckDumpX = -10;

    private void Start()
    {
        if (transform.position.x > wakableMapEndX)
        {
            transform.position = new Vector3(wreckDumpX, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Ground")
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount + wreckDumpValue;
            Destroy(gameObject);
        }
	}
}
