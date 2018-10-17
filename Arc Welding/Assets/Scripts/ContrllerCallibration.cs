using UnityEngine;
using UnityEngine.UI;
public class ContrllerCallibration : MonoBehaviour {

    public Text txt;
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            txt.text = "Fire1";
        }
        else if (Input.GetButton("Fire2"))
        {
            txt.text = "Fire2";
        }
        else if (Input.GetButton("Horizontal"))
        {
            txt.text = "Horizontal";
        }
		else if (Input.GetButton("Vertical"))
        {
            txt.text = "vertical";
        }
        else if (Input.GetButton("Fire3"))
        {
            txt.text = "Fire3";
        }
        else if (Input.GetButton("Jump"))
        {
            txt.text = "Jump";
        }
        else if (Input.GetButton("Submit"))
        {
            txt.text = "Submit";
        }
        else if (Input.GetButton("Cancel"))
        {
            txt.text = "Cancel";
        }
	}
}
