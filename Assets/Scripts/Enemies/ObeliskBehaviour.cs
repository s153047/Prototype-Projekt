using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObeliskBehaviour : ObjectBehaviour
{
    // Start is called before the first frame update
    public float attackCooldown;
    public float currentCooldown;
    public GameObject ObeliskShotPrefab;
    public int volleyAmount;
    public float xMin;
    public float xMax;


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

                float volleyCurrent = Random.Range(xMin, xMax);

                while (volley.Contains(volleyCurrent))
                {
                    volleyCurrent = Random.Range(xMin, xMax);
                }
                volley.Add(volleyCurrent);
                Vector3 pos = new Vector3(volleyCurrent, 3, 0);

                Instantiate(ObeliskShotPrefab, pos, Quaternion.identity);
            }

            currentCooldown = attackCooldown;
        }
    }
}
