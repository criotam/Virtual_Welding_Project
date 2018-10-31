using System.Collections;
using UnityEngine;

public class BeadAnalysis : MonoBehaviour {

    GameObject[] Beads;
    public float distance=0;

	public void Analyse()
    {
        Beads = GameObject.FindGameObjectsWithTag("Beads");
        Debug.Log(Beads.Length);
        StartCoroutine(Calculate());
        

    }

    IEnumerator Calculate()
    {
        for (int i = 0; i<Beads.Length-1; ++i)
        {
            float d = Vector3.Distance(Beads[i].transform.position, Beads[i + 1].transform.position);
            if (d > distance)
                distance = d;
            yield return new WaitForEndOfFrame();
        }
        
    }

}
