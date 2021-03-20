using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NosacPlatforme : MonoBehaviour
{
    private void OnTriggerEnter(Collider kolizija)
    {
        if (kolizija.gameObject.tag == "Igrac")
        {
            SceneManager.LoadScene(4);
        }
    }
}
