using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    private Vector3 startPosition;
    
    void Start()
   {
        startPosition = transform.position;
   }
    // Remembering where the ball started
   void Update()
   {
   if (transform.position.y < -5f)
        {
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
   // Reset of the ball is triggered when the ball is falling with the force of 5
   }
}
