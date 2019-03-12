using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour {
    public Text TextButton;
    public Image imageButton;
    public bool isShowing;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.S))
            ShowHideButton();
	}
    public void ShowHideButton()
    {
        isShowing = !isShowing;
        TextButton.enabled = isShowing;
        imageButton.enabled = isShowing;
       
    }
   

}
