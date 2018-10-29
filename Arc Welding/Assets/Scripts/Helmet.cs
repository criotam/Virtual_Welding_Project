using UnityEngine;

public class Helmet : MonoBehaviour {

    public GameObject HelmetPosition;
    public float Distance;
    Controls control;
    bool pointingTo;
    bool HelmetOn;
    void Start()
    {
        pointingTo = false;
        HelmetOn = false;
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
    }

	void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Controls.CurrentState == "EmptyHand" && pointingTo == true)
        {
            Controls.SwitchToHelmetOn();
            Debug.Log(Controls.CurrentState);
            HelmetOn = true;
            gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
        }
        else if (Input.GetButtonDown("Fire3") && Controls.CurrentState == "HelmetOn")
        {
            Controls.SwitchToEmptyhand();
            this.gameObject.transform.position = HelmetPosition.transform.position;
            this.gameObject.transform.rotation = HelmetPosition.transform.rotation;
            HelmetOn = false;
            gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
            Debug.Log(Controls.CurrentState);
        }
        if (HelmetOn)
        {
            this.transform.rotation = Camera.main.transform.rotation;
            this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Distance;
        }

    }

    public void OnPointerEnter()
    {
        pointingTo = true;
    }
    public void OnPointerExit()
    {
        pointingTo = false;
    }

    public void ToggleView()
    {
        MeshRenderer mr = GetComponentInChildren<BoxCollider>().gameObject.GetComponent<MeshRenderer>();
        if (mr.enabled == true)
            mr.enabled = false;
        else
            mr.enabled = true;
    }
}
