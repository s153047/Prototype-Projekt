using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TotemBehaviour : ObjectBehaviour
{
    public float attackCooldown;
    public float currentCooldown;
    public GameObject TotemShotPrefab;
    public int volleyAmount;
    public float yMin;
    public float yMax;


    protected override void Update()
    {
        ShootVolley();
        currentCooldown -= Time.deltaTime;
    }

    void ShootVolley()
    {
        if (currentCooldown < 0)
        {
            List<float> volley = new List<float>();
            for (int i = 0; i < volleyAmount; i++)
            {

                float volleyCurrent = Random.Range(yMin, yMax);

                while (volley.Contains(volleyCurrent))
                {
                    volleyCurrent = Random.Range(yMin, yMax);
                }
                volley.Add(volleyCurrent);
                Vector3 pos = new Vector3(-7, volleyCurrent, 0);

                Instantiate(TotemShotPrefab, pos, Quaternion.identity);
            }

            currentCooldown = attackCooldown;
        }
    }



}
