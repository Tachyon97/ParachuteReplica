using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startLives = 3;
    private int points = 0;
    public Text text;
    public LivesController livesController;
    EnemySpawner enemySpawner;
    public GameObject gameOver;
    public GameObject input;

    void Start()
    {
        DisplayText();
        livesController.InitLives(startLives);
        enemySpawner = GetComponent<EnemySpawner>();
        gameOver.SetActive(false);
    }
    public int Points()
    {
        return points;
    }
    public void EnemyCrashed()
    {
        if (!livesController.RemoveLife())
            GameOver();

    }
    public void EnemySaved()
    {
        points++;
        DisplayText();
    }
    private void GameOver()
    {
        gameOver.SetActive(true);
        enemySpawner.Stop();
        input.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    void OnEnable()
    {
        JumpController.OnJumperCrash += EnemyCrashed;
        JumpController.OnJumperSave += EnemySaved;
    }

    void OnDisable()
    {
        JumpController.OnJumperCrash -= EnemyCrashed;
        JumpController.OnJumperSave -= EnemySaved;
    }

    private void DisplayText()
    {
        text.GetComponent<Text>().text = points.ToString();
    }
}
