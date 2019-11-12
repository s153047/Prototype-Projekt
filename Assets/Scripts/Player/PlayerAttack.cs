using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public float coolDown;
    float currentCoolDown;


    void Start()
    {
        currentCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                currentCoolDown = coolDown;
            }
        }
    }

    void Shoot()
    {
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
    }
}
