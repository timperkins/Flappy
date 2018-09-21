using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb;
	private Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if (isDead == false) {
			if (Input.GetMouseButtonDown(0)) {
				rb.velocity = Vector2.zero;
				rb.AddForce(new Vector2(0, upForce));
				anim.SetTrigger("Flap");
			}
		}
	}

	void OnCollisionEnter2D() {
		rb.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger("Die");
		GameControl.instance.BirdDied();
	}
}
