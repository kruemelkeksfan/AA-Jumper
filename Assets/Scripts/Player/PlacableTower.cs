using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableTower : MonoBehaviour
{
    public static int TowerCCount;
    public static int EnvironmentCCount;

    [SerializeField] List<Collider> hittingTower = new List<Collider>();
    [SerializeField] List<Collider> hittingEnvironment = new List<Collider>();
    [SerializeField] GameObject towerCanvas;

    float canvasDisplayTime = 10;
    float canvasDisplayStart = -10;

    private void Start()
    {
        TowerCCount = 0;
        EnvironmentCCount = 0;
    }
    private void Update()
    {
        if ((canvasDisplayStart + canvasDisplayTime) < Time.time)
        {
            towerCanvas.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            towerCanvas.SetActive(false);
        }
    }
    void OnTriggerEnter (Collider c)
    {
        
        if (c.tag == "Tower")
        {
            hittingTower.Add(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Add(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tower")
        {
            hittingTower.Remove(c);
            TowerCCount = hittingTower.Count;
        }
        else if (c.tag == "Environment")
        {
            hittingEnvironment.Remove(c);
            EnvironmentCCount = hittingEnvironment.Count;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Hello Dev");
        canvasDisplayStart = Time.time;
        towerCanvas.SetActive(true);
    }
}


