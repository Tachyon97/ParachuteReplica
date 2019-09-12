using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    public void OnMouseDown()
    {

        gameManager.RestartGame();
    }

}
