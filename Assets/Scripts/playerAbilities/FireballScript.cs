using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "ScriptableObjects/Fireball", order = 1)]
public class FireballScript : Abilities
{
	public GameObject fireballPrefab;
	public int cost;
	public override void castSpell(GameObject player, Transform firePoint){
		Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }
}
