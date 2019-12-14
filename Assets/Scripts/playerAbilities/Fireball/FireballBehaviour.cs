using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : ProjectileBehaviour
{
    public GameObject exploPrefab;
	public float explosionRadius = 1.0f;
	Vector3 endPoint;
    float angle;

	protected override void Start(){
    	base.Start();
		endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	endPoint.z = 0;
        angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle+90f));
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
        Instantiate(exploPrefab,transform.position,transform.rotation);
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
