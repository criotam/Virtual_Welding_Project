using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public float Distance;
    public GameObject menu;
    bool MenuActive = false;
    string PreviousState;

    void Start()
    {
        menu.SetActive(MenuActive);
    }

    void Update()
    {
        if (Controls.CurrentState != "Welding" && Controls.CurrentState != "CloseToTable")
        {
            if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump"))
            {
                if (MenuActive)
                {
                    MenuActive = false;
                    Controls.SwitchTo(PreviousState);
                }
                else
                {
                    MenuActive = true;
                    PreviousState = Controls.CurrentState;
                    Controls.SwitchToPauseMenu();
                }
                menu.SetActive(MenuActive);
            }
        }
        if (MenuActive)
        {
            menu.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y,0, Camera.main.transform.rotation.w);
            menu.transform.position = Camera.main.transform.position + new Vector3 (Camera.main.transform.forward.x,0,Camera.main.transform.forward.z )* Distance;
        }

    }

    public void ReturnToGame()
    {
        MenuActive = false;
        Controls.SwitchTo(PreviousState);
        menu.SetActive(MenuActive);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
