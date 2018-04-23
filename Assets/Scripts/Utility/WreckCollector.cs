using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckCollector : MonoBehaviour
{
	void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Ground")
        {
            ScrapManager.scrapCount = ScrapManager.scrapCount + 5;
            Destroy(gameObject);
        }
	}
}
