using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{

    public delegate void Jumper();
    public static event Jumper OnJumperCrash;
    public static event Jumper OnJumperSave;

    #region SerializedField
   public  List<Transform> positions = new List<Transform>();
    [SerializeField]
    private float moveDelay = 1.0f;
    [SerializeField]
    public LayerMask layerMask;
    #endregion SerializedField

    #region Private fields
    private int currentPosition;
    private float lastMove;
    [HideInInspector]
    public EnemySpawner enemySpawner;
    private bool dead = false;
    private float deathDelay = 0.5f;
    #endregion

    void Start()
    {
        UpdatePosition();
        lastMove = Time.time;
        StartCoroutine(Move());

    }

    private void NextPosition()
    {

        currentPosition++;
        if (currentPosition >= positions.Count)
            DestroyEnemy();
        else
            UpdatePosition();

    }

    private void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
        if(positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);
            if (hit.collider == null)
            {
                StartCoroutine(Crash());
                OnJumperCrash?.Invoke();
            }
            else
            {
                Debug.LogError("Raycast not null");
                OnJumperSave?.Invoke();
            }
        }
    }

    public void DestroyEnemy()
    {
        GameObject p = transform.parent.gameObject;
        enemySpawner.DestroyEnemy(p);
    }

    IEnumerator Crash()
    {
        dead = true;
        yield return new WaitForSeconds(deathDelay);
        DestroyEnemy();
    }
    IEnumerator Move()
    {
        while (!dead)
        {
            yield return new WaitForSeconds(moveDelay);
            NextPosition();
        }
    }
    
}
