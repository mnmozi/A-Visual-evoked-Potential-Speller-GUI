using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour
{
    Material material;
    Color changingColor;
    public float colorSeven;
    public int  id ;
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
                material.SetColor("_Color" , (new Color32(0,255,0,255)) );
                yield return new WaitForSeconds(colorSeven);
            }
            if (currentScore == "1")
            {
                material.SetColor("_Color", Color.black);
                yield return new WaitForSeconds(colorSeven);
            }
            if (currentScore == "-1")
            {
                material.SetColor("_Color", (new Color32(0, 255, 0, 255)));
                yield return new WaitForSeconds(colorSeven);
            }
            else {
                material.SetColor("_Color", Color.black);
                yield return new WaitForSeconds(0);
            }


        }

    }
}
