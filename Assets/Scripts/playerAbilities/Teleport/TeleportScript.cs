using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleport", menuName = "ScriptableObjects/Teleport", order = 1)]
public class TeleportScript : Abilities
{
	//public float range = 2f;
	public override bool CastSpell(GameObject player, Transform firePoint){
		if (!base.CastSpell(player, firePoint)) return false;
		Vector3 targetTmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 target = new Vector3(Mathf.Clamp(targetTmp.x,-7.6f,7.6f),Mathf.Clamp(targetTmp.y, -4f, 3.6f),0f);
		//target.y -= 0.5f;

		player.transform.position = target;
		return true;
    }


}

