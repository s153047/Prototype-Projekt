using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterBehaviour : MonoBehaviour
{
    GameObject player;
    public float orbitDistance = 1.5f;
    public float orbitDegreesPerSec = 180.0f;
    public int damage = 100;

    void Start () {
    	player = GameObject.FindWithTag("Player"); 
    }
    
    void Orbit()
    {
        if(player != null)
        {
            // Keep us at orbitDistance from player
            Vector3 playerPos = player.transform.position + new Vector3(0f,0.5f,0f);
            transform.position = playerPos + (transform.position - playerPos).normalized * orbitDistance;
            transform.RotateAround(playerPos, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);
        }
    }
    
    void LateUpdate () {
        Orbit();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(damage);
        }
    }
}
