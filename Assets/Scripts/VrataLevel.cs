using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrataLevel : MonoBehaviour
{
    public Rigidbody desnoKrilo;
    public Rigidbody lijevoKrilo;
    public GameObject lijevoSvjetlo;
    public GameObject desnoSvjetlo;
    public GameObject gornjeSvjetlo;
    public Material crveno;
    public Material zeleno;
    public GameObject igrac;
    float brzina = 50.0f;
    bool desnoKriloOtvoreno;
    bool lijevoKriloOtvoreno;
    Renderer svjetloLijevo;
    Renderer svjetloDesno;
    Renderer svjetloGornje;

    void Start()
    {
        desnoKrilo.useGravity = false;
        lijevoKrilo.useGravity = false;
        desnoKriloOtvoreno = false;
        lijevoKriloOtvoreno = false;
        svjetloLijevo = lijevoSvjetlo.GetComponent<Renderer>();
        svjetloLijevo.sharedMaterial = crveno;
        svjetloDesno = desnoSvjetlo.GetComponent<Renderer>();
        svjetloDesno.sharedMaterial = crveno;
        svjetloGornje = gornjeSvjetlo.GetComponent<Renderer>();
        svjetloGornje.sharedMaterial = crveno;
    }

    void Update()
    {
        if (igrac.GetComponent<IgracKontrole>().imaKljuc.isOn)
        {
            svjetloLijevo.sharedMaterial = zeleno;
            svjetloDesno.sharedMaterial = zeleno;
            svjetloGornje.sharedMaterial = zeleno;
        }
        else
        {
            svjetloLijevo.sharedMaterial = crveno;
            svjetloDesno.sharedMaterial = crveno;
            svjetloGornje.sharedMaterial = crveno;
        }
    }

    void OtvoriVrata()
    {
        desnoKrilo.useGravity = true;
        Vector3 pomakDesno = new Vector3(1.0f, 0.0f, 0.0f);
        desnoKrilo.AddForce(pomakDesno * brzina);
        desnoKrilo.GetComponent<AudioSource>().pitch = 0.8f;
        desnoKrilo.GetComponent<AudioSource>().Play();
        desnoKriloOtvoreno = true;

        lijevoKrilo.useGravity = true;
        Vector3 pomakLijevo = new Vector3(-1.0f, 0.0f, 0.0f);
        lijevoKrilo.AddForce(pomakLijevo * brzina);
        lijevoKrilo.GetComponent<AudioSource>().pitch = 0.8f;
        lijevoKrilo.GetComponent<AudioSource>().Play();
        lijevoKriloOtvoreno = true;
    }

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "Igrac" && Input.GetKeyDown(KeyCode.F) && igrac.GetComponent<IgracKontrole>().imaKljuc.isOn && desnoKriloOtvoreno == false && lijevoKriloOtvoreno == false)
        {
            desnoKrilo.isKinematic = false;
            lijevoKrilo.isKinematic = false;
            OtvoriVrata();
        }
    }
}
