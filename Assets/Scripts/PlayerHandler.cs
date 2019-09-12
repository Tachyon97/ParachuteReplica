using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    List<Transform> positions = new List<Transform>();
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    int startPosition = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprites[1];
        UpdatePosition();

    }

    //Disable event   
    private void OnDisable()
    {
        TouchBehaviour.OnLeftPressed -= OnLeftPressed;
        TouchBehaviour.OnRightPressed -= onRightPressed;
    }

    //Enable event
    private void OnEnable()
    {
        TouchBehaviour.OnLeftPressed += OnLeftPressed;
        TouchBehaviour.OnRightPressed += onRightPressed;
    }
    public void OnLeftPressed()
    {
        log("Left touch");
        if(DoLeft())
        {
            startPosition++;
            UpdatePosition();
        }
    }
    public void onRightPressed()
    {
        log("Right touch");
        if(DoRight())
        {
            startPosition--;
            UpdatePosition();
        }
    }

    private bool DoRight()
    {
        if (transform.position != positions[0].position)
            return true;
        return false;
    }
    private bool DoLeft()
    {

        if (transform.position != positions[2].position)
            return true;
        return false;
    }

    private void UpdatePosition()
    {
        transform.position = positions[startPosition].position;
    }

    void Update()
    {
        ExecuteAnimation();
    }

    private void ExecuteAnimation()
    {
        LeftSprite();
        MiddleSprite();
        RightSprite();
    }


    private void LeftSprite()
    {
        if (transform.position == positions[0].position)
        {

            if (spriteRenderer.sprite != sprites[0])
            {
                spriteRenderer.sprite = sprites[0];
            }
        }
    }
    private void MiddleSprite()
    {
        if (transform.position == positions[1].position)
        {
            if (spriteRenderer.sprite != sprites[1])
            {
                spriteRenderer.sprite = sprites[1];
            }
        }
    }
    private void RightSprite()
    {
        if (transform.position == positions[2].position)
        {
            if (spriteRenderer.sprite != sprites[2])
            {
                spriteRenderer.sprite = sprites[2];
            }
        }
    }


    private void log(string m)
    {
        Debug.Log(m);
    }
}
