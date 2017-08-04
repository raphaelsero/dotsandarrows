using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void resetGame(){
		// this object was clicked - do something
		Destroy (this.gameObject);
		SceneManager.LoadScene("Game");
	}   

}
