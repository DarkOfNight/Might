using UnityEngine;
using System.Collections;

public class GestionNiveau : MonoBehaviour
{

	public GameObject Scripts;

	public int level = 1, chapitre = 1, vague = 0;

	void Start () {
		//level = PlayerPrefs.GetInt ("Levels.CurrentLevel", -1);
		//chapitre = PlayerPrefs.GetInt ("Levels.CurrentChapitre", -1);
		Scripts.GetComponent<GestionGrille> ().Open(level, chapitre);
		StartCoroutine (NewVague ());
	}

	private IEnumerator NewVague(){
		yield return null;
		Scripts.GetComponent<GestionVague> ().InitVague (vague);
	}

	public void FinishVague(){
		vague++;
		if (vague < 30)
			StartCoroutine (NewVague());
		else
			StartCoroutine (Finish ());
	}

	private IEnumerator Finish(){

		yield return null;

		Debug.LogAssertion ("Finish");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


}

