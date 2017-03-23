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

		if (Input.touchCount > 0 && !isDashed && (wall!=1 && wall != 2)) {
         // The screen has been touched so store the touch
         Touch touch = Input.GetTouch(0);

		Vector3 startPos = gameObject.transform.position;
         
         if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
             // If the finger is on the screen, move the object smoothly to the touch position
		Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));                
             transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime*1.5f);
         }
       	
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, startPos.y, startPos.z);
           		wall=0;
		}
		#endif
	}


	void Awake() { 


		#if !UNITY_ANDROID
		#else

		Input.multiTouchEnabled = true;
		#endif

	}
}