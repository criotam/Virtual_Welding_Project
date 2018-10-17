using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour {
	public float speed = 1.0F;
	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(translationX ,translationY ,0);
	}
}
