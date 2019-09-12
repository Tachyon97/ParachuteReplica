using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Prefab = new List<GameObject>();
    float lastSpawnTime;
    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    private float randomDelay;
    [Range(0, 2)]
    public float deltaRandom = 0.5f;
    private List<GameObject> enemies = new List<GameObject>();
    GameManager gameManager;
    private bool stop = false;
    public float spawnDelayDecreaseSpeed = 0.02f;

    private GameObject _RandomPrefab()
    {
        return Prefab[Random.Range(0, Prefab.Count)];
    }

    void Start()
    {

        if (_RandomPrefab() == null)
            return;
        gameManager = GetComponent<GameManager>();
        randomDelay = spawnDelay;
        SpawnEnemy();
    }

    private void Update()
    {
        if (!stop && Time.time > lastSpawnTime + randomDelay)
            SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        lastSpawnTime = Time.time;
        float delay = Mathf.Clamp(spawnDelay - (spawnDelayDecreaseSpeed * gameManager.Points()), deltaRandom, spawnDelay);
        randomDelay = Random.Range(delay - deltaRandom, delay + deltaRandom);
        GameObject enemy = Instantiate(_RandomPrefab());
        enemies.Add(enemy);
        JumpController jumper = enemy.GetComponentInChildren<JumpController>();
        jumper.enemySpawner = this;
    }
    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }
    public void Stop()
    {
        stop = true;
        for (int i = enemies.Count - 1; i >= 0; i--)
            DestroyEnemy(enemies[i]);
    }
}
