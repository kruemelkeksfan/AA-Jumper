using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    private float rotationZ = 0.0f;
    private float sensitivityZ = 2.0f;

    void Update ()
    {
        if (rotationZ < 90)
        {
            rotationZ += sensitivityZ;
        }
        if (transform.position.y <= -5)
        {
            DestroyObject(gameObject);
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotationZ);
    }
}
