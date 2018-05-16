using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GestionNiveau : MonoBehaviour
{

	public ConstructeurEnnemi constructeurEnnemi;
	public SystemLevel constructeurLevel;
	public int level = 1, chapitre = 1;

	void Start () {
		constructeurLevel = new SystemLevel(constructeurEnnemi, PlayerPrefs.GetInt ("Levels.CurrentLevel", level), PlayerPrefs.GetInt ("Levels.CurrentChapitre", chapitre));
		StartCoroutine (LaunchLevel());
	}

	public void EnnemyDestroyed (int x, int y)
	{
		StartCoroutine(constructeurLevel.EnnemyDestroyed (x, y));
	}

	private IEnumerator LaunchLevel(){
		bool finished = false;
		constructeurLevel.New ();
		while (!finished) {
			yield return new WaitForSeconds(1);
			if (constructeurLevel.VagueFinished ()) {
				if (constructeurLevel.currentVague < (constructeurLevel.vague - 1))
					constructeurLevel.New ();
				else {
					constructeurLevel.Stop ();
					finished = true;
				}
			}
		}
		Finish ();
	}

	private void Finish(){
		Debug.LogWarning("Finish!!!");
	}
	/////
	/// 

}

