using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject markerEffect;
    private GameObject last;
    private GameObject last1;
    private GameObject last2;
    private bool green = false;
    private bool red = false;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var markCount = GameObject.FindGameObjectsWithTag("Marker");
                if (hit.collider.tag == "Road")
                {
                    ParticleSystem.MainModule settings = markerEffect.GetComponent<ParticleSystem>().main;

                    if (markCount.Length == 1)
                    {
                        settings.startColor = Color.green;
                        green = true;
                    }
                    if (green)
                    {
                        last = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, 0.05f), Quaternion.identity);
                        Destroy(last, 2);
                        green = false;
                    }
                    if (markCount.Length == 2)
                    {
                        settings.startColor = Color.red;
                        red = true;
                    }
                    if (markCount.Length == 3 && markCount[1].GetComponent<ParticleSystem>().main.startColor.color == Color.red)
                    {
                        markCount[2].transform.position = markCount[1].transform.position;
                        Destroy(markCount[1]);
                    }
                    if (red)
                    {
                        last1 = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, 0.05f), Quaternion.identity);
                        Destroy(last1, 2);
                        settings.startColor = Color.green;
                        last2 = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, -5.0f), Quaternion.identity);
                        Destroy(last2, 2);
                        red = false;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var markCount = GameObject.FindGameObjectsWithTag("Marker");
                if (hit.collider.tag == "Road")
                {                       
                    ParticleSystem.MainModule settings = markerEffect.GetComponent<ParticleSystem>().main;

                    if (markCount.Length == 1)
                    {
                        settings.startColor = Color.green;
                        green = true;
                    }
                    if (green)
                    {
                        last = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, 0.05f), Quaternion.identity);
                        Destroy(last, 2);
                        green = false;
                    }
                    if (markCount.Length == 2)
                    {
                        settings.startColor = Color.red;
                        red = true;
                    }
                    if (markCount.Length == 3 && markCount[1].GetComponent<ParticleSystem>().main.startColor.color == Color.red)
                    {
                        markCount[2].transform.position = markCount[1].transform.position;
                        Destroy(markCount[1]);
                    }
                    if (red)
                    {
                        last1 = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, 0.05f), Quaternion.identity);
                        Destroy(last1, 1.5F);
                        settings.startColor = Color.green;
                        last2 = Instantiate(markerEffect, hit.point - new Vector3(0.0f, 0.0f, -5.0f), Quaternion.identity);
                        Destroy(last2, 1.5F);
                        red = false;
                    }
                }
            }
        }
    }
}