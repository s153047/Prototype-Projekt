using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatBehaviour : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rb;
    float timer;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        
        
        Vector2 position = GetComponent<Rigidbody2D>().position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
 
        GetComponent<Rigidbody2D>().MovePosition(position);
    }
    

}
