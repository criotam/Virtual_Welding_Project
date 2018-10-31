using UnityEngine;

public class Controls : MonoBehaviour {

    public static string[] States = { "EmptyHand", "HelmetOn", "GunEquipped", "CloseToTable", "Welding", "PauseMenu" };
    public static string CurrentState
    {
        get;
        private set;
    }
    
	void Start () {
        CurrentState = "EmptyHand";
	}
	
	void Update () {
		
	}
    
    public static void SwitchTo(string s)
    {
        for (int i = 0; i<States.Length; ++i)
        {
            if (s == States[i])
            {
                CurrentState = s;
            }
        }
    }

    public static void ResetLevel()
    {
        CurrentState = "EmptyHand";
    }
    public static void SwitchToEmptyhand()
    {
        CurrentState = "EmptyHand";
    }
    public static void SwitchToHelmetOn()
    {
        CurrentState = "HelmetOn";
    }
    public static void SwitchToGunEquipped()
    {
        CurrentState = "GunEquipped";
    }
    public static void SwitchToCloseToTable()
    {
        CurrentState = "CloseToTable";
    }
    public static void SwitchToWelding()
    {
        CurrentState = "Welding";
    }
    public static void SwitchToPauseMenu()
    {
        CurrentState = "PauseMenu";
    }

}
