using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movement_base : MonoBehaviour {
	public  float vitesse;
	public float coeffPos = 0f;
	public Slider slide;
	public int wall=0;

	void OnTriggerEnter2D(Collider2D mur){
		if (mur.gameObject.name == "MurDroit")
			wall=1;
		if (mur.gameObject.name == "MurGauche")
			wall=2;
	}

	public bool isDashed = false;

	void Update (){
		if(Time.timeScale == 0)return;
		#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
		if (!isDashed && Input.GetKey ("left")&&(wall!=2)){
			gameObject.transform.Translate(new Vector3 (- vitesse, 0)*Time.deltaTime);
			wall=0;
		}

		if (!isDashed && Input.GetKey ("right")&&(wall!=1)){
			gameObject.transform.Translate(new Vector3 (vitesse, 0)*Time.deltaTime);
			wall=0;
		}
		#elif UNITY_ANDROID

		if (Input.touchCount > 0){
		float touchPos = Input.GetTouch(0).deltaPosition.x;
		if (!isDashed && (wall!=1 && wall != 2)){
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3 (touchPos, gameObject.transform.position.y), vitesse);
				wall=0;
			}
		}
		#endif
	}


	void Awake() { 


		#if !UNITY_ANDROID
		#else

		Input.multiTouchEnabled = true;
		StartCoroutine(MoveMobile());
		#endif

	}

	public bool isSlideTouched = false;

	private IEnumerator MoveMobile() {
		while (true) {
			if (isSlideTouched && (slide.value < 40f || slide.value > 60f)) {
				if (slide.value < 50f)
					coeffPos = -2f;
				else
					coeffPos = 2f;
				//coeffPos = (slide.normalizedValue - 0.5f)*2;
			} else
				coeffPos = 0f;
			yield return new WaitForSeconds (0.01f);	

		}
	}
}