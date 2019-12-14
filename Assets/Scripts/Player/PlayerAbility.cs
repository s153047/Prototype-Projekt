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
        foreach (char c in Input.inputString) {
            switch (c) {
                case '1' :
                    CastSpell(0);
                    break;
                case '2' :
                    CastSpell(1);
                    break;
                case '3' :
                    CastSpell(2);
                    break;
                case '4' :
                    CastSpell(3);
                    break;
                case '5' :
                    CastSpell(4);
                    break;
                default :
                    break;
            }
        }
        if (Input.GetButtonDown("Fire1") && currentCooldown <= 0)
        {
            Shoot();
            currentCooldown = globalCooldown;
        }
    }

    void CastSpell(int i){
        abilityScripts[i].CastSpell(gameObject, firePoint);
        currentCooldown = globalCooldown;
    }

    void Shoot()
    {
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
    }
}
