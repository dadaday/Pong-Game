using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {

	public float forceScale = 400.0f;
	public float ForceToBallScale = 400.0f;

	private Rigidbody ball;
	private Rigidbody paddle;

	// Use this for initialization
	void Start () {
		paddle = GetComponent<Rigidbody> ();
		ball = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!ball)
			ball = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody> ();
		
		if (ball.velocity.z > 0 && ball.transform.position.z > 0) {
			Vector3 force = new Vector3 (0, 0, 0);
			float dir = ball.transform.position.x - transform.position.x;

			if(dir > 2)
				force = new Vector3 (1, 0, 0);
			else if (dir < -2)
				force = new Vector3 (-1, 0, 0);
			
			force *= forceScale;	
			paddle.AddForce (force);
		}
	}

	void OnCollisionEnter(Collision other) {
		GameObject gamObj = other.gameObject;

		if (gamObj.CompareTag ("Ball")) {
			Vector3 force;
			float shift = gamObj.transform.position.x - transform.position.x;

			//			if (shift < transform.localScale.x / 4 && shift > -1 * transform.localScale.x / 4) {
			//				Debug.Log ("here");
			//				force = new Vector3 (0.0f, 0.0f, shift) * ForceToBallScale;
			//			} else {
			force = new Vector3 (shift, 0.0f, 0.0f) * ForceToBallScale;
			//			}

			gamObj.GetComponent<Rigidbody> ().AddForce (force);
		}

	}
}
