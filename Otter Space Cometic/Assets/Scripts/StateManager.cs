﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Canvas cameraCanvas;
    public Canvas rocketCanvas;
    public Canvas overlayCanvas;
    public GameObject instructionsPanel;
    public GameObject dialoguePanel;

	// Use this for initialization
	void Start ()
    {
        cameraCanvas.gameObject.SetActive(false);
        rocketCanvas.gameObject.SetActive(false);
        overlayCanvas.gameObject.SetActive(true);
        dialoguePanel.gameObject.SetActive(false);
        instructionsPanel.SetActive(true);
        StartCoroutine(ShowInstructions());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            if (cameraCanvas.gameObject.activeInHierarchy)
            {
                cameraCanvas.gameObject.SetActive(false);
            }
            else
            {
                cameraCanvas.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            if (rocketCanvas.gameObject.activeInHierarchy)
            {
                rocketCanvas.gameObject.SetActive(false);
            }
            else
            {
                rocketCanvas.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            if (overlayCanvas.gameObject.activeInHierarchy)
            {
                overlayCanvas.gameObject.SetActive(false);
            }
            else
            {
                overlayCanvas.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ShowInstructions()
    {
        yield return 0;
        yield return new WaitForSeconds(10.0f);
        instructionsPanel.SetActive(false);
        dialoguePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        overlayCanvas.gameObject.SetActive(false);
        cameraCanvas.gameObject.SetActive(true);
        rocketCanvas.gameObject.SetActive(true);
    }
}
