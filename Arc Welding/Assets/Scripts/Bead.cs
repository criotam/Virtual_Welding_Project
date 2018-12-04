using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour {

    bool welding = false;

	void Start () {
        GetComponent<MeshRenderer>().enabled = false;
	}
	
    void Update()
    {
        if (Controls.CurrentState == "Welding")
        {
            welding = true;
        }
        else
            welding = false;
    }

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Collision has happened");
        if (obj.gameObject.tag == "ElectrodeTip" && welding)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
	
}
