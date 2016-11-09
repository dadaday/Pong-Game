using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject ballTemplate;

	public Text firstPlayerScore;
	public Text secondPlayerScore;

	public Text CongratulationMessage;

	public bool firstPlayerWon;

	private AudioSource aSource;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	void Start ()
	{
		aSource = GetComponent<AudioSource> ();
		firstPlayerWon = false;
	}

	void OnTriggerExit (Collider other)
	{
		GameObject gameObj = other.gameObject;

		if (gameObj.CompareTag ("Ball")) {

			if (gameObj.transform.position.z < transform.position.z) {
				if(++firstPlayerScoreCounter > 1)
					CongratulationMessage.text = "Player 1 \n victory!";
				firstPlayerWon = true;
			} else {
				if(++secondPlayerScoreCounter > 1)
					CongratulationMessage.text = "Player 2 \n victory!";
				firstPlayerWon = false;
			}

			if (firstPlayerScoreCounter > 1 || secondPlayerScoreCounter > 1) {
				CongratulationMessage.enabled = true;
				firstPlayerScoreCounter = 0;
				secondPlayerScoreCounter = 0;
			} else {
				CongratulationMessage.enabled = false;
			}

			firstPlayerScore.text = firstPlayerScoreCounter.ToString ();
			secondPlayerScore.text = secondPlayerScoreCounter.ToString ();

		}
			
		aSource.Play ();

		Destroy (gameObj);
		Instantiate (ballTemplate);
	}
}
