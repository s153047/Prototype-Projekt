using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : ObjectStats
{
    // Start is called before the first frame update
    public int damageGive = 50;
    private Slider healthSlider;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthSlider.value = health / 100 * 100;
    }

    protected override void Start()
    {
        base.Start();

        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
    } 

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
