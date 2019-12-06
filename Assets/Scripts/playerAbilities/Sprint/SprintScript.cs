using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sprint", menuName = "ScriptableObjects/Sprint", order = 1)]
public class SprintScript : Abilities
{
	public float duration = 2f;
	public override bool CastSpell(GameObject player, Transform firePoint){
		PlayerController pc = player.GetComponent<PlayerController>();
		if (pc.sprintOn) return false;
		if (!base.CastSpell(player, firePoint)) return false;
		
		pc.speed = pc.baseSpeed * 2;
		pc.sprintOn = true;
		pc.StartCoroutine(removeSprint(pc));
		return true;
    }

    IEnumerator removeSprint(PlayerController pc)
    {
    	yield return new WaitForSeconds(duration);
    	pc.speed = pc.baseSpeed;
    	pc.sprintOn = false;
    }
}
/*
public class Helper : MonoBehaviour {
	public static Helper instance;
     
	void Start() {
		Helper.instance = this;
	}

    IEnumerator removeSprint(PlayerController pc, float duration)
    {
    	yield return new WaitForSeconds(duration);
    	pc.speed = pc.speed / 2;
    }
}*/
