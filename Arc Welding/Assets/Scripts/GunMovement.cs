using UnityEngine;

public class GunMovement : MonoBehaviour {

    //public Quaternion Rotation;
    //public Vector3 EulerAngles;
    //public float Distance;
    public Vector3 pos;
    public float speed = 1.0F;
    Controls control;
    bool pointingTo;
    bool GunWeilded = false;
    void Start()
    {
        pointingTo = false;
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
    }

	void Update () {

        //Rotation = this.transform.rotation;
        //EulerAngles = this.transform.localEulerAngles;
        //Distance = Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (Controls.CurrentState == "CloseToTable")
        {
            float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(translationX, translationY, 0);
        }
        
        if (pointingTo && Input.GetButtonDown("Fire1") && Controls.CurrentState == "HelmetOn")
        {
            GetComponentInChildren<BoxCollider>().enabled = false;
            control.CHangeState(2);
            Debug.Log(Controls.CurrentState);
            GunWeilded = true;
            pos = Camera.main.transform.position + new Vector3(0.2949999f, -0.3110024f, 0.3310001f);
            transform.position = new Vector3(pos.x,pos.y,pos.z);

        }
        if (Input.GetButtonDown("Fire2") && Controls.CurrentState == "GunEquipped")
        {
            GunWeilded = false;
            GetComponentInChildren<BoxCollider>().enabled = true;
            control.CHangeState(1);

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
}
