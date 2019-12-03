using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public Abilities[] abilityScripts;
    public float globalCooldown;
    float currentCooldown;

    void Start()
    {
        currentCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            foreach (char c in Input.inputString) {
                switch (c) {
                    case '1' :
                        castSpell(0);
                        break;
                    case '2' :
                        castSpell(1);
                        break;
                    case '3' :
                        castSpell(2);
                        break;
                    case '4' :
                        castSpell(3);
                        break;
                    default :
                        break;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                currentCooldown = globalCooldown;
            }
        }
    }

    void castSpell(int i){
        abilityScripts[i].castSpell(gameObject, firePoint);
        currentCooldown = globalCooldown;
    }

    void Shoot()
    {
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
    }
}
