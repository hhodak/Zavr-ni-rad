using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrataLevel3 : MonoBehaviour
{
    public GameObject zvukOtvaranje;
    Rigidbody vrata;
    public float snaga;
    public bool otvorena;

    void Start()
    {
        otvorena = false;
        vrata = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (vrata.position.y >= 6.0f)
        {
            vrata.position = new Vector3(0, 6.0f, 0);
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

    void ZatvoriVrata()
    {
        vrata.velocity = Vector3.zero;
        vrata.angularVelocity = Vector3.zero;
    }
}
