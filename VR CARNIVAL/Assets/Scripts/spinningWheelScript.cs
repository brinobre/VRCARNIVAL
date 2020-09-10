using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinningWheelScript : MonoBehaviour
{

    [SerializeField] private Rigidbody wheel;

    [SerializeField] private GameObject Arrow;

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
        
        {
            if (other.gameObject.tag == "win")
            {
                resultText.text = "Congrats!";
            } else if(other.gameObject.tag == "loss")
            {
                resultText.text = "Try again!";
            }
        }
       
        
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
