using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jump;
    public float velocidadeMaxima;
	public float giro = 2;
    public Animator anim;
    private Rigidbody2D playerRB;
	private Vector3 d = new Vector3(0, 0, -30);

	private bool isDead = false;

	public AudioSource fly;
	public AudioSource coin;
	public AudioSource morte;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 angulos = new Vector3 (0, 0, Mathf.Clamp (playerRB.velocity.y * giro, -180, 35));
		transform.eulerAngles = angulos;

		if (isDead) return;

		if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().AddForce(jump * Vector2.up);
            anim.SetTrigger("Fly");
			fly.Play();

        }



        Brake();
        
	}

    void Brake() {
        if(playerRB.velocity.magnitude > velocidadeMaxima) {
            playerRB.velocity = playerRB.velocity.normalized * velocidadeMaxima;
        }

        

    }

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Ponto") {
			coin.Play ();
			GameManager.Instance.setPontos ();
		}

	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Death"){
			isDead = true;
			morte.Play ();
			GameManager.Instance.setPlayerVivo (false);
		}
	}
}
