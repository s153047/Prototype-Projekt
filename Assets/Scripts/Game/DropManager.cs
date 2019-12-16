using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance = null;

    public GameObject[] Tier1Drops;
    public int Tier1Weight = 2;
    public GameObject[] Tier2Drops;
    public int Tier2Weight = 1;


    void Awake()
    {
        // Maintain only one instantiation of Instance at a time
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void EnemyDied(Vector3 pos, int tier, GameObject[] specialDrops)
    {
        if (!Tier1Drops.Any() || !Tier2Drops.Any())
        {
            return;
        }


        // Just do a 50% drop chance for now
        var roll = Random.Range(0, 100);
        if (roll >= 50)
        {

            // Now check if it's tier 1 or 2
            roll = Random.Range(0, Tier1Weight + Tier2Weight + 1);
            
            // T1 drop
            if (roll < Tier1Weight)
            {
                SpawnDrop(pos, Tier1Drops[Random.Range(0, Tier1Drops.Length)]);
            }
            // T2 drop
            else if (tier >= 2)
            {
                SpawnDrop(pos, Tier2Drops[Random.Range(0, Tier2Drops.Length)]);
            }
        }


        // Roll for special item, 5% chance
        if (specialDrops.Any())
        {
            roll = Random.Range(0, 100);
            if (roll >= 95)
            {
                var specialItem = specialDrops[Random.Range(0, specialDrops.Length)];
                SpawnDrop(pos, specialItem);
            }
        }
    }

    private void SpawnDrop(Vector3 pos, GameObject item)
    {
        Instantiate(item, pos, Quaternion.identity);
    }
}
