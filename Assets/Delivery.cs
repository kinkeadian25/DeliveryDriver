using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0,243,255,255);
    [SerializeField] Color32 noPackageColor = new Color32(200,120,0,255); 


    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    void OnCollisionEnter2D(Collision2D other) 
    {   
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package is picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

        }
    }
}
