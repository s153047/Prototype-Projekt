using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;


    public virtual void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
    protected virtual void Dead()
    {
    	Destroy(gameObject);
    }
}
