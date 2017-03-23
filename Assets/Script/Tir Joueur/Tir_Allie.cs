using UnityEngine;
using System.Collections;

public class Tir_Allie : MonoBehaviour {

	public GameObject TirLTank;
	public GameObject TirCentralMight, TirCentralSnipe, TirCentralTank, TirPulse, MegaPulse, TirTrueMight ;

	public AudioClip SonMight, SonSnipe, SonTankCentral, SonTankL, SonPulse;
	private AudioSource src;

	public int passifmight=0;

	public float TirLatenceMight = 0.25f, TirLatenceSnipe = 0.6f, TirLatenceTank_Lateral = 0.5f, TirLatenceTank_Central = 3f, TirLatencePulse = 0.28f;

	void Awake () {

		src = GetComponent<AudioSource>();

	}


	void Start() {
		StartCoroutine ("GestionTir"+PlayerPrefs.GetString("Play.VaisseauID", "0"));
		if (PlayerPrefs.GetString("Play.VaisseauID", "0") == "2") //if Tank
			StartCoroutine ("GestionTir"+PlayerPrefs.GetString("Play.VaisseauID", "0")+"Lateral");
	}

	private IEnumerator GestionTir0() { // Defaut : Might
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				if (passifmight > 0) {
					Instantiate (TirTrueMight, new Vector3 (gameObject.transform.position.x - 4.5f, gameObject.transform.position.y + 8f), new Quaternion (0, 0, 0, 0));
					Instantiate (TirTrueMight, new Vector3 (gameObject.transform.position.x + 4.5f, gameObject.transform.position.y + 8f), new Quaternion (0, 0, 0, 0));
					src.PlayOneShot (SonMight, 0.5f);
					passifmight -= 1;
					yield return new WaitForSeconds (TirLatenceMight);
				}
				else {
					Instantiate (TirCentralMight, new Vector3 (gameObject.transform.position.x - 4.5f, gameObject.transform.position.y + 8f), new Quaternion (0, 0, 0, 0));
					Instantiate (TirCentralMight, new Vector3 (gameObject.transform.position.x + 4.5f, gameObject.transform.position.y + 8f), new Quaternion (0, 0, 0, 0));
					src.PlayOneShot (SonMight, 0.3f);
					yield return new WaitForSeconds (TirLatenceMight);
				}
			}
			else
				yield return new WaitForSeconds(0.0001f);

		}
	}

	private IEnumerator GestionTir1() { // Defaut : Snipe
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				Instantiate (TirCentralSnipe, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
				src.PlayOneShot (SonSnipe, 0.3f);
				yield return new WaitForSeconds (TirLatenceSnipe);
			}
			else
				yield return new WaitForSeconds(0.0001f);
		}
	}

	private IEnumerator GestionTir2() { // Defaut : Tank
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				Instantiate (TirCentralTank, new Vector3 (gameObject.transform.position.x, 55f), new Quaternion (0, 0, 0, 0));
				src.PlayOneShot (SonTankCentral, 0.6f);
				yield return new WaitForSeconds (TirLatenceTank_Central);
			}
			else
				yield return new WaitForSeconds(0.0001f);
		}
	}

	private IEnumerator GestionTir2Lateral() { // Defaut : Tank
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				var x = (GameObject)Instantiate (TirLTank, new Vector3 (gameObject.transform.position.x-4f, gameObject.transform.position.y), new Quaternion(0, 0, 0, 0));
				x.AddComponent<tirTank_LateralG>();
				x.transform.Rotate(0, 0, 2f);
				var y = (GameObject)Instantiate (TirLTank, new Vector3 (gameObject.transform.position.x+4f, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
				y.AddComponent<tirTank_LateralD>();
				x.transform.Rotate(0, 0, -2f);
				src.PlayOneShot (SonTankL, 0.3f);
				yield return new WaitForSeconds (TirLatenceTank_Lateral);
			}
			else
				yield return new WaitForSeconds(0.0001f);
		}
	}

	private IEnumerator GestionTir3(){ // Defaut : Pulse
		int CompteTir = 0;
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				if (CompteTir < 4) {
					CompteTir += 1;
					Instantiate (TirPulse, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 4f), new Quaternion (0, 0, 0, 0));
				} 
				else {
					CompteTir = 0;
					Instantiate (MegaPulse, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 4f), new Quaternion (0, 0, 0, 0));
				}
				src.PlayOneShot (SonPulse, 0.1f);
				yield return new WaitForSeconds (TirLatencePulse);
			} else
				yield return new WaitForSeconds (0.0001f);
		}
	}

}
