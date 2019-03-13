using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour {
    public Text TextButton;
    public Image imageButton;
    public bool isShowing;
    public float coolDown;
    private bool countdownRunning;

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
       // isShowing = !isShowing;
       // TextButton.enabled = isShowing;
       // imageButton.enabled = isShowing;
        imageButton.fillAmount = 0.5f;
    }
    public void ClikButton()
    {
        //TODO startcooldown and activateHability with states
        //SartCourotne(CountDown(1f);
        StartCoroutine(WaitForSeconds(1f));
        Debug.Log("Start cooldown i activateHability");
    }
   
    IEnumerator CountDown(float time)
    {
        countdownRunning = true;
        StartCoroutine("CountDownAnimation", time);
        yield return new WaitForSeconds(time);
        Debug.Log("Ding ding ding");
        if (countdownRunning)
            //do stuff

            countdownRunning = false;
    }
    IEnumerator CountDownAnimation(float time)
    {
        float animationTime = time;
        while (animationTime > 0)
        {
            animationTime -= Time.deltaTime;
            imageButton.fillAmount = animationTime / time;
            yield return new WaitForSeconds(Time.deltaTime);
        }
       
    }
    IEnumerator WaitForSeconds(float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            imageButton.fillAmount = Time.time - startTime / duration;
            yield return null;
        }
    }

}
