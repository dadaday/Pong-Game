using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject ballTemplate;
	public GameObject brickTemplate;

	public int Lives;
	public Text LivesLeft;
	public Text WinLossMessage;

	public Text ScoreMessage;
	public static int Score;
	private AudioSource aSource;

	public static GameController Instance;

	void Start ()
	{
		Instance = this;
		Score = 0;
		Lives = 3;
		bool green = true;
		aSource = GetComponent<AudioSource> ();

		int l = -36;
		int r = 36;

		for (int i = 1; i < 7; i++)
		{
			for(int j = l; j <= r; j+=3)
			{
				GameObject brick = Instantiate (brickTemplate, new Vector3 (5.0f + i * 3.0f , 0, j), Quaternion.identity) as GameObject;

				if (!green) {
					brick.GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.blue);
				}

				green = !green;
			}
			green = !green;
			l += 3;
			r -= 3;
		}
	}

	void Update() {
		ScoreMessage.text = "Score: " + Score.ToString ();
	}

	void WinCondition() {
		WinLossMessage.text = "YOU WON!\n YOUR SCORE IS " + Score;
		WinLossMessage.enabled = true;
		StartCoroutine (hideMessage (2.0f));
		Start ();
	}

	public static void increaseScore(int n) {
		Score += n;
		if (Score == 120) {
			Instance.WinCondition ();
		}
	}

	private IEnumerator hideMessage (float WaitTime)
	{
		yield return new WaitForSecondsRealtime (WaitTime);
		WinLossMessage.enabled = false;
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Ball")) {
			GameObject ball = other.gameObject;
			aSource.Play ();

			if (--Lives == 0) {
				WinLossMessage.text = "YOU LOST!\n YOUR SCORE IS " + Score;
				WinLossMessage.enabled = true;
				StartCoroutine (hideMessage (2.0f));
				this.Start ();
			}

			LivesLeft.text = "Lives left: " + Lives;

			Destroy (ball.gameObject);
			Instantiate (ballTemplate);
		}
	}
}
