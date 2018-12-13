using UnityEngine;

public class TouchDown : MonoBehaviour {
	public GameObject sparks;
	public GameObject beads;
    public Helmet hm;

    [SerializeField]
    GameObject[] ElectrodePositions;

    Collision co;
    Controls control;
    bool welding = false;
    int PosID;
    float timeLapse = 0f;

    AudioSource Source;

    void Start()
    {
        PosID = 0;
        Source = GetComponentInParent<AudioSource>();
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
            Source.Play();
            hm.ToggleView();

        }
        if (Controls.CurrentState == "CloseToTable" && Input.GetButtonDown("Jump"))
        {
            GetComponentInParent<AudioSource>().gameObject.transform.position = ElectrodePositions[(PosID + 1) % 2].transform.position;
            GetComponentInParent<AudioSource>().gameObject.transform.rotation = ElectrodePositions[(PosID + 1) % 2].transform.rotation;
            PosID = PosID + 1;
        }


        else if (Controls.CurrentState == "Welding" && Input.GetButtonUp("Fire1"))
        {
            sparks.SetActive(false);
            welding = false;
            Controls.SwitchToCloseToTable();
            Debug.Log(Controls.CurrentState);
            Source.Stop();
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
