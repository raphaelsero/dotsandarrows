using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	private SpriteRenderer theSprite;

	public int thisButtonNumber;
	private GameManager gm;

	public KeyCode key;
	Vector3 rotationEuler;
	public int counter = 0;
	private Vector3 v3T;
	private Vector3 v3Tsafe;



	// Use this for initialization
	void Start () {
		theSprite = GetComponent<SpriteRenderer> ();
		v3Tsafe = transform.localScale;
		gm = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		// rotationEuler+= Vector3.up*250*Time.deltaTime; //increment 30 degrees every second
		// transform.rotation = Quaternion.Euler(rotationEuler);
		counter = 0;
		if (Input.GetKeyDown (key)) {
			//theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);

			v3T.x = transform.localScale.x * 1.3f;
			v3T.y = transform.localScale.y * 1.3f;
			transform.localScale = v3T;
		// RotateLeft ();
		}
		if (Input.GetKeyUp (key) && counter == 0) {
			counter++;
			theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.3f);
			v3T = v3Tsafe;
			transform.localScale = v3Tsafe;	
			gm.ColorPressed (thisButtonNumber);
		}
	}

	void RotateLeft () {
		transform.Rotate (Vector3.forward * -90);
	}

	public void OnMouseDown(){
		theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
	}

	public void OnMouseUp(){
		theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.3f);	
	}

}
