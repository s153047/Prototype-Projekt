﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : ObjectStats
{
    // Start is called before the first frame update
    public float maxMana = 100f;
    public float manaRegen = 100f;
    public int damageGive = 50;
    private Slider healthSlider;
    private Slider manaSlider;
    float currentMana;

    public override void ChangeHealth(int damage)
    {
        base.ChangeHealth(damage);

        healthSlider.value = (float) Health / maxHealth;
    }

    public void ChangeMana(float change){
        currentMana = Mathf.Clamp(currentMana + change, 0.0f, maxMana);
    }

    public float getMana(){
        return currentMana;
    }

    protected override void Start()
    {
        base.Start();
        currentMana = maxMana;
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
    } 
    protected override void Dead()
    {
        healthSlider.value = 0;
        base.Dead();
    }

    // Update is called once per frame
    protected override void Update()
    {
        currentMana = Mathf.Clamp(currentMana + (manaRegen * Time.deltaTime), 0f, maxMana);
        manaSlider.value = currentMana / maxMana;
    }

}
