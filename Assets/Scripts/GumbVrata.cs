using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbVrata : MonoBehaviour
{
    public GameObject vrata;
    public Material otvorena;
    public Material zatvorena;
    Renderer rendererGumb;

    void Start()
    {
        rendererGumb = GetComponent<Renderer>();
        rendererGumb.sharedMaterial = zatvorena;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit pogodak;
            Ray usmjerenje = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(usmjerenje, out pogodak, 100.0f))
            {
                if (pogodak.transform.name == "Dugme")
                {
                    GetComponent<AudioSource>().Play();

                    if (vrata.GetComponent<VrataLevel1>().otvorena == false)
                        vrata.GetComponent<VrataLevel1>().OtvoriVrata();
                    else
                        vrata.GetComponent<VrataLevel1>().ZatvoriVrata();
                }
            }
        }

        Boja(vrata.GetComponent<VrataLevel1>().otvorena);
    }

    void Boja(bool statusVrata)
    {
        if (statusVrata)
        {
            rendererGumb.sharedMaterial = otvorena;
        }
        else
        {
            rendererGumb.sharedMaterial = zatvorena;
        }
    }

}
