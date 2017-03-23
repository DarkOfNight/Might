using UnityEngine;
using System.Collections;

public class sound_manager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		ChangeVolume ();
	}
	public void ChangeVolume() { 
		if (gameObject.tag == "MainCamera")
			gameObject.GetComponent<AudioSource>().volume = float.Parse (PlayerPrefs.GetString ("Option.Son", "3")) * 0.2F;
		else
			gameObject.GetComponent<AudioSource>().volume = float.Parse (PlayerPrefs.GetString ("Option.Bruit", "3")) * 0.2F;
	}
}
