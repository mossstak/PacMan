using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour {

    //Settings
    public float speed = 1.0f;//the speed pacman can travel

    //Processing variables
    private Vector2 direction; //the direction pacman is going

    //References
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        anim.SetBool("moving", rb2d.velocity.magnitude > 0.1);
		if (Input.GetAxis("Horizontal") < 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = Vector2.right;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            direction = Vector2.up;
        }
        rb2d.velocity = direction * speed;
        transform.up = direction;
        if (rb2d.velocity.x == 0)
        {
            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
        }
        if (rb2d.velocity.y == 0)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
        }
    }
}
