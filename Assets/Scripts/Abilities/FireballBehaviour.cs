﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : ProjectileBehaviour
{
	public float explosionRadius = 1.0f;
	Vector3 endPoint;
	protected override void Start(){
    	base.Start();
		endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	endPoint.z = 0;
	}
    protected override void Update()
    {
    	base.Update();
    	if (Vector3.Distance(endPoint, transform.position) < 0.1){
    		Explode();
    	}
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
        	Explode();
        } else if (other.gameObject.CompareTag("Walls")){
            Explode();
        }
    }

    void Explode(){
    	Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
    	foreach (Collider2D c in hitColliders){
    		if (c.gameObject.CompareTag("Enemy")){
    			EnemyStats enemy = c.GetComponent<EnemyStats>();
            	enemy.TakeDamage(damage);
    		}
    	}
    	Destroy(gameObject);
    }

}