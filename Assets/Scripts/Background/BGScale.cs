using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Vector3 tempScale = transform.localScale;
		float height = sr.bounds.size.y;
		float width = sr.bounds.size.x;
		float workHeight = Camera.main.orthographicSize * 2f;
		float workWidth = workHeight * Screen.width / Screen.height;
		tempScale.y = workHeight / height;
		tempScale.x = workWidth / width;
		transform.localScale = tempScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
