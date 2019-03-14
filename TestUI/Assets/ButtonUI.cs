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
    #endregion
    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        imageButton.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            ShowHideButton();
        ResetButtonAfterCoolDown();
    }
    #endregion
    #region HelperMethods
    public void ResetButtonAfterCoolDown()
    {
        cooldownReset = imageButton.fillAmount == 1.0F;
        if (gameObject.transform.parent.GetComponent<FuntionsButton>().isCoolDown)
        {
//            gameObject.transform.parent.GetComponent<FuntionsButton>().EnableButtonsOtherButtons();
            //GetComponent<Button>().interactable = true;
        }
    }
    public void ShowHideButton()
    {
        isShowingButton = !isShowingButton;
        TextButton.enabled = isShowingButton;
        imageButton.enabled = isShowingButton;
    }
    public void ClikButton()
    {
        //TODO activateHability with states
      
        StartCoroutine(CoolDown(durationCoolDownTime));
        Debug.Log("Start cooldown i activateHability");
    }
    #endregion
    IEnumerator CoolDown(float duration)
    {
        if (cooldownReset)
        {
            gameObject.transform.parent.GetComponent<FuntionsButton>().DisableButtonsOtherButtons();
            //GetComponent<Button>().interactable = false;
            float startTime = Time.time;
            while (Time.time - startTime <= duration + 0.1F)
            {
                imageButton.fillAmount = Time.time - startTime / duration;
                yield return null;
            }
        }        
    }
}
