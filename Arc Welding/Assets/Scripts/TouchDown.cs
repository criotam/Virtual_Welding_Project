using UnityEngine;

public class TouchDown : MonoBehaviour {
	public GameObject sparks;
	public GameObject beads;
    public Helmet hm;

    Collision co;
    Controls control;
    bool welding = false;
    void Update()
    {
        if (Controls.CurrentState == "CloseToTable" && Input.GetButtonDown("Fire1"))
        {
            sparks.SetActive(true);
            welding = true;
            Controls.SwitchToWelding();
            Debug.Log(Controls.CurrentState);
            hm.ToggleView();

        }
        else if (Controls.CurrentState == "Welding" && Input.GetButtonUp("Fire1"))
        {
            sparks.SetActive(false);
            welding = false;
            Controls.SwitchToCloseToTable();
            Debug.Log(Controls.CurrentState);
            hm.ToggleView();
        }
    }
    /*
	void OnCollisionEnter(Collision obj){
        
        if (obj.gameObject.CompareTag("WP") && Controls.CurrentState == "CloseToTable")  {
            Controls.SwitchToWelding();
            Debug.Log(Controls.CurrentState);
            sparks.SetActive (true);
		}
	}
    */
	void OnCollisionStay(Collision obj){
        //Debug.Log("Working");
		if (welding) {
            Debug.Log("double working");
			ContactPoint contact = obj.contacts [0];
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate (beads,pos,rot);
		}
	}
    /*
	void OnCollisionExit(Collision collision){
        
        if (Controls.CurrentState == "Welding")
        {
            Controls.SwitchToCloseToTable();
            Debug.Log(Controls.CurrentState);
            sparks.SetActive(false);
        }
	}
    */
}
