using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyStats : ObjectStats
{
    public GameObject[] SpecialDrops;
    public int Tier = 1;

    protected override void Dead()
    {
        Vector3 baseDropPosition = gameObject.transform.position;

        // DropManager.Instance.EnemyDied(baseDropPosition, Tier, SpecialDrops);

        // Need to call last to ensure we capture transform position from the dead enemy
        base.Dead();
    }
}
