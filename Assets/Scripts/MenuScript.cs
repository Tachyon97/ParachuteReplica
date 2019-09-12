using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool startGame;
    public delegate void MenuPressed();
    public static event MenuPressed StartGame;
    public static event MenuPressed ExitGame;


    void Start()
    {

        Debug.Log("HEj1");
    }
    


    void OnMouseDown()
    {
        Debug.Log("HEj");
        if (StartGame != null && startGame)
            StartGame();
        else
            ExitGame?.Invoke();
    }
}

