using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Canvas Radar;
    public Canvas Rocket;
    public Canvas Dialogue;

	// Use this for initialization
	void Start ()
    {
        Radar.gameObject.SetActive(false);
        Rocket.gameObject.SetActive(false);
        Dialogue.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
