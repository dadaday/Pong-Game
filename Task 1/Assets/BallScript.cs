using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float forceScale = 500.0f;
	public float InitialAngle;

	public AudioClip WallSound;
	public AudioClip PaddleSound;

	private AudioSource aSource;
	private Rigidbody ball;

	// Use this for initialization
	void Start () {
		//angles for top paddle: -90 < x < 90
		//angles for bot paddle: 90 < x < 270
		//don't use angles less than 20 (too plain)

		if (!GameObject.Find ("InnerField").GetComponent<GameController> ().firstPlayerWon) {
			InitialAngle = Random.Range (110, 250);
		} else {
			InitialAngle = Random.Range(-70, 70);
		}

		aSource = GetComponent<AudioSource> ();
		
		ball = GetComponent<Rigidbody> ();

		Vector3 force = Quaternion.Euler(0.0f, InitialAngle, 0.0f) * Vector3.forward *  forceScale;

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
