using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] Text discriptionDisplay;
    [Header("Canvases")]
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject gameSceneCanvas;
    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject towerCanvas;
    [SerializeField] GameObject enemyCanvas;
    [SerializeField] GameObject scrapCanvas;
    [Header("Camera Positions")]
    [SerializeField] Transform mainPosition;
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform towerPosition;
    [SerializeField] Transform enemyPosition;
    [SerializeField] Transform scrapPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    public void SetDiscription(string discriptionText)
    {
        discriptionDisplay.text = discriptionText;
    }
    public void BackToMenu()
    {
        CloseAllCanvases();
        mainCanvas.SetActive(true);
        mainCamera.transform.position = mainPosition.position;
        mainCamera.transform.rotation = mainPosition.rotation;
    }
    public void ToGameScene()
    {
        CloseAllCanvases();
        gameSceneCanvas.SetActive(true);
    }
    public void ToPlayer()
    {
        CloseAllCanvases();
        playerCanvas.SetActive(true);
        mainCamera.transform.position = playerPosition.position;
        mainCamera.transform.rotation = playerPosition.rotation;
    }
    public void ToTowers()
    {
        CloseAllCanvases();
        towerCanvas.SetActive(true);
        mainCamera.transform.position = towerPosition.position;
        mainCamera.transform.rotation = towerPosition.rotation;
    }
    public void ToEnemies()
    {
        CloseAllCanvases();
        enemyCanvas.SetActive(true);
        mainCamera.transform.position = enemyPosition.position;
        mainCamera.transform.rotation = enemyPosition.rotation;
    }
    public void ToScrap()
    {
        CloseAllCanvases();
        scrapCanvas.SetActive(true);
        mainCamera.transform.position = scrapPosition.position;
        mainCamera.transform.rotation = scrapPosition.rotation;
    }
    private void CloseAllCanvases()
    {
        mainCanvas.SetActive(false);
        gameSceneCanvas.SetActive(false);
        playerCanvas.SetActive(false);
        towerCanvas.SetActive(false);
        enemyCanvas.SetActive(false);
        scrapCanvas.SetActive(false);
    }
}
