using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public Text FirstPlayerScore;
	public Text SecondPlayerScore;

	public void ShowScore() {
		FirstPlayerScore.enabled = true;
		SecondPlayerScore.enabled = true;
	}
}
