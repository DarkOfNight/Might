using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu_principal : MonoBehaviour {


	public GameObject menuPrincipal, menuOptions, menuCredits ,menuSelection;
	public GameObject retour, logo;

	public void ToSelection(bool isHardcore){
		if (isHardcore)
			PlayerPrefs.SetInt ("Play.Hardcore", 1);
		else 
			PlayerPrefs.SetInt ("Play.Hardcore", 0);
		PlayerPrefs.Save ();

		menuPrincipal.SetActive (false);
		menuSelection.SetActive (true);

		retour.SetActive (true);
		logo.SetActive (false);
	}
	public void ToOptions(){
		menuPrincipal.SetActive (false);
		menuOptions.SetActive (true);

		retour.SetActive (true);
	}
	public void ToCredits(){
		menuPrincipal.SetActive (false);
		menuCredits.SetActive (true);

		retour.SetActive (true);
	}
	public void ToPrincipal(){
		retour.SetActive (false);
		logo.SetActive (true);

		menuPrincipal.SetActive (true);
		menuSelection.SetActive (false);
		menuCredits.SetActive (false);
		menuSelection.SetActive (false);
		menuOptions.SetActive (false);
	}


	public void ToQuit(){
		Application.Quit ();
	}


}
