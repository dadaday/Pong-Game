﻿using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float forceScale = 400.0f;
	public float ForceToBallScale = 300.0f;

	private Rigidbody paddle;

	// Use this for initialization
	void Start () {
		paddle = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontalAxis = Input.GetAxis ("Horizontal");

		Vector3 force = new Vector3 (horizontalAxis, 0, 0);
		force *= forceScale;	

		paddle.AddForce (force);
	
	}

	void OnCollisionEnter(Collision other) {
		GameObject gamObj = other.gameObject;

		if (gamObj.CompareTag ("Ball")) {
			float shift = gamObj.transform.position.x - transform.position.x;
			Vector3 force= new Vector3 (shift, 0.0f, 0.0f) * ForceToBallScale;

			gamObj.GetComponent<Rigidbody> ().AddForce (force);
		}
	
	}
}
