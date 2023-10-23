using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startingPosition;
    public float movementSpeed = 10;
    Rigidbody2D body;
    AudioSource audioSource;
    public GameManager manager;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        startingPosition = transform.position;
        PickDirectionAndMove();
    }

    // Update is called once per frame
    

    void ResetPosition()
    {
        transform.position = startingPosition;
    }

    void PickDirectionAndMove()
    {
        Vector2 direction = new Vector2(Random.Range(45,135), Random.Range(45,135));
        transform.up = direction;
        body.velocity = transform.up * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            manager.OnBlockDestroyed();
        }
        else if (collision.gameObject.CompareTag("Kill"))
        {
            ResetPosition();
            PickDirectionAndMove();
            manager.OnLifeLost();
        }
    }
}
