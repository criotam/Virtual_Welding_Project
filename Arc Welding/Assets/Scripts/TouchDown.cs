using UnityEngine;

public class TouchDown : MonoBehaviour {
	public GameObject sparks;
	public GameObject beads;
    public Helmet hm;

    Collision co;
    Controls control;
    bool welding = false;

    float timeLapse = 0f;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
    }

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
            control.GetComponent<BeadAnalysis>().AddToPositionList(new Vector3(0, 0, 0));
        }

        if (Controls.CurrentState == "Welding" && Input.GetButton("Fire1")){
            if (timeLapse < 1)
            {
                timeLapse += Time.deltaTime;
            }
            else
            {
                timeLapse = 0f;
                control.GetComponent<BeadAnalysis>().AddToPositionList(
                    GetComponent<GunMovement>().Parent.transform.position);
            }
        }
    }

}
