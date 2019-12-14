﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskShotBehaviour : EnemyProjectileBehaviour
{
    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (new Vector3(transform.position.x, transform.position.y-4, transform.position.z) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if
          (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
