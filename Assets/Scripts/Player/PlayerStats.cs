using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : ObjectStats
{
    // Start is called before the first frame update
    public int damageGive = 50;
    private Slider healthSlider;

    public override void ChangeHealth(int damage)
    {
        base.ChangeHealth(damage);

        healthSlider.value = Health;
    }

    protected override void Start()
    {
        base.Start();

        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
    } 
    protected override void Dead()
    {
        healthSlider.value = 0;
        base.Dead();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
