using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ControllerCalliborator : MonoBehaviour {

    public Button A, B, C, D;
    public Image img;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            A.GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetButton("Fire2"))
        {
            C.GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetButton("Fire3"))
        {
            D.GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetButton("Submit"))
        {
            //B.GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetButton("Jump"))
        {
            B.GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetButton("Cancel"))
        {
            //text.text = "Cancel";
        }
        else
        {
            A.GetComponent<Image>().color = Color.green;
            C.GetComponent<Image>().color = Color.green;
            D.GetComponent<Image>().color = Color.green;
            B.GetComponent<Image>().color = Color.green;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x !=0 || y!=0 )
        {
            img.color = Color.red;
        }
        else
            img.color = Color.green;
    }
    
    public void BackTOHome()
    {
        SceneManager.LoadScene(0);
    }
}
