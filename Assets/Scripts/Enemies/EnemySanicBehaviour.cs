﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySanicBehaviour : ObjectBehaviour
{
    public Transform target;

    GameObject player;
    float attackPause;
    public int damage;
    public float waitTime;
    public float currentTime;
    protected override void Start()
    {
        base.Start();

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player == null)
            return;

        target = player.transform;
        if (currentTime >= waitTime)
        { 
            if (Vector3.Distance(transform.position, target.position) > 0.5f)
            {
                MoveTowards(target.position);
                RotateTowards(target.position);
            }
        }

        currentTime += Time.deltaTime;
        speed += Time.deltaTime;
        


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
            speed = 0;
            currentTime = 0;
        }
    }
    
    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void RotateTowards(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }
}
