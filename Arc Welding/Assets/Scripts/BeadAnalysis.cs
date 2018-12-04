using System.Collections.Generic;
using UnityEngine;

public class BeadAnalysis : MonoBehaviour {

    List<Vector3> ElectrodePosition = new List<Vector3>();

    [SerializeField] GameObject GraphCanvas;

    WindowGraph GraphWindow;

    void Start()
    {
        GraphWindow = GraphCanvas.GetComponentInChildren<WindowGraph>();
        GraphCanvas.transform.position = GraphCanvas.transform.position + new Vector3(0, -110, 0);
    }
 
    void Update()
    {
        Debug.Log(ElectrodePosition.Count);
    }

    public void AddToPositionList(Vector3 pos)
    {
        ElectrodePosition.Add(pos);
    }

    public void AnalyseSpeed()
    {
        if (ElectrodePosition.Count < 1)
            return;
        List<float> speed = new List<float>();
        for (int i = 0; i<ElectrodePosition.Count-1; ++i)
        {
            while (ElectrodePosition[i+1] != Vector3.zero)
            {
                speed.Add(1000*Mathf.Abs(ElectrodePosition[i].z - ElectrodePosition[i + 1].z));
                i++;
            }
            i = i + 1;
        }
        for (int i = 0; i < speed.Count; ++i)
        {
            Debug.Log(speed[i]);
        }

        GraphWindow.ShowSpeedGraph(speed);
        GraphCanvas.transform.position = GraphCanvas.transform.position + new Vector3(0, +110, 0);
    }

}
