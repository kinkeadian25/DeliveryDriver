using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Driver : MonoBehaviour
{
    // Variables
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;
    float relativeTime;
    bool slowSpeedOn;
    bool boostSpeedOn;
 
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Slowing speed Cabron!");
        slowSpeedOn = true;
        boostSpeedOn = false;
        relativeTime = Time.fixedTime + 2.0f;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            Debug.Log("Boooooosting!");
            relativeTime = Time.fixedTime + 5.0f;
            boostSpeedOn = true;
            slowSpeedOn = false;
        }
    }
    void Update()
    {
        if(relativeTime >= Time.fixedTime && slowSpeedOn){
            moveSpeed = slowSpeed;
        }
        if(relativeTime >= Time.fixedTime && boostSpeedOn){
            moveSpeed = boostSpeed;
        }
        if(relativeTime < Time.fixedTime){
            moveSpeed = 12f;
            slowSpeedOn = false;
            boostSpeedOn = false;
        }
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
 
        transform.Translate(0, moveAmount, 0);
  
        if (moveAmount > 0.01f){
            transform.Rotate(0, 0, -steerAmount);
        }
        if (moveAmount < -0.01f){
            transform.Rotate(0, 0, steerAmount);
        }
    }
 
}