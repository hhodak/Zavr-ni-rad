using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzmiKutiju : MonoBehaviour
{
    public GameObject stvar;
    public GameObject trenutniRoditelj;
    public Transform vodic;
    public bool drziStvar = false;
    float udaljenost;
    float snaga = 600;

    void Start()
    {
        trenutniRoditelj = GameObject.Find("vodic");
        vodic = trenutniRoditelj.GetComponent<Transform>();
    }

    void Update()
    {
        udaljenost = Vector3.Distance(stvar.transform.position, vodic.transform.position);

        if (drziStvar == true)
        {
            stvar.GetComponent<Rigidbody>().useGravity = false;
            stvar.GetComponent<Rigidbody>().detectCollisions = true;
            stvar.transform.parent = trenutniRoditelj.transform;
            stvar.transform.position = vodic.transform.position;
            if (Input.GetMouseButtonDown(1))
            {
                stvar.GetComponent<Rigidbody>().AddForce(vodic.transform.forward * snaga);
                drziStvar = false;
            }
        }
        else
        {
            stvar.GetComponent<Rigidbody>().useGravity = true;
            stvar.transform.parent = null;
        }
    }

    void OnMouseDown()
    {
        if (udaljenost <= 1.5f)
        {
            drziStvar = true;
        }
    }

    void OnMouseUp()
    {
        drziStvar = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        drziStvar = false;
    }
}

