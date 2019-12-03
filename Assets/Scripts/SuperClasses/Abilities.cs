using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : ScriptableObject
{
	public float cost;
	PlayerStats pStats;
    public virtual bool CastSpell(GameObject player, Transform firePoint){
    	pStats = player.GetComponent<PlayerStats>();
    	if(pStats.getMana() <= cost) return false;
    	SpendMana();
    	return true;
    }
    public virtual void SpendMana(){
    	pStats.SpendMana(cost);
    }
}
