using UnityEngine;

public class Controls : MonoBehaviour {

    public string[] States = { "EmptyHand", "HelmetOn", "GunEquipped", "CloseToTable", "Welding", "PauseMenu" };
    public static string CurrentState;
    public static int StateIndex;
    
	void Start () {
        StateIndex = 0;
        CurrentState = States[StateIndex];
	}
	
	void Update () {
		
	}
    public void ResetLevel()
    {
        CurrentState = States[0];
    }

    public void CHangeState(int index)
    {
        CurrentState = States[index];
    }
}
