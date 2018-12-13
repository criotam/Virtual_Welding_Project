using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Report : MonoBehaviour {

    [SerializeField]
    GameObject Username, Date, ExecutionTime, JointType, WeldingSpeed;

    public void ShowReport(List<float> valueList, float timetaken)
    {
        Text txt = Date.GetComponentInChildren<Text>();
        txt.text = DateTime.Today.ToString("dd-MM-yyyy") + "  " + DateTime.Now.ToString("HH:mm:ss");

        txt = Username.GetComponentInChildren<Text>();
        txt.text = TypingScript.username;

        txt = ExecutionTime.GetComponentInChildren<Text>();
        txt.text = timetaken.ToString() + " s";

        txt = JointType.GetComponentInChildren<Text>();
        string temp = "";
        if (SceneManager.GetActiveScene().buildIndex == 1)
            temp = "Butt Joint";
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            temp = "Corner Joint";
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            temp = "Lap Joint";
        else if (SceneManager.GetActiveScene().buildIndex == 4)
            temp = "T Joint";
        txt.text = temp;

        txt = WeldingSpeed.GetComponentInChildren<Text>();
        float avg = 0.0f;
        int outliers = 0;
        for (int i = 0; i < valueList.Count; ++i)
        { 
            if (i != valueList.Count - 1)
            {
                if (Mathf.Abs(valueList[i] - valueList[i + 1]) > 30 && valueList[i] > valueList[i+1])
                {
                    Debug.Log(outliers);
                    outliers++;
                    continue;
                }
            }
            avg += valueList[i];
            Debug.Log(valueList[i]);
        }
        avg = avg / (valueList.Count-outliers);
        txt.text = avg.ToString() + " mm\\s";

    }
}
