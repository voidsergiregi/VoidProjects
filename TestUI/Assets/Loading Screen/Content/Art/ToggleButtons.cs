using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour {
    public List<Button> listButton = new List<Button>();
    public Button currentSelectedButton;
    public Button startButton;
    public SpriteState sprState;
    public EventSystem eventSystem;
    public int currentSelectedIndex;

    //public SpriteState SelectionState;

    // Use this for initialization
    void Start () {
        listButton.AddRange(GetComponentsInChildren<Button>());
        currentSelectedIndex = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchActiveButton(listButton[2]);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchActiveButton();
        }
    }
    public void SwitchActiveButton(Button button)
    {
        if (button)
        {
            currentSelectedButton = button;
            eventSystem.SetSelectedGameObject(button.gameObject);
  
        }
    }
    public void SwitchActiveButton()
    {
        if (currentSelectedIndex >= listButton.Count-1)
            currentSelectedIndex = 0;
        else
         currentSelectedIndex++;
        SwitchActiveButton(listButton[currentSelectedIndex]);
    }

}
