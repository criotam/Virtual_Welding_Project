using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void StartScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
