using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Orbiter", menuName = "ScriptableObjects/Orbiter", order = 1)]
public class OrbiterScript : Abilities
{
	public GameObject orbiterPrefab;
	public float duration = 5f;
	GameObject orbInstance;
	public override bool CastSpell(GameObject player, Transform firePoint){
		if(!base.CastSpell(player, firePoint)) return false;
		orbInstance = Instantiate(orbiterPrefab, firePoint.position, firePoint.rotation);
		OrbiterBehaviour orbBehav = orbInstance.GetComponent<OrbiterBehaviour>();
		orbBehav.StartCoroutine(deleteOrbInstance());
		return true;
    }


    IEnumerator deleteOrbInstance()
    {
    	yield return new WaitForSeconds(duration);
    	Destroy(orbInstance);
    }

}
