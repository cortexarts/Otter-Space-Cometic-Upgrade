using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Canvas CameraCanvas;
    public Canvas RocketCanvas;
    public Canvas OverlayCanvas;

	// Use this for initialization
	void Start ()
    {
        CameraCanvas.gameObject.SetActive(false);
        RocketCanvas.gameObject.SetActive(false);
        OverlayCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            CameraCanvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            RocketCanvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            OverlayCanvas.gameObject.SetActive(true);
        }
    }
}
