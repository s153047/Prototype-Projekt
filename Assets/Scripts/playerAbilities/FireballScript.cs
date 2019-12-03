using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "ScriptableObjects/Fireball", order = 1)]
public class FireballScript : Abilities
{
	public GameObject fireballPrefab;
	public override bool CastSpell(GameObject player, Transform firePoint){
		if(!base.CastSpell(player, firePoint)) return false;
		Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
		return true;
    }


}
