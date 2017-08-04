using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour {
	public KeyCode key;
	private GameManager gm;
	Vector3 rotationEuler;
	private Vector3 v3T;
	private Vector3 v3Tsafe;
	private SpriteRenderer theSprite;


	// Use this for initialization
	void Start () {
		theSprite = GetComponent<SpriteRenderer> ();
		v3Tsafe = transform.localScale;
		gm = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key)) {
			//theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);

			v3T.x = transform.localScale.x * 1.2f;
			v3T.y = transform.localScale.y * 1.2f;
			transform.localScale = v3T;
			// RotateLeft ();
		}
		if (Input.GetKeyUp (key)) {
			v3T = v3Tsafe;
			transform.localScale = v3Tsafe;	
			gm.StartGame ();	
		}
	}
}
