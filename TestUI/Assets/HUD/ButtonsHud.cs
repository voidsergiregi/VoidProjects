using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonsHud : MonoBehaviour {
    #region Variables
    public List<Button> listButtons;
    public bool isCoolDown;
    #endregion
    #region Unity Methods
    // Use this for initialization
    void Start () {
        listButtons.AddRange(GetComponentsInChildren<Button>());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V)){
            ShowHideButton(listButtons[1]);
        }
	}
    
    #endregion
    #region Helpers Methods
    public void FuntionButton1(Button button)
    {
        GenericButton(button);
    }
    public void FuntionButton2(Button button)
    {
        GenericButton(button); 
    }
    public void FuntionButton3(Button button)
    {
        GenericButton(button);
    }
    public void FuntionButton4(Button button)
    {
        GenericButton(button);
    }
    public void FuntionButton5(Button button)
    {
        GenericButton(button);
    }
    public void FuntionButton6(Button button)
    {
        GenericButton(button);
    }
    private void GenericButton(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void DisableButtonsOtherButtons()
    {
        isCoolDown = true;
        foreach (var item in listButtons)
        {
            item.interactable = false;
        }
    }
    public void EnableButtonsOtherButtons()
    {
        isCoolDown = false;
        foreach (var item in listButtons)
        {
            item.interactable = true;
        }
    }
    public void ShowHideButton(Button button)
    {
        button.GetComponent<ButtonUI>().ShowHideButton();
    }
    #endregion
}
