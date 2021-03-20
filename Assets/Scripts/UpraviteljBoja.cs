using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpraviteljBoja : MonoBehaviour
{
    public GameObject zutaPlatforma;
    public GameObject narancastaPlatforma;
    public GameObject crvenaPlatforma;
    public GameObject ljubicastaPlatforma;
    public GameObject plavaPlatforma;
    public GameObject zelenaPlatforma;
    public GameObject vrata;

    void Update()
    {
        if (zutaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            narancastaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            crvenaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            ljubicastaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            plavaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            zelenaPlatforma.GetComponent<PlatformaBoja>().ukljucena &&
            vrata.GetComponent<VrataLevel3>().otvorena == false)
        {
            vrata.GetComponent<VrataLevel3>().OtvoriVrata();
        }
    }
}
