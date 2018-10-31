using UnityEngine;

public class GunMovement : MonoBehaviour {

    public GameObject GunPosition;
    public Vector3 pos;
    public float speed = 1.0F;
    public GameObject WeldingPosition;
    public float MovementDistance;

    bool pointingTo;
    bool GunWeilded = false;
    Vector3 inititalPosition;
    public GameObject Parent;
    void Start()
    {
        pointingTo = false;
        //transform.position = Parent.transform.position;
        Parent.transform.position = GunPosition.transform.position;
    }

	void Update () {

        if (GunWeilded)
        {
            float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPos = Parent.transform.position + new Vector3(translationX, 0, translationY);
            if (Vector3.Distance(newPos, WeldingPosition.transform.position) < MovementDistance)
                Parent.transform.position = newPos;
        }
        
        if (pointingTo && Input.GetButtonDown("Fire1") && Controls.CurrentState == "HelmetOn")
        {
            GetComponentInChildren<BoxCollider>().enabled = false;
            Controls.SwitchToGunEquipped();
            Debug.Log(Controls.CurrentState);
            GunWeilded = true;
            pos = Camera.main.transform.position + new Vector3(0.2949999f, -0.3110024f, 0.3310001f);
            Parent.transform.position = new Vector3(pos.x,pos.y,pos.z);
        }
        else if (Controls.CurrentState == "GunEquipped" && Input.GetButtonDown("Fire1"))
        {
            Parent.transform.position = WeldingPosition.transform.position;
            Controls.SwitchToCloseToTable();
            Debug.Log(Controls.CurrentState);
        }
        else if (Input.GetButtonDown("Fire3") && Controls.CurrentState == "CloseToTable")
        {
            Controls.SwitchToGunEquipped();
            Debug.Log(Controls.CurrentState);
            pos = Camera.main.transform.position + new Vector3(0.2949999f, -0.3110024f, 0.3310001f);
            Parent.transform.position = new Vector3(pos.x, pos.y, pos.z);
            inititalPosition = Parent.transform.position;
        }
        else if (Input.GetButtonDown("Fire3") && Controls.CurrentState == "GunEquipped")
        {
            GunWeilded = false;
            GetComponentInChildren<BoxCollider>().enabled = true;
            Controls.SwitchToHelmetOn();
            Parent.transform.position = GunPosition.transform.position;
            Debug.Log(Controls.CurrentState);
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
