using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{

    private float rotationZ = 0f;
    private float sensitivityZ = 2f;

    void Update ()
    {
        rotationZ += -1 * sensitivityZ;
        rotationZ = Mathf.Clamp(rotationZ, -90, 90);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
    }

}
