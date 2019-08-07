using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
	public static BirdController instance;
	public float bounceForce;
	public float flag =0;
	private GameObject createPipe;
	private Rigidbody2D myBody;
	private Animator anim;

	//AUDIO

	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip flyClip, pingClip, dieClip;

	private bool isAlive;
	private bool didFlap;
	// Use this for initialization
	void Awake () {
		isAlive = true;
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		MakeInstance();
		createPipe = GameObject.Find("CreatePipe");
	}
	void MakeInstance(){
		if(instance==null){
			instance=this;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		BirdMoveMent();
	}
	void BirdMoveMent(){
		if(isAlive){
			if(didFlap){
				didFlap=false;
				myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
				audioSource.PlayOneShot(flyClip);
			}
		}

		if(myBody.velocity.y>0){
			float angel =0;
			angel = Mathf.Lerp(0,90,myBody.velocity.y/7);
			transform.rotation = Quaternion.Euler(0,0,angel);
		}
		else if(myBody.velocity.y==0){
			float angel =0;
			angel = Mathf.Lerp(0,0,0);
			transform.rotation = Quaternion.Euler(0,0,angel);
		}
		if(myBody.velocity.y<0){
			float angel =0;
			angel = Mathf.Lerp(0,-90,-myBody.velocity.y/7);
			transform.rotation = Quaternion.Euler(0,0,angel);
		}
	}
	public void FlapButton(){
		didFlap=true;
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "PipeHolder"){
			audioSource.PlayOneShot(pingClip);
		}

	}
	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground"){
			flag = 1;
			Destroy(createPipe);
			audioSource.PlayOneShot(dieClip);
			anim.SetTrigger("Die");
		}
	}
}
