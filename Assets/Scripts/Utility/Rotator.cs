using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed;

    Vector3 startLocalPosition;
    float deltaSpeed;

    void Start()
    {
        startLocalPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startLocalPosition;
        transform.Rotate(rotationSpeed.x * Time.deltaTime, rotationSpeed.y * Time.deltaTime, rotationSpeed.z * Time.deltaTime);
    }
}
