using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : ProjectileBehaviour
{
    // Start is called before the first frame update

    protected Transform target;
    
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        moveDirection = (target.transform.position - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }
    protected override void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }

    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        } else if
            (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
