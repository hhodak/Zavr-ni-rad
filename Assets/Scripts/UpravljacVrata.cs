using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpravljacVrata : MonoBehaviour
{
    public GameObject platformaLijevo;
    public GameObject platformaDesno;
    public GameObject vrataLijevo;
    public GameObject vrataDesno;

    void Update()
    {
        //platformaLijevo.GetComponent<DetekcijaKutije>().otkljucano se gleda suprotna vrijednost
        if (platformaLijevo.GetComponent<DetekcijaKutije>().otkljucano == false && vrataLijevo.GetComponent<VrataLevel4>().otvoreno == false)
        {
            vrataLijevo.GetComponent<VrataLevel4>().Otvori();
        }

        if(platformaLijevo.GetComponent<DetekcijaKutije>().otkljucano==true && vrataLijevo.GetComponent<VrataLevel4>().otvoreno==true)
        {
            vrataLijevo.GetComponent<VrataLevel4>().Zatvori();
        }

        //platformaDesno.GetComponent<DetekcijaKutije>().otkljucano se gleda suprotna vrijednost
        if (platformaDesno.GetComponent<DetekcijaKutije>().otkljucano == false && vrataDesno.GetComponent<VrataLevel4>().otvoreno == false)
        {
            vrataDesno.GetComponent<VrataLevel4>().Otvori();
        }

        if (platformaDesno.GetComponent<DetekcijaKutije>().otkljucano == true && vrataDesno.GetComponent<VrataLevel4>().otvoreno == true)
        {
            vrataDesno.GetComponent<VrataLevel4>().Zatvori();
        }
    }
}
