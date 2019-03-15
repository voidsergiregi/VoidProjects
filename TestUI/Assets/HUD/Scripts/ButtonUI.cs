using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    #region Variables Public
    public Text TextButton;
    public Image imageButton;
    public bool isShowingButton;
    public float durationCoolDownTime=1f;
    #endregion
    #region Variables Private
    private bool cooldownReset;
    private ButtonsHud buttonsHudParent;
    #endregion
    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        buttonsHudParent = gameObject.transform.parent.GetComponent<ButtonsHud>();
        imageButton.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            ShowHideButton();
 
    }
    #endregion
    #region HelperMethods
   
    public void ShowHideButton()
    {
        isShowingButton = !isShowingButton;
        TextButton.enabled = isShowingButton;
        imageButton.enabled = isShowingButton;
    }
    public void ClikButton()
    {
        //TODO activateHability with states
      
        StartCoroutine(CoolDownButton(durationCoolDownTime));
        Debug.Log("Start cooldown i activateHability");
    }
    #endregion
    public IEnumerator CoolDownButton(float duration=2f)
    {
        buttonsHudParent.DisableButtonsOtherButtons();
            float startTime = Time.time;
            while (Time.time - startTime <= duration + 0.1F)
            {
                imageButton.fillAmount = Time.time - startTime / duration;
                if(imageButton.fillAmount>=1.0f && buttonsHudParent.isCoolDown)
                buttonsHudParent.EnableButtonsOtherButtons();
                yield return null;
            }
    }
}
