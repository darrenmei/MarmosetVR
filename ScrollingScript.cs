using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

	public GameObject player;
	public float speed;
	public int count;
	public float shift;

	// Use this for initialization
	void Start () {
		count = 0;
		speed = 10;
		//shift = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (count % 5 == 0) {
			speed = Random.value * 10;
			//shift = -shift;
		}
		transform.Translate(new Vector3(0,7,0) * Time.deltaTime);
		count++;
	}
}
