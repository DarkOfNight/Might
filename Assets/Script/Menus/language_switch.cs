using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class language_switch : MonoBehaviour {

	public Text[] menuOption, menuPrincipal, menuPause, menuSelection, menuCredit;
	string[,] language = new string[3, 15];

	void Awake(){
		ChangeDictionnaire ();
		ApplyDictionnaire ();
	}


	void InitDictionnaire () {
		// FR, EN, ES

		// Menu_Princ.Unity  -- Principal
		language [0, 0] = "Jouer";
		language [1, 0] = "Play";
		language [2, 0] = "Jugar";

		language [0, 1] = "Hardcore";
		language [1, 1] = "Hardcore";
		language [2, 1] = "Hardcore";

		language [0, 2] = "Options";
		language [1, 2] = "Options";
		language [2, 2] = "Opción";

		language [0, 3] = "Crédits";
		language [1, 3] = "Credits";
		language [2, 3] = "Crédito";


		// Menu_Princ.Unity  -- Options
		language [0, 4] = "Son";
		language [1, 4] = "Sound";
		language [2, 4] = "Sonido";

		language [0, 5] = "Bruit";
		language [1, 5] = "Noise";
		language [2, 5] = "Ruido";

		language [0, 6] = "Langue";
		language [1, 6] = "Language";
		language [2, 6] = "Idioma";

		language [0, 7] = "Réinitialiser";
		language [1, 7] = "Reinit";
		language [2, 7] = "Reinicializar";


		// Menu_Princ.Unity  -- Sélection
		language [0, 8] = "Choix du vaisseau";
		language [1, 8] = "Selection of the Ship";
		language [2, 8] = "Seleccionar una nave";

		language [0, 9] = "Force";
		language [1, 9] = "Power";
		language [2, 9] = "Fuerza";

		language [0, 10] = "Vitesse";
		language [1, 10] = "Speed";
		language [2, 10] = "Velocidad";

		language [0, 11] = "Latence";
		language [1, 11] = "Latency";
		language [2, 11] = "Latencia";



		// Demo.Unity  -- Pause
		language [0, 12] = "Reprendre le jeu";
		language [1, 12] = "Resume";
		language [2, 12] = "Retomar";

		language [0, 13] = "Rejouer le niveau";
		language [1, 13] = "Replay";
		language [2, 13] = "Repetir";

		language [0, 14] = "Quitter";
		language [1, 14] = "Quit";
		language [2, 14] = "Abandonar";
			
	}


	public void ChangeDictionnaire () {
		if (language[0, 0] == null || language[0, 0] == "")
			InitDictionnaire ();

		int langueID = ConvertLanguage(PlayerPrefs.GetString ("Option.Langue", "0"));

		PlayerPrefs.SetString ("Option.Langue", ConvertLanguage (langueID));

		PlayerPrefs.SetString("Langue.MenuPrincipal_0", language[langueID, 0]);
		PlayerPrefs.SetString("Langue.MenuPrincipal_1", language[langueID, 1]);
		PlayerPrefs.SetString("Langue.MenuPrincipal_2", language[langueID, 2]);
		PlayerPrefs.SetString("Langue.MenuPrincipal_3", language[langueID, 3]);

		PlayerPrefs.SetString("Langue.MenuOption_0", language[langueID, 2]);
		PlayerPrefs.SetString("Langue.MenuOption_1", language[langueID, 4]);
		PlayerPrefs.SetString("Langue.MenuOption_2", language[langueID, 5]);
		PlayerPrefs.SetString("Langue.MenuOption_3", language[langueID, 6]);
		PlayerPrefs.SetString("Langue.MenuOption_4", language[langueID, 7]);

		PlayerPrefs.SetString("Langue.MenuCredit_0", language[langueID, 3]);

		PlayerPrefs.SetString("Langue.MenuSelection_0", language[langueID, 8]);
		PlayerPrefs.SetString("Langue.MenuSelection_1", language[langueID, 0]);
		PlayerPrefs.SetString("Langue.MenuSelection_2", language[langueID, 9]);
		PlayerPrefs.SetString("Langue.MenuSelection_3", language[langueID, 10]);
		PlayerPrefs.SetString("Langue.MenuSelection_4", language[langueID, 11]);

		PlayerPrefs.SetString("Langue.MenuPause_0", language[langueID, 12]);
		PlayerPrefs.SetString("Langue.MenuPause_1", language[langueID, 13]);
		PlayerPrefs.SetString("Langue.MenuPause_2", language[langueID, 2]);
		PlayerPrefs.SetString("Langue.MenuPause_3", language[langueID, 14]);

		PlayerPrefs.Save ();
	}

	public void ApplyDictionnaire () {
		if (language [0, 0] == null || language [0, 0] == "")
			ChangeDictionnaire ();

		for (int i = 0; i < menuOption.Length; i++)
			if (menuOption [i] != null)
				menuOption [i].text = PlayerPrefs.GetString ("Langue.MenuOption_" + i);
		for (int i = 0; i < menuPrincipal.Length; i++)
			if (menuPrincipal [i] != null)
				menuPrincipal [i].text = PlayerPrefs.GetString ("Langue.MenuPrincipal_" + i);
		for (int i = 0; i < menuPause.Length; i++)
			if (menuPause [i] != null)
				menuPause [i].text = PlayerPrefs.GetString ("Langue.MenuPause_" + i);
		for (int i = 0; i < menuSelection.Length; i++)
			if (menuSelection [i] != null)
				menuSelection [i].text = PlayerPrefs.GetString ("Langue.MenuSelection_" + i);
		for (int i = 0; i < menuCredit.Length; i++)
			if (menuCredit [i] != null)
				menuCredit [i].text = PlayerPrefs.GetString ("Langue.MenuCredit_" + i);
	}

	private int ConvertLanguage(string str){
		switch (str) {
		default:
		case "fr":
			return 0;
		case "en":
			return 1;
		case "es":
			return 2;
		}
	}
	private string ConvertLanguage(int i){
		switch (i) {
		default:
		case 0:
			return "fr";
		case 1:
			return "en";
		case 2:
			return "es";
		}
	}
}
