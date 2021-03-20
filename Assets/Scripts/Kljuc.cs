using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kljuc : MonoBehaviour
{
    public void KljucZvuk()
    {
        GetComponent<AudioSource>().Play();
    }

    public void KljucUkloni()
    {
        gameObject.SetActive(false);
    }
}
