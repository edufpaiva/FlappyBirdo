using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapTap : MonoBehaviour {
	bool transparente = false;
	// Use this for initialization
	void Start () {
		Invoke ("Pisca", 1);
		Debug.Log ("Start TAPTAP");
	}
	
	public void Delete(){
		Destroy (gameObject);

	}

	public void Comeca(){
		GameManager.Instance.setComecou ();
	}
	void Pisca(){
		if (transparente) {
			GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		} else {
			GetComponent<Image> ().color = new Color (1, 1, 1, 0);
		}

		transparente = !transparente;
		Debug.Log ("Start TAPTAP " + transparente);

		Invoke ("Pisca", 1);
	}
}
