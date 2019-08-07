﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PipeMoveMent();
		if(BirdController.instance!=null){
			if(BirdController.instance.flag==1){
				Destroy(GetComponent<PipeController> ());
			}

		}
	}
	void PipeMoveMent(){
		Vector3 temp = transform.position;
		temp.x -= speed*Time.deltaTime;
		transform.position=temp;
	}
	void OnCollisionEnter2D(Collision2D target){
		
	}
	void OnTriggerEnter2D (Collider2D target){
		if(target.tag=="Destroy"){
			Destroy(gameObject);
		}	
	}
}
