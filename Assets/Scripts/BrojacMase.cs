using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrojacMase : MonoBehaviour
{
    public float masa;
    public GameObject vrata;
    
    void Start()
    {
        masa = 0.0f;
    }
    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "KutijaTag")
        {
            masa += kolizija.gameObject.GetComponent<Rigidbody>().mass;
            vrata.GetComponent<VrataLevel2>().PodigniVrata(kolizija.gameObject.GetComponent<Rigidbody>().mass);
        }
    }

    private void OnTriggerExit(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "KutijaTag")
        {
            masa -= kolizija.gameObject.GetComponent<Rigidbody>().mass;
            vrata.GetComponent<VrataLevel2>().PodigniVrata(-kolizija.gameObject.GetComponent<Rigidbody>().mass);
        }
    }

}
