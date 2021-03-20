using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KrajLevela : MonoBehaviour
{
    public Text krajTekst;
    int brojScena = 5;

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "Igrac")
        {
            krajTekst.text = "Razina " + SceneManager.GetActiveScene().buildIndex + " gotova!";
            krajTekst.gameObject.SetActive(true);
            Invoke("PozoviScenu", 5.0f);
        }
    }

    void PozoviScenu()
    {
        if (SceneManager.GetActiveScene().buildIndex < brojScena - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Izbornik");
        }
    }
}
