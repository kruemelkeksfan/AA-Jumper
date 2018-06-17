using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{ 
	public void StartGame ()
    {
        SceneManager.LoadScene(1);
	}
    public void StartCustomGame ()
    {
        SceneManager.LoadScene(2);
    }
    public void EndGame ()
    {
        Application.Quit();
	}
    public void MainMenu ()
    {
        SceneManager.LoadScene(0);
    }
    public void closeWindow(GameObject window)
    {
        window.SetActive(false);
    }
}
