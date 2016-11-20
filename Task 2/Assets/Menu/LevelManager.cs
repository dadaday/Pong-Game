using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public Canvas QuitMenu;
	public Canvas StartMenu;

	void Start() {
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		StartMenu = StartMenu.GetComponent<Canvas> ();
	}

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}

	public void ExitPress() {
		QuitMenu.enabled = true;
		StartMenu.enabled = false;
	}

	public void ChooseNo() {
		QuitMenu.enabled = false;
		StartMenu.enabled = true;
	}

	public void ChooseYes() {
		Application.Quit ();
	}
}
