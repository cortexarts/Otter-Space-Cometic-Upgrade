using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooting : MonoBehaviour
{
    public GameObject rocketPrefab;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
       Instantiate(rocketPrefab, this.transform.position, this.transform.rotation);
    }
}