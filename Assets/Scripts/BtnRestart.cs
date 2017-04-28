using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRestart : MonoBehaviour {

	public void Restart(){
		GameManager.Instance.restart ();
	}
}
