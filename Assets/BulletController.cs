using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float shellSpeed;

    void Update ()
    {
        transform.localPosition = new Vector3 (transform.localPosition.x + shellSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
	}
}
