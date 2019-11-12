using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : ObjectBehaviour
{
    public float changeTime = 3.0f;
    public bool vertical;
    

    float timer;
    int direction = 1;


    void Start()
    {
        //ObjectBehaviour::Start();
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        
        Vector2 position = rb.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
 
        rb.MovePosition(position);
    }
}
