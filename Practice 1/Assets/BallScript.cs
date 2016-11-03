using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float forceScale = 10.0f;

	private Rigidbody ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (horizontalAxis, 0, verticalAxis);
		force *= forceScale;	

		ball.AddForce (force);
	}
}
