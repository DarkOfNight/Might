using UnityEngine;
using System.Collections;

public class tirTank_Lateral : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ennemi_base" || col.gameObject.tag == "hitbox_boss") {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate(new Vector3 (0,130f,0)*Time.deltaTime);
	}
}
