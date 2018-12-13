using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TypingScript : MonoBehaviour {

	private static int changeCase = 0;
    public static string username = "USERNAME";
    public static int length;
    GameObject Screen;
    bool ButtonActive = false;

    public void Start()
    {
        length = 8;
        Screen = GameObject.FindGameObjectWithTag("Screen");
        Screen.GetComponentInChildren<Text>().text = username;
        this.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { OnPointerEnter(); });
        GetComponent<EventTrigger>().triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((eventData) => { OnPointerExit(); });
        GetComponent<EventTrigger>().triggers.Add(entry);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ButtonActive)
        {
            if (this.gameObject.name == "del")
            {
                Screen.GetComponentInChildren<Text>().text = "";
                ChangeUserName("");
            }
            else
                change();
        }
    }

    public void OnPointerEnter()
    {
        ButtonActive = true;
    }
    public void OnPointerExit()
    {
        ButtonActive = false;
    }

	void change()
    {

		string screenText;
        Text tx = Screen.GetComponentInChildren<Text>();
		screenText = tx.text;
        if (screenText.Length >= length)
            return;
		screenText = screenText + this.gameObject.name;
        tx.text = screenText;
        ChangeUserName(tx.text);

    }

    public static void ChangeUserName(string txt)
    {
        username = txt;
    }
}
