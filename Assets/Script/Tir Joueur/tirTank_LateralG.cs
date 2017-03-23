using UnityEngine;
using System.Collections;

public class tirTank_LateralG : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ennemi_base" || col.gameObject.tag == "hitbox_boss") {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x-0.2595f, gameObject.transform.position.y+1.5f);
	}
	

}
