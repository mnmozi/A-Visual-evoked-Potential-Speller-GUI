using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour
{
    Material material;
    Color changingColor;
    public float colorSeven;

    public string currentScore = "0";
    public bool start;

    // Start is called before the first frame update
    void Start()
    {

        material = GetComponent<Renderer>().material;
        StartCoroutine(GoBlue());

    }

    public void changeCurrent(string data)
    {
        currentScore = data;
    }
    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator GoBlue()
    {


        while (true)
        {
            if (currentScore == "1")
            {
                material.SetColor("_Color", Color.blue);
                yield return new WaitForSeconds(colorSeven);
                material.SetColor("_Color", Color.black);
                yield return new WaitForSeconds(colorSeven);
            }
            else
            {
                yield return new WaitForSeconds(0);
            }


        }

    }
}
