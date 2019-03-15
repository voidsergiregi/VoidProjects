using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCanvas : MonoBehaviour {
    public Camera mainCamera;
    public Canvas Canvas;
    public bool isShowingCanvas;
	// Use this for initialization
	void Start () {
        Canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateShowHideCanvas();
	}
    public void UpdateShowHideCanvas()
    {
        isShowingCanvas = IsVisionEdCanvas();
        Canvas.enabled = isShowingCanvas;
    }
    
    public bool IsVisionEdCanvas()
    {
        return (Vector3.Dot(mainCamera.transform.forward, transform.forward) > 0f);
    }
}
