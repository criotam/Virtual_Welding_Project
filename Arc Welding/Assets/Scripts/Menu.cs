using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject Panel_1, Panel_2;
    AudioSource Source;

    bool WeldingButton = false, ControllerButton = false, QuitButton = false;
    bool ButtJointButton = false, CornerJointButton = false, LapJointButton = false, TJointButton = false;
    bool BackButton = false;

    void Start()
    {
        Source = GetComponentInParent<AudioSource>();
        WeldingButton = false; ControllerButton = false; QuitButton = false;
        ButtJointButton = false; CornerJointButton = false; LapJointButton = false; TJointButton = false;
        BackButton = false;

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
            Source.Play();
            LoadPanel_2();
        }
        else if (ControllerButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            StartScene(5);
        }
        else if (QuitButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            Quit();
        }
        else if (ButtJointButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            StartScene(1);
        }
        else if (CornerJointButton && Input.GetButtonDown("Fire1"))
        {
            StartScene(3);
        }
        else if (LapJointButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            StartScene(2);
        }
        else if (TJointButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            StartScene(4);
        }
        else if (BackButton && Input.GetButtonDown("Fire1"))
        {
            Source.Play();
            LoadPanel_1();
        }
    }

    public void OnWeldingButtonEnter()
    {
        WeldingButton = true;
    }
    public void OnWeldingButtonExit()
    {
        WeldingButton = false;
    }

    public void OnControllerEnter()
    {
        ControllerButton = true;
    }
    public void OnControllerExit()
    {
        ControllerButton = false;
    }

    public void OnQuitButtonEnter()
    {
        QuitButton = true;
    }
    public void OnQuitButtonExit()
    {
        QuitButton = false;
    }

    public void OnButtJointEnter()
    {
        ButtJointButton = true;
    }
    public void OnButtJointExit()
    {
        ButtJointButton = false;
    }

    public void OnCornerJointEnter()
    {
        CornerJointButton = true;
    }
    public void OnCornerJointExit()
    {
        CornerJointButton = false;
    }

    public void OnLapJointEnter()
    {
        LapJointButton = true;
    }
    public void OnLapJointExit()
    {
        LapJointButton = false;
    }

    public void OnTJointEnter()
    {
        TJointButton = true;
    }
    public void OnTJointExit()
    {
        TJointButton = false;
    }

    public void OnBackButtonEnter()
    {
        BackButton = true;
    }
    public void OnBackButtonExit()
    {
        BackButton = false;
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
