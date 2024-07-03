using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
    [SerializeField] private string scene;
    private bool isActive = false;
    [SerializeField] private GameObject targetObject;
    public void sceneLoader()
    {
            SceneManager.LoadScene(scene);
    }

     public void ToggleObjectActive()
    {
        isActive = !isActive;
        targetObject.SetActive(isActive);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
