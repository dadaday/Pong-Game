using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject ballTemplate;

	public Text firstPlayerScore;
	public Text secondPlayerScore;
	public Text TimeLimitText;

	public Text CongratulationMessage;
	public float MessageWaitTime;
	public float GameTimeInSec;

	public bool firstPlayerWon;

	private AudioSource aSource;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;

	private float counter;
	private const int MAXSCORE = 1;

	void Start ()
	{
		aSource = GetComponent<AudioSource> ();
		firstPlayerScoreCounter = 0;
		secondPlayerScoreCounter = 0;

		StartCoroutine (TimeLimit (GameTimeInSec));
	}

	private IEnumerator TimeLimit(float GameTime) {
		counter = GameTime;
		while (counter-- > 0) {
			yield return new WaitForSecondsRealtime (1.0f);
			TimeLimitText.text = counter.ToString();
		}

		if (counter <= 0) {
			if (firstPlayerScoreCounter > secondPlayerScoreCounter) {
				CongratulatePlayer (1);
			} else if (firstPlayerScoreCounter < secondPlayerScoreCounter) {
				CongratulatePlayer (2);
			}

			GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
			Destroy (ball);
			Instantiate (ballTemplate);

			this.Start ();
			firstPlayerScore.text = firstPlayerScoreCounter.ToString ();
			secondPlayerScore.text = secondPlayerScoreCounter.ToString ();
		}
	}

	private IEnumerator hideMessage (float WaitTime)
	{
		yield return new WaitForSecondsRealtime (WaitTime);
		CongratulationMessage.enabled = false;
	}

	private void CongratulatePlayer(int player) {
		Color col;

		if(player == 1)
			col = new Color (0.0f, 255f, 0.0f);
		else
			col = new Color (0.0f, 0.0f, 255f);

		CongratulationMessage.enabled = true;
		CongratulationMessage.color = col;
		CongratulationMessage.text = "Player " + player + "\n victory!";

		StartCoroutine (hideMessage (MessageWaitTime));

		firstPlayerScoreCounter = 0;
		secondPlayerScoreCounter = 0;

		counter = GameTimeInSec;
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Ball")) {
			
			GameObject ball = other.gameObject;

			if (ball.transform.position.z < transform.position.z) {
				if (++firstPlayerScoreCounter > MAXSCORE) {
					CongratulatePlayer (1);
				}
				firstPlayerWon = true;
			} else {
				if (++secondPlayerScoreCounter > MAXSCORE) {
					CongratulatePlayer (2);
				}
				firstPlayerWon = false;
			}

			firstPlayerScore.text = firstPlayerScoreCounter.ToString ();
			secondPlayerScore.text = secondPlayerScoreCounter.ToString ();

			aSource.Play ();
		}

		Destroy (other.gameObject);
		Instantiate (ballTemplate);
	}
}
