using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu_pause : MonoBehaviour {

	public bool isPaused = false, isInstancied = false;
	public GameObject menuPause, menuPause_Principal, menuPause_Options, buttonReturn;


	void Update () {
		if (Input.GetKey ("escape"))
			StartCoroutine(SwitchPause ());
	}

	public void Retour_au_jeu () {
		StartCoroutine(SwitchPause ());
	}
	public void Options (bool goToOptions) {
		buttonReturn.SetActive (goToOptions);
		menuPause_Options.SetActive (goToOptions);
		menuPause_Principal.SetActive (!goToOptions);
	}

	private IEnumerator SwitchPause() {
		if (!isInstancied) {
			isInstancied = true;
			if (!isPaused)
				Time.timeScale = 0f;
			else
				Time.timeScale = 1f;
			isPaused = !isPaused;
			if (!isPaused)
				Options (isPaused);
			menuPause.SetActive (isPaused);


			float start = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup < start + 1f) {
				yield return null;
			}

			isInstancied = false;
		}

		yield return null;
	}
}
