using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject ballTemplate;

	public Text firstPlayerScore;
	public Text secondPlayerScore;

	public bool firstPlayerWon;

	private AudioSource aSource;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	void Start() {
		aSource = GetComponent<AudioSource> ();
		firstPlayerWon = false;
	}

	void OnTriggerExit(Collider other) {
		GameObject gameObj = other.gameObject;

		if (gameObj.CompareTag ("Ball")) {

			if (gameObj.transform.position.z < transform.position.z) {
				++firstPlayerScoreCounter;
				firstPlayerScore.text = firstPlayerScoreCounter.ToString ();
				firstPlayerWon = true;
			} else {
				++secondPlayerScoreCounter;
				secondPlayerScore.text = secondPlayerScoreCounter.ToString ();	
				firstPlayerWon = false;
			}

			aSource.Play ();

			Destroy (gameObj);
			Instantiate (ballTemplate);
		}
		
	}
}
