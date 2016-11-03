using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float forceScale = 500.0f;
	public float InitialAngle = 20.0f;

	private Rigidbody ball;

	// Use this for initialization
	void Start () {
		float randFloat = Random.value * 25.0f;
		
		ball = GetComponent<Rigidbody> ();

		Vector3 force = Quaternion.Euler(0.0f, InitialAngle + randFloat, 0.0f) * Vector3.back *  forceScale;

		ball.AddForce (force);
	}
}
