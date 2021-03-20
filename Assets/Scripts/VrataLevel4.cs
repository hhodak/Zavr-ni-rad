using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrataLevel4 : MonoBehaviour
{
    public GameObject zvukOtvaranje;
    public GameObject zvukUdarac;
    public GameObject platforma;
    public bool otvoreno;
    Rigidbody vrata;
    float snaga = 60.0f;

    void Start()
    {
        otvoreno = false;
        vrata = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (vrata.position.y >= 9.0f)
        {
            vrata.position = new Vector3(0, 9.0f, 0);
            ZaustaviVrata();
        }
    }

    public void Otvori()
    {
        otvoreno = true;
        vrata.GetComponent<Rigidbody>().useGravity = false;
        zvukOtvaranje.GetComponent<AudioSource>().pitch = 0.75f;
        zvukOtvaranje.GetComponent<AudioSource>().Play();
        vrata.AddForce(vrata.transform.up * snaga);
    }

    public void Zatvori()
    {
        otvoreno = false;
        vrata.GetComponent<Rigidbody>().useGravity = true;
        zvukOtvaranje.GetComponent<AudioSource>().pitch = 3.0f;
        zvukOtvaranje.GetComponent<AudioSource>().Play();
        zvukUdarac.GetComponent<AudioSource>().PlayDelayed(0.8f);
    }

    public void ZaustaviVrata()
    {
        vrata.velocity = Vector3.zero;
        vrata.angularVelocity = Vector3.zero;
    }
}
