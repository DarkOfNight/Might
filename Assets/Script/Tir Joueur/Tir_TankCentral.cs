using UnityEngine;
using System.Collections;

public class Tir_TankCentral : MonoBehaviour {

	void Start () {	StartCoroutine (WaitForDestroy ());
		StartCoroutine(fade());
		}

	private IEnumerator WaitForDestroy () {
		yield return new WaitForSeconds (0.35f);
		Destroy (gameObject);
	}
	private IEnumerator fade(){
		for (int i = 0; i < 11; i++) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 0.8f, i / 10f);
			yield return new WaitForSeconds(0.015f);
		}
	}
}
