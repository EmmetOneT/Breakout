using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 10;
    Rigidbody2D body;
    float horizontal;//hold input
    void Start()
    {
        body = GetComponent<Rigidbody2D>();  

    }

    // Update is called once per frame
    void Update()
    {
        //Getaxisraw no acceleration on input
        horizontal = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(horizontal * movementSpeed, 0);
    }
}
