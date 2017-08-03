using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public SpriteRenderer[] colors;
	private int colorSelect;
	private int lives = 3;
	private int score;
	public Text scoreText;
	public Text livesText;

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
		scoreText.text = "Score: 0";
		livesText.text = "Lives: 3";
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldBeLit) {
			stayLitCounter -= Time.deltaTime;
		} 
		if( stayLitCounter < 0) {
			colors [activeSequence[positionInSequence]].color = new Color (colors [activeSequence[positionInSequence]].color.r, colors [activeSequence[positionInSequence]].color.g, colors [activeSequence[positionInSequence]].color.b, 0.5f);
			shouldBeLit = false;
			shouldBeDark = true;
			waitBetweenCounter = waitBetweenLights;
			positionInSequence++;

		}

		if (shouldBeDark) {
			waitBetweenCounter -= Time.deltaTime;
			if (positionInSequence >= activeSequence.Count) {
				shouldBeDark = false;
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
		}
	}

	public void StartGame(){
		positionInSequence = 0;
		colorSelect = Random.Range (0, colors.Length);
		activeSequence.Add (colorSelect);
		colors [activeSequence[positionInSequence]].color = new Color (colors [activeSequence[positionInSequence]].color.r, colors [activeSequence[positionInSequence]].color.g, colors [activeSequence[positionInSequence]].color.b, 1f);
		stayLitCounter = stayLit;
		shouldBeLit = true;
	}

	public void ColorPressed(int whichButton){
		if (activeSequence[positionInSequence] == whichButton) {
//			sc.IncrementScore ();
			score++;
			scoreText.text = "Score: " + score;
			Debug.Log ("Score: " + score );

		} else {
			--lives;
			livesText.text = "Lives " + lives;
			Debug.Log("Lives " + lives);

		}
	}
}
