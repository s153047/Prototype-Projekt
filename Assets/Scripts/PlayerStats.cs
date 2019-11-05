using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circl : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GameOver()
    {

    }
}
