using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketShooting : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Text TextValue;
    public int Value;


    // Use this for initialization
    void Start ()
    {
        Value = Random.Range(1, 10);
        TextValue.text = Value.ToString();
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
       GameObject Rocket = Instantiate(rocketPrefab, this.transform.position, this.transform.rotation);
       Rocket.SendMessage("SetAnswer", Value);
       Value = Random.Range(1, 10);
       TextValue.text = Value.ToString();
    }
}