using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public float Distance;
    public GameObject menu;
    bool MenuActive = false;
    string PreviousState;
    AudioSource Source;
    bool GameButton = false, HomeButton = false;
    Controls control;


    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Controls").GetComponent<Controls>();
        Source = GameObject.FindGameObjectWithTag("Controls").GetComponent<AudioSource>();
        GameButton = false;
        HomeButton = false;
        MenuActive = false;
        menu.SetActive(MenuActive);
    }

    void Update()
    {
        if (GameButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            ReturnToGame();
        }
        if (HomeButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            ReturnToMainMenu();
        }

        if (Controls.CurrentState != "Welding" && Controls.CurrentState != "CloseToTable")
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (MenuActive)
                {
                    MenuActive = false;
                    Controls.SwitchTo(PreviousState);
                    GameButton = false;
                    HomeButton = false;
                    control.GetComponent<BeadAnalysis>().AnalyseButton = false;

                    Debug.Log(Controls.CurrentState);
                }
                else
                {
                    MenuActive = true;
                    PreviousState = Controls.CurrentState;
                    Controls.SwitchToPauseMenu();
                    Debug.Log(Controls.CurrentState);
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

    public void OnHomeButtonEnter()
    {
        HomeButton = true;
    }
    public void OnHomeButtonexit()
    {
        HomeButton = false;
    }

    public void OnGameButtonEnter()
    {
        GameButton = true;
    }
    public void OnGameButtonExit()
    {
        GameButton = false;
    }

    void ReturnToGame()
    {
        MenuActive = false;
        Controls.SwitchTo(PreviousState);
        menu.SetActive(MenuActive);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
