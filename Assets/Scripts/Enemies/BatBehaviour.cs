using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : ObjectBehaviour
{
    public float changeTime = 3.0f;
    public bool vertical;

    float timer;
    int direction = 1;

    protected override void Start()
    {
        base.Start();
        timer = changeTime;
    }

    protected override void Update()
    {
        base.Update();

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