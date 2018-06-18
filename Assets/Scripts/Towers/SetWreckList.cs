using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWreckList : MonoBehaviour
{
    SetWreckList setWreckList;
    CollectorTowerController collectorTowerController;
	
	void Start ()
    {
        setWreckList = gameObject.GetComponent<SetWreckList>();
        collectorTowerController = gameObject.GetComponent<CollectorTowerController>();
	}
    private void Update()
    {
        Object.Destroy(setWreckList);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Scrap" && collectorTowerController.wrecksInRange.Contains(other))
        {
            collectorTowerController.wrecksInRange.Add(other);
        }
    }
}
