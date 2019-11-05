using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;
    Vector3 moveDirection;


    void Start()
    {
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

}
