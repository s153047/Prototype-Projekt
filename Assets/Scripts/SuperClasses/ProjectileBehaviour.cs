using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
	// Start is called before the first frame update
	public int damage = 50;
    public float speed;
    public Rigidbody2D rb;
    protected Vector3 moveDirection;
    
    protected virtual void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    protected virtual void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Walls")){
            Destroy(gameObject);
        }
    }

}
