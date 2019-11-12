using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ObjectStats
{
    // Start is called before the first frame update
    public int damageGive;

    protected override void Start()
    {
        base.Start();
        damageGive = 50;
    } 
    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
