using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomicanjePlatforme : MonoBehaviour
{
    public GameObject detektor;
    GameObject gumbLijevo;
    GameObject gumbDesno;
    public int trenutniX;
    public int najveciX;
    public int najmanjiX;
    public int koordinataZ;
    bool kretanjeLijevo;
    bool kretanjeDesno;
    bool uPokretu;

    void Start()
    {
        kretanjeDesno = false;
        kretanjeLijevo = false;
        uPokretu = false;

        gumbLijevo = GameObject.Find("GumbLijevo");
        gumbDesno = GameObject.Find("GumbDesno");
    }

    void Update()
    {
        if (gumbLijevo.GetComponent<GumbPlatforma>().pritisnuto == true && trenutniX > najmanjiX && !uPokretu && detektor.GetComponent<DetekcijaKutije>().otkljucano)
        {
            PomakniPlatformu(gumbLijevo.GetComponent<GumbPlatforma>().pomak);
            trenutniX -= 5;
            kretanjeLijevo = true;
            uPokretu = true;
        }

        if (gumbDesno.GetComponent<GumbPlatforma>().pritisnuto == true && trenutniX < najveciX && !uPokretu && detektor.GetComponent<DetekcijaKutije>().otkljucano)
        {
            PomakniPlatformu(gumbDesno.GetComponent<GumbPlatforma>().pomak);
            trenutniX += 5;
            kretanjeDesno = true;
            uPokretu = true;
        }

        if (kretanjeLijevo && transform.position.x <= trenutniX)
        {
            ZaustaviPlatformu();
            kretanjeLijevo = false;
        }

        if (kretanjeDesno && transform.position.x >= trenutniX)
        {
            ZaustaviPlatformu();
            kretanjeDesno = false;
        }
    }

    void PomakniPlatformu(Vector3 pomak)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(pomak * 20);
        GetComponent<AudioSource>().pitch = 10.0f;
        GetComponent<AudioSource>().Play();
    }

    void ZaustaviPlatformu()
    {
        transform.position = new Vector3(trenutniX, 1, koordinataZ);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gumbDesno.GetComponent<GumbPlatforma>().pritisnuto = false;
        gumbLijevo.GetComponent<GumbPlatforma>().pritisnuto = false;
        uPokretu = false;
    }
}
