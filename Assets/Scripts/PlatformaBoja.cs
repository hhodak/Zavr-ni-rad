using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaBoja : MonoBehaviour
{
    public bool ukljucena;
    public string kutijaTag;

    private void OnTriggerStay(Collider kolizija)
    {
        if (kolizija.tag == kutijaTag)
        {
            ukljucena = true;
        }
    }

    private void OnTriggerExit(Collider kolizija)
    {
        if (kolizija.tag == kutijaTag)
        {
            ukljucena = false;
        }
    }
}
