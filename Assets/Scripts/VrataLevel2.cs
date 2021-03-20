using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrataLevel2 : MonoBehaviour
{
    public GameObject platforma;
    public Rigidbody vrata;
    float masa;
    public float visina;
    public float ukupnaMasa;

    private void Update()
    {
        if (gameObject.transform.position.y >= 2.0f)
        {
            vrata.velocity = Vector3.zero;
        }
    }

    public void PodigniVrata(float mass)
    {
        masa = mass;
        Vector3 podizanje = new Vector3(0.0f, (masa / ukupnaMasa) * visina, 0.0f);
        gameObject.transform.Translate(podizanje);
    }
}
