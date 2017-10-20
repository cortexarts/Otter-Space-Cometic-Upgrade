using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float lifeTime = 0;
    public float maxLifeTime = 5.0f;
    public float movementSpeed = 2.0f;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.AddForce(transform.up * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
