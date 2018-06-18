using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] Vector3 maxPosition;
    [SerializeField] Vector3 minPosition;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    float floatSpeed;

    private void Start()
    {
        float cloudXPos = Random.Range(minPosition.x, maxPosition.x);
        ResetCloud(cloudXPos);
    }

    private void ResetCloud(float cloudXPos)
    {
        transform.position = new Vector3(cloudXPos, Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        floatSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (floatSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        if (transform.position.x >= maxPosition.x)
        {
            ResetCloud(minPosition.x);
        }
    }
}
