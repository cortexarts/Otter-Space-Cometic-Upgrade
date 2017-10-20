﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float lifeTime = 0;
    public float maxLifeTime = 5.0f;

    [SerializeField]
    public float m_Velocity = 150.0f;

    // Handle camera shaking
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    CameraShake camShake;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        camShake = Camera.main.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.LogError("No CameraShake script found.");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime > maxLifeTime)
        {
            DestroyImmediate(this.gameObject);
        }
	}

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = transform.up * m_Velocity * Time.fixedDeltaTime;
    }

    private void OnDestroy()
    {
        Debug.Log("Still need to add animations!");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Comet")
        {
            //Shake the camera
            camShake.Shake(camShakeAmt, camShakeLength);
            DestroyObject(this.gameObject);
        }
    }
}
