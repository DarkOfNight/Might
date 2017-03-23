using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {

	public Text[] menuChargement;

	public void ToDemo()
	{
		Switch();
		SceneManager.LoadScene (1);
	}
	public void ToMain()
	{
		Switch();
		SceneManager.LoadScene (0);
	}
	public void ToReplay()
	{
		Switch();
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	void Switch() {
		Time.timeScale = 1f;
		for (int i = 0; i < menuChargement.Length; i++)
			if (menuChargement [i] != null) {
				menuChargement [i].text = PlayerPrefs.GetString ("Langue.MenuChargement_" + i);
				menuChargement [i].fontSize = 30;
			}
	}
}
