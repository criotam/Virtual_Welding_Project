using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject Panel_1, Panel_2;

    void Start()
    {
        if (Panel_2 != null)
        {
            Panel_1.SetActive(true);
            Panel_2.SetActive(false);
        }
    }

	public void StartScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadPanel_2()
    {
        Panel_2.SetActive(true);
        Panel_1.SetActive(false);
    }

    public void LoadPanel_1()
    {
        Panel_1.SetActive(true);
        Panel_2.SetActive(false);
    }
}
