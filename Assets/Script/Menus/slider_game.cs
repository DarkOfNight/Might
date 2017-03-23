using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slider_game : MonoBehaviour {

	GameObject vaisseau;
	Slider slide;

	void Start() {
		vaisseau = GameObject.FindGameObjectWithTag ("Player");
		slide = gameObject.GetComponent<Slider>();
		vaisseau.GetComponent<movement_base> ().slide = slide;
	}

	void SlideDetection(bool i) {
		vaisseau.GetComponent<movement_base> ().isSlideTouched = i;
	}

	public void Begin(){
		if (vaisseau != null && (slide.value >= 40f && slide.value <= 60f))
			SlideDetection (true);
	}

	public void End(){
		if (vaisseau != null) {
			SlideDetection (false);
			slide.value = 50f;
			vaisseau.GetComponent<movement_base> ().coeffPos = 0f;
		}
	}
}
