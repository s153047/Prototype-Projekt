using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichBehaviour : ObjectBehaviour
{
    public Transform target;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject LichShotPrefab;
    Vector2 direction;
    float angle;
    float xOffset;
    float yOffset;
    // Start is called before the first frame update

    // Update is called once per frame
    protected override void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        xOffset = 0 * Mathf.Cos(angle*Mathf.Deg2Rad) + 1 * Mathf.Sin(angle*Mathf.Deg2Rad);
        yOffset = 0 * Mathf.Sin(angle * Mathf.Deg2Rad) + 1 * Mathf.Cos(angle * Mathf.Deg2Rad);
        //RotateTowards();
        ShootAtPlayer();
        currentCooldown -= Time.deltaTime; 
    }
    void ShootAtPlayer()
    {
        if (currentCooldown < 0)
        {

            Instantiate(LichShotPrefab, transform.position, Quaternion.Euler(Vector3.forward * (angle+90f)));
            Instantiate(LichShotPrefab, new Vector3(transform.position.x + xOffset,transform.position.y - yOffset, transform.position.z), Quaternion.Euler(Vector3.forward * (angle+90f)));
            Instantiate(LichShotPrefab, new Vector3(transform.position.x - xOffset,transform.position.y + yOffset, transform.position.z), Quaternion.Euler(Vector3.forward * (angle+90f)));
            currentCooldown = attackCooldown;
        }
    }
    private void RotateTowards()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }
}
