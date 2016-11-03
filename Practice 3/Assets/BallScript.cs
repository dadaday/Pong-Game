using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float forceScale = 500.0f;
	public float InitialAngle = 20.0f;

	public AudioClip WallSound;
	public AudioClip PaddleSound;

	private AudioSource aSource;
	private Rigidbody ball;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();

		float randFloat = Random.value * 25.0f; //get random value of range [0, 25] and add it to the InitialAngle
		
		ball = GetComponent<Rigidbody> ();

		Vector3 force = Quaternion.Euler(0.0f, InitialAngle + randFloat, 0.0f) * Vector3.forward *  forceScale;

		ball.AddForce (force);
	}

	void OnCollisionEnter(Collision collision) {
		GameObject gObj = collision.gameObject;

		if (gObj.CompareTag ("Wall")) {
			aSource.PlayOneShot (WallSound);
		} else if (gObj.CompareTag ("Paddle")) {
			aSource.PlayOneShot (PaddleSound);
		}
		
	}
}
