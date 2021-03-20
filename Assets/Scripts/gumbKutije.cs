using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumbKutije : MonoBehaviour
{
    public GameObject gumb;
    public GameObject kutija;
    public GameObject ploca;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit pogodak;
            Ray usmjerenje = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(usmjerenje, out pogodak, 25.0f))
            {
                if (pogodak.transform.name == gumb.name && ploca.GetComponent<Ploca>().aktivno == false)
                {
                    GetComponent<AudioSource>().Play();
                    ploca.GetComponent<Ploca>().aktivno = true;
                    Instantiate(kutija);
                    ploca.GetComponent<Ploca>().Invoke("Naprijed", 2.0f);
                    ploca.GetComponent<Ploca>().Invoke("Natrag", 3.0f);
                }
            }
        }
    }
}
