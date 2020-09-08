using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinningWheelScript : MonoBehaviour
{

    [SerializeField] private Rigidbody wheel;

    [SerializeField] private GameObject Arrow;

   // [SerializeField] private Collider arrow;

    [SerializeField] private GameObject win;

    [SerializeField] private GameObject loss;


    [SerializeField] private Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "Spin!";
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
       //if(wheel.velocity == Vector3.zero)
        {
            if (other.gameObject.tag == "win")
            {
                if (wheel.isKinematic == false)
                    resultText.text = "Good job!";
            } else if(other.gameObject.tag == "loss")
            {
                if (wheel.isKinematic == false)
                    resultText.text = "Better luck next time!";
            }
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        /**
        //if (wheel.isKinematic == false)
        {
            if (Arrow.tag == "Arrow" && win.tag == "win")
            {
                resultText.text = "Good job!";
            }
            else if (Arrow.tag == "Arrow" && loss.tag == "loss")
            {
                resultText.text = "Better luck next time!";
            }
        }*/
    }
}
