using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetekcijaKutije : MonoBehaviour
{
    public bool otkljucano;
    public GameObject platforma;
    public Material crveno;
    public Material zeleno;
    Renderer rendererPlatforma;

    void Start()
    {
        otkljucano = true;
        rendererPlatforma = platforma.GetComponent<Renderer>();
    }

    void Update()
    {
        if (otkljucano)
        {
            rendererPlatforma.sharedMaterial = zeleno;
        }
        else
        {
            rendererPlatforma.sharedMaterial = crveno;
        }
    }

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.tag == "KutijaTag")
        {
            otkljucano = false;
        }
    }

    private void OnTriggerExit(Collider kolizija)
    {
        if (kolizija.tag == "KutijaTag")
        {
            otkljucano = true;
        }
    }
}
