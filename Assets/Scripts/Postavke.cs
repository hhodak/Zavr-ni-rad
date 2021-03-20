using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Postavke : MonoBehaviour
{

    public AudioMixer glavniZvuk;
    public Dropdown rezolucijeIzbornik;
    Resolution[] rezolucije;

    private void Start()
    {
        rezolucije = Screen.resolutions;

        rezolucijeIzbornik.ClearOptions();

        List<string> opcije = new List<string>();

        int trenutnaRezolucija = 0;

        for (int i = 0; i < rezolucije.Length; i++)
        {
            string opcija = rezolucije[i].width + " x " + rezolucije[i].height;
            opcije.Add(opcija);

            if (rezolucije[i].width == Screen.currentResolution.width && rezolucije[i].height == Screen.currentResolution.height)
            {
                trenutnaRezolucija = i;
            }
        }

        rezolucijeIzbornik.AddOptions(opcije);
        rezolucijeIzbornik.value = trenutnaRezolucija;
        rezolucijeIzbornik.RefreshShownValue();
    }

    public void PostaviZvuk(float glasnoca)
    {
        glavniZvuk.SetFloat("Zvuk", glasnoca);
    }

    public void PostaviKvalitetu(int kvaliteta)
    {
        QualitySettings.SetQualityLevel(kvaliteta);
    }

    public void PostaviCijeliZaslon(bool cijeliZaslon)
    {
        Screen.fullScreen = cijeliZaslon;
    }

    public void PostaviRezoluciju(int rezolucija)
    {
        Resolution rez = rezolucije[rezolucija];
        Screen.SetResolution(rez.width, rez.height, Screen.fullScreen);
    }
}
