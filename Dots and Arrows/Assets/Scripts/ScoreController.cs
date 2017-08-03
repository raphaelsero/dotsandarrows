using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	public int score;
	public string scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementScore(){
		score++;
		scoreText = "Score: " + score;
		Debug.Log ("Score: " + score );
	}
}
