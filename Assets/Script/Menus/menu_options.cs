using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class menu_options : MonoBehaviour {

	public Dropdown son, bruit, langue;
	void Start(){
		langue.value = ConvertLanguage(PlayerPrefs.GetString("Option.Langue", "0"));
		try{
			bruit.value = int.Parse(PlayerPrefs.GetString("Option.Bruit", "3"));
			son.value = int.Parse(PlayerPrefs.GetString("Option.Son", "3"));
		}
		catch(Exception e) {

			Debug.Log (e);
			bruit.value = 3;
			son.value = 3;
		}
	}

	public void ChangeLanguage(){
		PlayerPrefs.SetString("Option.Langue", ConvertLanguage(langue.value));
		PlayerPrefs.Save ();
		GameObject.FindWithTag ("MainCamera").GetComponent<language_switch> ().ChangeDictionnaire ();
		GameObject.FindWithTag ("MainCamera").GetComponent<language_switch> ().ApplyDictionnaire ();
	}

	public void ChangeSound(){
		PlayerPrefs.SetString("Option.Son", son.value.ToString());
		PlayerPrefs.Save ();
		GameObject.FindWithTag ("MainCamera").GetComponent<sound_manager> ().ChangeVolume ();
		}
		
	public void ChangeNoise(){
		PlayerPrefs.SetString("Option.Bruit", bruit.value.ToString());
		PlayerPrefs.Save ();
	}

	public void ResetOptions() {
		langue.value = 0;
		bruit.value = 3;
		son.value = 3;

		PlayerPrefs.SetString ("Option.Son", son.value.ToString ());
		PlayerPrefs.SetString ("Option.Bruit", bruit.value.ToString ());
		PlayerPrefs.SetString ("Option.Langue", ConvertLanguage (langue.value));

		PlayerPrefs.Save ();
		GameObject.FindWithTag ("MainCamera").GetComponent<language_switch> ().ChangeDictionnaire ();
		GameObject.FindWithTag ("MainCamera").GetComponent<language_switch> ().ApplyDictionnaire ();
		GameObject.FindWithTag ("MainCamera").GetComponent<sound_manager> ().ChangeVolume ();

	}

	private int ConvertLanguage(string str){
		switch (str) {
		case "fr":
			return 0;
		default:
		case "en":
			return 1;
		case "es":
			return 2;
		}
	}
	private string ConvertLanguage(int i){
		switch (i) {
		case 0:
			return "fr";
		default:
		case 1:
			return "en";
		case 2:
			return "es";
		}
	}
}
