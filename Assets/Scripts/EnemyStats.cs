using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;


    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Dead()
    {
    	Destroy(gameObject);
    }
}
