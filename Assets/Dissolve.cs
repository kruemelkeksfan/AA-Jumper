using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] Color dissolveEdgeColor;
    [SerializeField] Renderer[] objectsToDissolve;
    bool dissolveIn;
    bool dissolveOut;

    float startTime;
    float dissolveTime;

    List<Material> materialsToDissolve = new List<Material>();

	// Use this for initialization
    public void SetDissolveIn(float dissolveTimeRef)
    {
        startTime = Time.time;
        foreach (Renderer objectToDissolve in objectsToDissolve)
        {
            objectToDissolve.receiveShadows = false;
        }
        dissolveTime = dissolveTimeRef;
        dissolveIn = true;
    }
    public void SetDissolveOut(float dissolveTimeRef)
    {
        startTime = Time.time;
        foreach (Renderer objectToDissolve in objectsToDissolve)
        {
            objectToDissolve.receiveShadows = false;
        }
        dissolveTime = dissolveTimeRef;
        dissolveOut = true;
    }
    void Start ()
    {
        foreach (Renderer objectToDissolve in objectsToDissolve)
        {
            materialsToDissolve.Add(objectToDissolve.material);
        }
        foreach (Material materialToDissolve in materialsToDissolve)
        {
            materialToDissolve.SetColor("Color_BB502008", dissolveEdgeColor);
        }
    }
	void Update ()
    {
        if (dissolveOut)
        {
            float dissolveProgress = (Time.time - startTime) / dissolveTime;
            foreach (Material materialToDissolve in materialsToDissolve)
            {
                materialToDissolve.SetFloat("Vector1_86334E84", dissolveProgress);
            }
        }
        else if (dissolveIn)
        {
            float dissolveProgress = (Time.time - startTime) / dissolveTime;
            foreach (Material materialToDissolve in materialsToDissolve)
            {
                materialToDissolve.SetFloat("Vector1_86334E84", (1 - dissolveProgress));
            }
            if (dissolveProgress >= 1)
            {
                foreach (Renderer objectToDissolve in objectsToDissolve)
                {
                    objectToDissolve.receiveShadows = true;
                }
                dissolveIn = false;
            }
        }
	}
}
