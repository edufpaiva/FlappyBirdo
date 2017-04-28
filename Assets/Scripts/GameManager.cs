using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public static GameManager Instance;

	private bool playerVivo =  true;
	private bool comecou =  false;
	public GameObject menuMorto;
	public GameObject pontuacao;
	private int pontos = 0;



	void Awake(){
		DontDestroyOnLoad (gameObject);
		if (Instance == null) {
			Instance = this;
		
		} else {
			Destroy (gameObject);
		}
		Debug.Log ("Awake");
	}
	void Start () {
		menuMorto = GameObject.FindGameObjectWithTag ("menuMorto");
		menuMorto.SetActive (false);
		Invoke ("Pause", 0.01f);

		Debug.Log ("START GAMEMANAGER");


	}

	void Update(){
		if(menuMorto == null){
			menuMorto = GameObject.FindGameObjectWithTag ("menuMorto");
			menuMorto.SetActive (false);

		}

		if (pontuacao == null) {
			pontuacao = GameObject.FindGameObjectWithTag ("Pontuacao");
		}
	}

	public void setPlayerVivo(bool vivo){
		playerVivo = vivo;
		if (!vivo) {
			menuMorto.SetActive (true);
			pontuacao.SetActive (false);

		}

	}

	public void setComecou(){
		comecou = true;
		Time.timeScale = 1;
	}


	public bool getPlayerVivo(){
		return playerVivo;
		
	}

	public void restart(){
		playerVivo = true;
		comecou = false;
		pontos = 0;

		SceneManager.LoadScene ("FlappyBird");

		Invoke ("Pause", 0.01f);
	
	}

	public int getPontos(){
		return pontos;

	}

	public void Pause(){
		Time.timeScale = 0f;
	}

	public void setPontos(){
		pontos++;
	}





}
