using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDown : MonoBehaviour {
	public GameObject sparks;
	public GameObject beads;
	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.CompareTag("WP")) {
			sparks.SetActive (true);

		}

	}
	void OnCollisionStay(Collision obj){
		if (obj.gameObject.CompareTag("WP")) {
			ContactPoint contact = obj.contacts [0];
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate (beads,pos,rot);
		}

	}
	void OnCollisionExit(Collision collision){
		sparks.SetActive (false);

	}
}
