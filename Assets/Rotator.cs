using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] Vector3 rotationSpeed;

    float deltaSpeed;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = -transform.right * movementSpeed;
    }
    void Update()
    {
        transform.Rotate(rotationSpeed.x * Time.deltaTime, rotationSpeed.y * Time.deltaTime, rotationSpeed.z * Time.deltaTime);
    }
}
