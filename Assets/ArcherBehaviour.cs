using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehaviour : ObjectBehaviour
{
    public Transform target;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject ArcherShotPrefab;
    Vector2 direction;
    float angle;

    GameObject player;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player != null)
        {
            target = player.transform;
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
            direction.Normalize();
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //RotateTowards();
            ShootAtPlayer();
            currentCooldown -= Time.deltaTime;
        }
    }
    void ShootAtPlayer()
    {
        if (currentCooldown < 0)
        {

            Instantiate(ArcherShotPrefab, transform.position, Quaternion.Euler(Vector3.forward * (angle)));

            currentCooldown = attackCooldown;
        }
    }
    private void RotateTowards()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }
}
