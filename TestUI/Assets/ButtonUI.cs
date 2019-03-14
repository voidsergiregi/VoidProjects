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
       // cooldownReset = imageButton.fillAmount == 1.0F;
      
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
    public IEnumerator CoolDown(float duration=2f)
    {
            gameObject.transform.parent.GetComponent<FuntionsButton>().DisableButtonsOtherButtons();
            float startTime = Time.time;
            while (Time.time - startTime <= duration + 0.1F)
            {
                imageButton.fillAmount = Time.time - startTime / duration;
                if(imageButton.fillAmount>=1.0f && gameObject.transform.parent.GetComponent<FuntionsButton>().isCoolDown)
                gameObject.transform.parent.GetComponent<FuntionsButton>().EnableButtonsOtherButtons();
            yield return null;
            }
        
    }
}
