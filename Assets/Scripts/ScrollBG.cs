using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour {

	private Renderer render;

	public float velocidadeX, velocidadeY;

	private float offsetX = 0, offsetY = 0;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.getPlayerVivo()){
			offsetX += velocidadeX;
			offsetY += velocidadeY;

			if (offsetX > 1) offsetX -= 1;
			if (offsetY > 1) offsetY -= 1;

			render.material.mainTextureOffset = new Vector2 (offsetX, offsetY);

		}
	}
}
