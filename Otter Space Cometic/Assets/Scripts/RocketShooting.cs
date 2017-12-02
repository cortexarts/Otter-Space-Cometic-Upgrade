using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketShooting : MonoBehaviour
{
    public GameObject missilePrefab;
    public Text TextValue;
    public int Value;
    public int ValueMin;
    public int ValueMax;
    public int numCorrectAnswers;
    public float cooldown = 1.0f;
    public float lastShotTime;

    // Use this for initialization
    void Start ()
    {
        Value = ValueMin;
        TextValue.text = Value.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (Time.time - lastShotTime > cooldown)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    void Shoot()
    {
       GameObject Missile = Instantiate(missilePrefab, this.transform.position, this.transform.rotation);
        Missile.SendMessage("SetAnswer", Value);
        if (++Value > ValueMax) Value = ValueMin;
       TextValue.text = Value.ToString();
    }
}