using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public SpriteRenderer[] colors;
	private int colorSelect;
	private int lives = 3;
	private int score;
	public Text scoreText;
	public Text livesText;
	public Text LevelText;
	public GameObject gameOverButton;
	public GameObject LevelButton;

	public bool levelInProgress;
	public Text gameOverText;
	public int level;

	public float stayLit;
	private float stayLitCounter;

	public float waitBetweenLights;
	private float waitBetweenCounter;

	private bool shouldBeLit;
	private bool shouldBeDark;

	public List<int> activeSequence;
	private int positionInSequence;

//	private ScoreController sc;

	// Use this for initialization
	void Start () {
//		sc = new ScoreController();
		score = 0;
		level = 1;
		lives = 3;
		scoreText.text = "Score: " + score;
		livesText.text = "Lives: " + lives;
		gameOverButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldBeLit) {
			stayLitCounter -= Time.deltaTime;
			levelInProgress = true;
		} 
		if( stayLitCounter < 0) {
			colors [activeSequence[positionInSequence]].color = new Color (colors [activeSequence[positionInSequence]].color.r, colors [activeSequence[positionInSequence]].color.g, colors [activeSequence[positionInSequence]].color.b, 0.5f);
			shouldBeLit = false;
			shouldBeDark = true;
			waitBetweenCounter = waitBetweenLights;
			positionInSequence++;
			levelInProgress = false;
		}

		if (shouldBeDark) {
			waitBetweenCounter -= Time.deltaTime;
			if (positionInSequence >= activeSequence.Count) {
				shouldBeDark = false;
				levelInProgress = false;
				LevelText.text = "Next Level!";

			} else {
				if (waitBetweenCounter < 0) {
//					colorSelect = Random.Range (0, colors.Length);
//					activeSequence.Add (colorSelect);
					colors [activeSequence[positionInSequence]].color = new Color (colors [activeSequence[positionInSequence]].color.r, colors [activeSequence[positionInSequence]].color.g, colors [activeSequence[positionInSequence]].color.b, 1f);
					stayLitCounter = stayLit;
					shouldBeLit = true;
					shouldBeDark = false;
				}
			}
			levelInProgress = false;
		}
		if(lives <= 0){
			gameOverText.text = "Restart Game";
			gameOverButton.SetActive (true);
//			SceneManager.LoadScene("Game");

		}

	}

	public void StartGame(){
		if (levelInProgress) {
			return;
		}
		levelInProgress = true;
		positionInSequence = 0;
		colorSelect = Random.Range (0, colors.Length);
		activeSequence.Add (colorSelect);
		colors [activeSequence[positionInSequence]].color = new Color (colors [activeSequence[positionInSequence]].color.r, colors [activeSequence[positionInSequence]].color.g, colors [activeSequence[positionInSequence]].color.b, 1f);
		stayLitCounter = stayLit;
		shouldBeLit = true;
		LevelText.text = "Level: " + level;
		stayLit = stayLit - 0.05f;
		level++;
	}

	public void ResetGame(){
		// this object was clicked - do something
		Destroy (this.gameObject);
		SceneManager.LoadScene("Game");
	} 
	public void ColorPressed(int whichButton){
		if (activeSequence[positionInSequence] == whichButton) {
//			sc.IncrementScore ();
			score++;
			scoreText.text = "Score: " + score;
			Debug.Log ("Score: " + score );
		} else {
			if (lives >= 1) {
				--lives;
			}
			livesText.text = "Lives: " + lives;
			Debug.Log("Lives " + lives);
			if(lives == 0){
				LevelText.text = "GAME OVER";
				LevelButton.SetActive(false);

			}
		}
	}
}
