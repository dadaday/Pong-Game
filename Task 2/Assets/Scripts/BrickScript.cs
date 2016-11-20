using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	
	private Rigidbody brick;

	void Start()
	{
		brick = GetComponent<Rigidbody> ();
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("Ball")) {	
			GameController.increaseScore (1);
			Destroy (brick.gameObject);
		}
	}
}
