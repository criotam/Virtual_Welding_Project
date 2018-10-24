using UnityEngine;

public class Helmet : MonoBehaviour {
    //public Vector3 pos;
    //public Quaternion rot;
    //public float distance;
    public float Distance;
    Controls control;
    bool pointingTo;
    bool HelmetOn;
    void Start()
    {
        
        pointingTo = false;
        HelmetOn = false;
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
        //pos = this.transform.position;
        //rot = this.transform.rotation;
        //distance = Vector3.Distance(pos, GameObject.FindGameObjectWithTag("Player").transform.position);
    }

	void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Controls.CurrentState == "EmptyHand" && pointingTo == true)
        {
            control.CHangeState(1);
            Debug.Log(Controls.CurrentState);
            HelmetOn = true;
            gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
        }
        else if (Input.GetButtonDown("Fire3") && Controls.CurrentState == "HelmetOn")
        {
            control.CHangeState(0);
            HelmetOn = false;
            gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
        }
        if (HelmetOn)
        {
            this.transform.rotation = Camera.main.transform.rotation;
            this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Distance;
        }
    }

    void FixedUpdate()
    {
        //this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.1025671f;
        //pos = this.transform.position;
        //rot = this.transform.rotation;
        //distance = Vector3.Distance(pos, GameObject.FindGameObjectWithTag("Player").transform.position);
        
    }

    public void OnPointerEnter()
    {
        pointingTo = true;
    }
    public void OnPointerExit()
    {
        pointingTo = false;
    }

}
