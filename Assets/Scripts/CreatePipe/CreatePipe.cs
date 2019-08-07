using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour {
	[SerializeField]
	
	private GameObject PipeHolder;

	// Use this for initialization
	void Start () {
		StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	IEnumerator Spawner(){
		yield return new WaitForSeconds(1);
		Vector3 temp = PipeHolder.transform.position;
		temp.y = Random.Range(-1.5f, 1.5f);
		Instantiate(PipeHolder,temp, Quaternion.identity);
		StartCoroutine(Spawner());
	}
}
