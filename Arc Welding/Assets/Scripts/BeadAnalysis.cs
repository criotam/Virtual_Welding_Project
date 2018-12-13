using System.Collections.Generic;
using UnityEngine;

public class BeadAnalysis : MonoBehaviour {

    List<Vector3> ElectrodePosition = new List<Vector3>();

    [SerializeField] GameObject GraphCanvas;
    [SerializeField] Report report;
    WindowGraph GraphWindow;
    public bool AnalyseButton = false;
    bool AnalysisDone = false;
    AudioSource Source;

    void Start()
    {
        Source = GameObject.FindGameObjectWithTag("Controls").GetComponent<AudioSource>();
        GraphWindow = GraphCanvas.GetComponentInChildren<WindowGraph>();
        GraphCanvas.transform.position = GraphCanvas.transform.position + new Vector3(0, -110, 0);
        report.transform.position = report.transform.position + new Vector3(0, -110, 0);
;    }
 
    void Update()
    {
        if (AnalyseButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            AnalyseSpeed();
        }

        //Debug.Log(ElectrodePosition.Count);
    }

    public void OnAnalyseButtonEnter()
    {
        AnalyseButton = true;
    }
    public void OnAnalyseButtonExit()
    {
        AnalyseButton = false;
    }

   

    public void AddToPositionList(Vector3 pos)
    {
        ElectrodePosition.Add(pos);
    }

    void AnalyseSpeed()
    {
        if (AnalysisDone)
            return;
        AnalysisDone = true;

        if (ElectrodePosition.Count < 1)
            return;
        List<float> speed = new List<float>();
        for (int i = 0; i<ElectrodePosition.Count-1;)
        {
            if (ElectrodePosition[i+1] != Vector3.zero)
            {
                speed.Add(1000*Mathf.Abs(ElectrodePosition[i].z - ElectrodePosition[i + 1].z));
                ++i;
            }
            else
                i = i + 2;

            if (i > 30)
                break;
        }
        for (int i = 0; i < speed.Count; ++i)
        {
            Debug.Log(speed[i]);
        }

        GraphWindow.ShowSpeedGraph(speed);
        report.ShowReport(speed, ElectrodePosition.Count);
        report.transform.position = report.transform.position + new Vector3(0, 110, 0);
        GraphCanvas.transform.position = GraphCanvas.transform.position + new Vector3(0, +110, 0);
    }

}
