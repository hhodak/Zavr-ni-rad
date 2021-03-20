using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ploca : MonoBehaviour
{
    Rigidbody ploca;
    public bool aktivno;

    void Start()
    {
        ploca = gameObject.GetComponent<Rigidbody>();
        aktivno = false;
    }

    void Naprijed()
    {
        if (gameObject.name == "Ploca_1")
        {
            Pomakni(3.0f);
        }
        else if (gameObject.name == "Ploca_2")
        {
            Pomakni(-3.0f);
        }
    }

    void Natrag()
    {
        aktivno = false;
        if (gameObject.name == "Ploca_1")
        {
            Pomakni(-3.0f);
        }
        else if (gameObject.name == "Ploca_2")
        {
            Pomakni(3.0f);
        }
    }

    void Pomakni(float strana)
    {
        GetComponent<AudioSource>().pitch = 2.0f;
        GetComponent<AudioSource>().Play();
        Vector3 pomak = new Vector3(strana, 0.0f, 0.0f);
        ploca.AddForce(pomak * 250);
    }
}
