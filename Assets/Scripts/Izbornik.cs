using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Izbornik : MonoBehaviour
{
    public GameObject izbornik;
    public GameObject postavke;
    public GameObject pomoc;

    public void ZapocniIgru()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Izlaz()
    {
        Application.Quit();
    }

    public void OtvoriPostavke()
    {
        izbornik.SetActive(false);
        postavke.SetActive(true);
    }

    public void ZatvoriPostavke()
    {
        izbornik.SetActive(true);
        postavke.SetActive(false);
    }

    public void OtvoriPomoc()
    {
        izbornik.SetActive(false);
        pomoc.SetActive(true);
    }

    public void ZatvoriPomoc()
    {
        izbornik.SetActive(true);
        pomoc.SetActive(false);
    }
}
