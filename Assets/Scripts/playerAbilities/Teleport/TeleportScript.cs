using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleport", menuName = "ScriptableObjects/Teleport", order = 1)]
public class TeleportScript : Abilities
{
	public float range = 5f;
	public override bool CastSpell(GameObject player, Transform firePoint){
		if (!base.CastSpell(player, firePoint)) return false;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 target = new Vector3(Mathf.Clamp(mousePos.x,-7.6f,7.6f),Mathf.Clamp(mousePos.y - 0.5f, -4f, 3.6f),0f);
		player.transform.position = player.transform.position + Vector3.ClampMagnitude(target - player.transform.position, range);
		return true;
    }
}