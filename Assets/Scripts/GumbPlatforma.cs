using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbPlatforma : MonoBehaviour
{
    public bool pritisnuto;
    public Vector3 pomak;

    void Start()
    {
        pritisnuto = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit pogodak;
            Ray usmjerenje = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(usmjerenje, out pogodak, 25.0f))
            {
                if (pogodak.transform.name == gameObject.name && pritisnuto == false)
                {
                    GetComponent<AudioSource>().Play();
                    pritisnuto = true;
                }
            }
        }
    }

}
