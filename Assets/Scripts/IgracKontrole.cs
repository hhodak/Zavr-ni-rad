using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IgracKontrole : MonoBehaviour
{
    private Rigidbody rbIgrac;
    private float pomakHorizontalno;
    private float pomakVertikalno;
    float brzina = 6.0f;
    float snagaSkoka = 6.0f;
    public LayerMask tlo;
    CapsuleCollider igracSudarac;
    public Toggle imaKljuc;
    public Text tekstPomoc;

    void Start()
    {
        tekstPomoc.text = "";
        rbIgrac = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        imaKljuc.isOn = false;
        igracSudarac = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        pomakHorizontalno = Input.GetAxis("Horizontal");
        pomakVertikalno = Input.GetAxis("Vertical");

        if (Uzemljen() && Input.GetKeyDown(KeyCode.Space))
        {
            rbIgrac.AddForce(Vector3.up * snagaSkoka, ForceMode.Impulse);
        }

        if (Input.GetKey("left ctrl"))
            brzina = 10.0f;
        else
        {
            brzina = 6.0f;
        }

        Vector3 pomak = new Vector3(pomakHorizontalno, 0.0f, pomakVertikalno);

        rbIgrac.transform.Translate(pomak * brzina * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetirajLevel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(PrikaziPoruku());
        }
    }

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "KljucTag" && Input.GetKeyDown(KeyCode.E))
        {
            kolizija.gameObject.GetComponent<Kljuc>().KljucZvuk();
            imaKljuc.isOn = true;
            kolizija.gameObject.GetComponent<Kljuc>().Invoke("KljucUkloni", 0.25f);
        }
    }

    void ResetirajLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    bool Uzemljen()
    {
        return Physics.CheckCapsule(igracSudarac.bounds.center, new Vector3(igracSudarac.bounds.center.x, igracSudarac.bounds.min.y, igracSudarac.bounds.center.z), igracSudarac.radius * 0.9f, tlo);
    }

    IEnumerator PrikaziPoruku()
    {
        PrikaziTekst();
        yield return new WaitForSeconds(5.0f);
        tekstPomoc.text = "";
    }

    void PrikaziTekst()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1: tekstPomoc.text = "Vrata ne ostaju otvorena. Potrebno ih je zadržati."; break;
            case 2: tekstPomoc.text = "Platforme detektiraju promjenu mase. Mogli bi to iskoristiti."; break;
            case 3: tekstPomoc.text = "Trebat ćemo primjeniti znanje o primarnim i sekundarnim bojama."; break;
            case 4: tekstPomoc.text = "Neke platforme treba 'zaključati' u mjestu, a druge pomaknuti."; break;
        }
    }
}
