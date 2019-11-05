using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int damageGive;

    public void TakeDamage (int damage)

    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    void Start()
    {
        health = 100;
        damageGive = 50;
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
    void GameOver()
    {

    }
}
