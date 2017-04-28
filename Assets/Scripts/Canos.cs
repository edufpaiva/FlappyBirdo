using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canos : MonoBehaviour {
	public float velocidade = 5;
	public float tempoDestroi = 7;
	public float tempoConstroi = 3;
	public GameObject canos;
	public float limiteCima = 2;
	public float limiteBaixo = -2;

	public ParticleSystem[] particulas;
	// Use this for initialization
	void Start () {
		Invoke ("Constroi", tempoConstroi);
		Destroy (gameObject, tempoDestroi);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.getPlayerVivo ()) {
			transform.Translate (Vector2.left * velocidade * Time.deltaTime);
		
		} else {
			
			for(int i = 0; i < particulas.Length; i++){
				particulas [i].Play ();

			}
			Destroy (gameObject);
		}



	}


	void Constroi(){
		float range = Random.Range (limiteBaixo, limiteCima);

		Instantiate (canos, new Vector2 (9, range), Quaternion.identity);
	
	}
}
