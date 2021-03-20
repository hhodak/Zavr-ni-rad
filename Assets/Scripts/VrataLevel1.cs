using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrataLevel1 : MonoBehaviour
{
    public GameObject zvukOtvaranje;
    public GameObject zvukUdarac;
    Rigidbody vrata;
    public bool otvorena = false;
    public float snaga;

    void Start()
    {
        vrata = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (vrata.position.y >= 6)
        {
            ZatvoriVrata();
        }
    }

    public void OtvoriVrata()
    {
        vrata.GetComponent<Rigidbody>().useGravity = false;
        zvukOtvaranje.GetComponent<AudioSource>().pitch = 0.75f;
        zvukOtvaranje.GetComponent<AudioSource>().Play();
        vrata.AddForce(vrata.transform.up * snaga);

        otvorena = true;
    }

    public void ZatvoriVrata()
    {
        vrata.GetComponent<Rigidbody>().useGravity = true;
        zvukOtvaranje.GetComponent<AudioSource>().pitch = 3.0f;
        zvukOtvaranje.GetComponent<AudioSource>().Play();
        zvukUdarac.GetComponent<AudioSource>().PlayDelayed(0.8f);
        otvorena = false;
    }

    void ZaustaviVrata()
    {
        vrata.velocity = Vector3.zero;
        vrata.angularVelocity = Vector3.zero;
    }
}
