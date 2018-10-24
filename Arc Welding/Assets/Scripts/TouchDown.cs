using UnityEngine;

public class TouchDown : MonoBehaviour {
	public GameObject sparks;
	public GameObject beads;

    Controls control;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
    }

	void OnCollisionEnter(Collision obj){
        
        if (obj.gameObject.CompareTag("WP") && Controls.CurrentState == "CloseToTable")  {
            control.CHangeState(4);
            Debug.Log(Controls.CurrentState);
            sparks.SetActive (true);
		}

	}
	void OnCollisionStay(Collision obj){
		if (obj.gameObject.CompareTag("WP") && Controls.CurrentState == "Welding") {
			ContactPoint contact = obj.contacts [0];
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate (beads,pos,rot);
		}

	}
	void OnCollisionExit(Collision collision){
        
        if (Controls.CurrentState == "Welding")
        {
            control.CHangeState(3);
            Debug.Log(Controls.CurrentState);
            sparks.SetActive(false);
        }
	}
}
