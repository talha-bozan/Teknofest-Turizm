using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxScript : MonoBehaviour
{   public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("slm");
        image.color = new Color(255,0,0);

    }
    private void OnTriggerExit(Collider other){
        Debug.Log("slm");
        image.color = new Color(0,0,0);

    }
}
