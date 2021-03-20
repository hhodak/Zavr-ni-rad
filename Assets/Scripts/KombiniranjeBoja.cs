using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KombiniranjeBoja : MonoBehaviour
{

    public GameObject platforma1;
    public GameObject platforma2;
    public GameObject narancasta;
    public GameObject ljubicasta;
    public GameObject zelena;
    int novaBoja;

    void Start()
    {
        novaBoja = 0;
    }

    void Update()
    {
        if (GetComponent<Ploca>().aktivno == false)
        {
            IzradiBoju(platforma1.GetComponent<PlatformaCrna>().brojKutije, platforma2.GetComponent<PlatformaCrna>().brojKutije);
            if (novaBoja != 0)
            {
                switch (novaBoja)
                {
                    case 4: KombinirajBoje(narancasta); break;
                    case 5: KombinirajBoje(zelena); break;
                    case 6: KombinirajBoje(ljubicasta); break;
                    default: break;
                }
            }
        }
    }

    void IzradiBoju(int prvaBoja, int drugaBoja)
    {
        if (prvaBoja == 1 && drugaBoja == 2)
        {
            novaBoja = 4;
        }
        else if (prvaBoja == 2 && drugaBoja == 1)
        {
            novaBoja = 4;
        }
        else if (prvaBoja == 1 && drugaBoja == 3)
        {
            novaBoja = 5;
        }
        else if (prvaBoja == 3 && drugaBoja == 1)
        {
            novaBoja = 5;
        }
        else if (prvaBoja == 2 && drugaBoja == 3)
        {
            novaBoja = 6;
        }
        else if (prvaBoja == 3 && drugaBoja == 2)
        {
            novaBoja = 6;
        }
        else
        {
            novaBoja = 0;
        }
    }

    void KombinirajBoje(GameObject kutija)
    {
        GetComponent<Ploca>().aktivno = true;
        Instantiate(kutija);
        Destroy(platforma1.GetComponent<PlatformaCrna>().kutija);
        Destroy(platforma2.GetComponent<PlatformaCrna>().kutija);
        platforma1.GetComponent<PlatformaCrna>().kutija = null;
        platforma2.GetComponent<PlatformaCrna>().kutija = null;
        platforma1.GetComponent<PlatformaCrna>().brojKutije = 0;
        platforma2.GetComponent<PlatformaCrna>().brojKutije = 0;
        GetComponent<Ploca>().Invoke("Naprijed", 2.0f);
        GetComponent<Ploca>().Invoke("Natrag", 3.0f);
    }
}
