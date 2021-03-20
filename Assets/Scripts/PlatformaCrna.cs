using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaCrna : MonoBehaviour
{
    public int brojKutije;
    public GameObject kutija;

    void Start()
    {
        brojKutije = 0;
    }

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.tag == "ZutaKutijaTag")
        {
            brojKutije = 1;
            kutija = kolizija.gameObject;
        }
        else if (kolizija.tag == "CrvenaKutijaTag")
        {
            brojKutije = 2;
            kutija = kolizija.gameObject;
        }
        else if (kolizija.tag == "PlavaKutijaTag")
        {
            brojKutije = 3;
            kutija = kolizija.gameObject;
        }
    }

    private void OnTriggerExit(Collider kolizija)
    {
        if (kolizija.tag == "ZutaKutijaTag")
        {
            brojKutije = 0;
            kutija = null;
        }
        else if (kolizija.tag == "CrvenaKutijaTag")
        {
            brojKutije = 0;
            kutija = null;
        }
        else if (kolizija.tag == "PlavaKutijaTag")
        {
            brojKutije = 0;
            kutija = null;
        }
    }
}
