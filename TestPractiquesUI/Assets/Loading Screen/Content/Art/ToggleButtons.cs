using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour {
    public List<Button> listButton;
    public Button currentButton;
    public Button startButton;
    public SpriteState sprState;  
    //public SpriteState SelectionState;

    // Use this for initialization
    void Start () {
        listButton.AddRange(GetComponentsInChildren<Button>());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)){
            SwitchActiveButton(listButton[2]);
        }
	}
    public void SwitchActiveButton(Button button)
    {
        if (button)
        {
            if (currentButton)
            {
                currentButton.spriteState = sprState; 
            }
            currentButton = button;
           
        }
    }
}
