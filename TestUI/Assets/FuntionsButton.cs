using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuntionsButton : MonoBehaviour {
    #region Variables
    #endregion
    #region Unity Methods
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion
    #region Helpers Methods
    public void FuntionButton1(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void FuntionButton2(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void FuntionButton3(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void FuntionButton4(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void FuntionButton5(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    public void FuntionButton6(Button button)
    {
        button.GetComponent<ButtonUI>().ClikButton();
    }
    #endregion
}
