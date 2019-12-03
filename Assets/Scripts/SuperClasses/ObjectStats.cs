using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int Health { get; private set; }

    public virtual void TakeDamage(int amount)
    {
        ChangeHealth(-amount);
    }

    public virtual void ChangeHealth (int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, maxHealth);
        if (Health <= 0)
        {
            Dead();
        }
    }

    protected virtual void Start()
    {
        Health = maxHealth;
    }

    protected virtual void Update()
    {
        
    }
    protected virtual void Dead()
    {
    	Destroy(gameObject);
    }
}
