using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracMis : MonoBehaviour
{
    Vector2 pomakMisa;
    Vector2 glatkiPomak;
    float osjetljivost = 3.0f;
    float glatkoca = 1.8f;

    GameObject Igrac;

    void Start()
    {
        Igrac = this.transform.parent.gameObject;
    }

    void Update()
    {
        var promjenaMisa = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        promjenaMisa = Vector2.Scale(promjenaMisa, new Vector2(osjetljivost * glatkoca, osjetljivost * glatkoca));
        glatkiPomak.x = Mathf.Lerp(glatkiPomak.x, promjenaMisa.x, 1f / glatkoca);
        glatkiPomak.y = Mathf.Lerp(glatkiPomak.y, promjenaMisa.y, 1f / glatkoca);
        pomakMisa += glatkiPomak;
        pomakMisa.y = Mathf.Clamp(pomakMisa.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-pomakMisa.y, Vector3.right);
        Igrac.transform.localRotation = Quaternion.AngleAxis(pomakMisa.x, Igrac.transform.up);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }
}
