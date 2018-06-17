using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float shellSpeed;
    [SerializeField] GameObject shellHeader;

    void Update ()
    {
        gameObject.name = shellHeader.name;
        transform.localPosition = new Vector3 (transform.localPosition.x + shellSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x > 1000)
        {
            Object.Destroy(gameObject);
        }
	}
    private void OnDestroy()
    {
        Object.Destroy(shellHeader);
    }
}
