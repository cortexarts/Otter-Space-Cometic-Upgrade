using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    //Maximum speed
    [SerializeField]
    private float m_MaxVelocity = 200f;
    //Maximum speed while going backwards,
    [SerializeField]
    private float m_MinVelocity = 0f;
    //Current speed
    [SerializeField]
    private float m_Velocity = 0f;
    //Value by which speed is increased
    [SerializeField]
    private float m_Acceleration = 4f;
    //Degrees turned a second if buttons are pressed 
    [SerializeField]
    private float m_RotationSpeed = 80f;
    //Fuel amount, currently untapped
    [SerializeField]
    private float m_FuelAmount = 100f;
    //Current direction the craft is moving towards
    [SerializeField]
    private Vector3 m_MoveDirection;

    [SerializeField]
    private Rigidbody2D m_Rigidbody2D;
    
    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputVertical != 0)
        {
            ChangeDirectionAndVelocity(transform.up, m_Acceleration, inputVertical);
        }
        if (inputHorizontal != 0)
        {
            //Rotate the craft according to button press
            transform.Rotate(transform.forward, -inputHorizontal * m_RotationSpeed * Time.fixedDeltaTime);

        }
        
        //Move the craft
        m_Rigidbody2D.velocity = m_MoveDirection * m_Velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
    }

    //Takes an degree angle difference between two directions and returns a value between 1 and -1
    //if the angle is 0 the directions aligned and 1 is returned
    //if the angle is 180 the directions were totally opposite and -1 is returned
    //and everything in between
    private float AngleToDirection(float angle)
    {
        return (angle - 90) / 90 * -1;
    }

    //This method is able to take a direction and howfast someone is trying to get there
    //And change the movement direction and velocity with it
    private void ChangeDirectionAndVelocity(Vector3 direction, float acceleration, float dir = 1)
    {
        float angle = Vector3.Angle(m_MoveDirection, direction * acceleration * dir);
        float accFactor = AngleToDirection(angle);
        //Change the move direction according to button press
        m_MoveDirection = m_MoveDirection * m_Velocity + direction * acceleration * dir;
        //Normalize it again
        m_MoveDirection.Normalize();
        //Update velocity
        m_Velocity += acceleration * accFactor;
        m_Velocity = Mathf.Clamp(m_Velocity, m_MinVelocity, m_MaxVelocity);
    }
    public float CurrentFuelAmount()
    {
        return m_FuelAmount;
    }
}
