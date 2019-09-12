using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuObject : MonoBehaviour
{

    void Start()
    {
        Debug.Log(this.name);
    }


    private void OnEnable()
    {
        Debug.Log("OnEnable");
        MenuScript.StartGame += StartGame;
        MenuScript.ExitGame += ExitGame;
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
        MenuScript.StartGame -= StartGame;
        MenuScript.ExitGame -= ExitGame;
    }

    private void ExitGame()
    {
        Debug.Log("ExitGame()");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("StartGame()");
        SceneManager.LoadScene(1);
    }
}
