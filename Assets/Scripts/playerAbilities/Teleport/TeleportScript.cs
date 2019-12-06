using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleport", menuName = "ScriptableObjects/Teleport", order = 1)]
public class TeleportScript : Abilities
{
	//public float range = 2f;
	public override bool CastSpell(GameObject player, Transform firePoint){
		if (!base.CastSpell(player, firePoint)) return false;
		Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = 0;
		target.y -= 0.5f;
		player.transform.position = target;
		return true;
    }


}

