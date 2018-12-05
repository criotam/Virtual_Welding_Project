using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject Panel_1, Panel_2;

    bool WeldingButton = false, ControllerButton = false, QuitButton = false;
    bool ButtJointButton = false, CornerJointButton = false, LapJointButton = false, TJointButton = false;
    bool BackButton = false;

    void Start()
    {
        if (Panel_2 != null)
        {
            Panel_1.SetActive(true);
            Panel_2.SetActive(false);
        }
    }

    void Update()
    {
        if (WeldingButton && Input.GetButtonDown("Fire1"))
        {
            LoadPanel_2();
        }
        else if (ControllerButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(5);
        }
        else if (QuitButton && Input.GetButtonDown("FIre1"))
        {
            Quit();
        }
        else if (ButtJointButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(1);
        }
        else if (CornerJointButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(3);
        }
        else if (LapJointButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(2);
        }
        else if (TJointButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(4);
        }
        else if (BackButton && Input.GetButtonDown("Fire1"))
        {
            LoadPanel_2();
        }
    }

    public void OnWeldingButtonEnter()
    {
        if (WeldingButton)
            WeldingButton = false;
        else
            WeldingButton = true;
    }

    public void OnControllerEnter()
    {
        if (ControllerButton)
            ControllerButton = false;
        else
            ControllerButton = true;
    }

    public void OnQuitButtonEnter()
    {
        if (QuitButton)
            QuitButton = false;
        else
            QuitButton = true;
    }

    public void OnButtJointEnter()
    {
        if (ButtJointButton)
            ButtJointButton = false;
        else
            ButtJointButton = true;
    }

    public void OnCornerJointEnter()
    {
        if (CornerJointButton)
            CornerJointButton = false;
        else
            CornerJointButton = true;
    }
    public void OnLapJointEnter()
    {
        if (LapJointButton)
            LapJointButton = false;
        else
            LapJointButton = true;
    }

    public void OnTJointEnter()
    {
        if (TJointButton)
            TJointButton = false;
        else
            TJointButton = true;
    }

    public void OnBackButtonEnter()
    {
        if (BackButton)
            BackButton = false;
        else
            BackButton = true;
    }

	void StartScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    void Quit()
    {
        Application.Quit();
    }

    void LoadPanel_2()
    {
        Panel_2.SetActive(true);
        Panel_1.SetActive(false);
    }

    void LoadPanel_1()
    {
        Panel_1.SetActive(true);
        Panel_2.SetActive(false);
    }
}
