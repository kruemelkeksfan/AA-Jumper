using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour {

    [SerializeField] float speed;

    private Rigidbody rigidBody;
   
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = -transform.right * speed;
    }

}
