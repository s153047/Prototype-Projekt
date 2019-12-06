using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    public float baseSpeed;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public bool sprintOn;
    void Start()
    {
    	rigidbody2d = GetComponent<Rigidbody2D>();
        speed = baseSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x += 3.0f * horizontal * Time.deltaTime * speed;
        position.y += 3.0f * vertical * Time.deltaTime * speed;

        rigidbody2d.MovePosition(position);
    }
}
