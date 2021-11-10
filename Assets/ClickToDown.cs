using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickToDown : MonoBehaviour
{
    bool Clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !Clicked)
        {
            Clicked = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("I come down");
        }
            
    }
    
    

    
}
