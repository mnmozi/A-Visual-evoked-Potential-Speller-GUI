using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class sqParent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public List<GameObject> squares;
    public List<GameObject> textFields;
    public GameObject Tarrow;
    public GameObject Ttext;
    public static bool train;
    public static bool arrowB;
    public static bool testB;
    public static char[] newData;
    void Start()
    {
        //ListAllChildren();
        StartCoroutine(trainMethod());
        Tarrow.SetActive(false);
        Ttext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ListAllChildren()
    {

        //squares[0].GetComponent<change_color>().currentScore = "1";
        foreach (Transform child in parent.transform)
        {
            Debug.Log(child.gameObject.name);
        }
    }
    public static void changeData(string data)
    {
        newData = data.ToCharArray();
        if (newData[0] == 't')
        {
            Debug.Log("T");
            newData = newData.Skip(1).ToArray();
            arrowB = true;
        }
        else
        {
            testB = true;
        }
        


    }
    public void training_control(int trainTurn)
    {
        for (int i = 0; i <5;i++)
        {
            if (trainTurn == i || trainTurn== -1 )
            {
                squares[i].GetComponent<change_color>().changeCurrent("1");
            }
            else
            {
                squares[i].GetComponent<change_color>().changeCurrent("0");
            }
        }
    }
    public void TfieldsV(Boolean visibility)
    {
        foreach (GameObject tfield in textFields)
        {
            tfield.gameObject.SetActive(visibility);
        }
    }
    public void arrowTime(int ArrowPos)
    {
        switch (ArrowPos)
        {
            case 0:
                Tarrow.transform.position = new Vector3(-8.5f,1f,0f);
                Ttext.transform.position = new Vector3(-8.5f, -0.2f, 0f);
                squares[ArrowPos].GetComponent<change_color>().changeCurrent("-1");
                break;
            case 1:
                Tarrow.transform.position = new Vector3(0f, 1f, 0f);
                Ttext.transform.position = new Vector3(0f, -0.2f, 0f);
                squares[ArrowPos].GetComponent<change_color>().changeCurrent("-1");
                break;
            case 2:
                Tarrow.transform.position = new Vector3(8.5f, 1f, 0f);
                Ttext.transform.position = new Vector3(8.5f, -0.2f, 0f);
                squares[ArrowPos].GetComponent<change_color>().changeCurrent("-1");
                break;
            case 3:
                Tarrow.transform.position = new Vector3(-4.2f, -2.9f, 0f);
                Ttext.transform.position = new Vector3(-4.2f, -4f, 0f);
                squares[ArrowPos].GetComponent<change_color>().changeCurrent("-1");
                break;
            case 4:
                Tarrow.transform.position = new Vector3(4.2f, -2.9f, 0f);
                Ttext.transform.position = new Vector3(4.2f, -4f, 0f);
                squares[ArrowPos].GetComponent<change_color>().changeCurrent("-1");
                break;
        }
    }
    IEnumerator trainMethod()
    {
        while (true)
        {
            if (train)
            {
                TfieldsV(false);
                char sqNumber = newData[0];
                int sqINumber = sqNumber - '0';
                sqINumber = sqINumber - 1;
                Debug.Log("it issssssss " + (sqINumber));
                switch (sqINumber)
                {
                    case 0:
                        training_control(0);
                        break;
                    case 1:
                        training_control(1);
                        break;
                    case 2:
                        training_control(2);
                        break;
                    case 3:
                        training_control(3);
                        break;
                    case 4:
                        training_control(4);
                        break;
                }
                newData = newData.Skip(1).ToArray();
                arrowB = true;
                train = false;
                if (newData.Length == 0)
                {
                    arrowB = false;
                }
                yield return new WaitForSeconds(5);
            }
            else if (arrowB)
            {
                TfieldsV(false);
                training_control(-2);
                char sqNumber = newData[0];
                int sqINumber = sqNumber - '0';
                sqINumber = sqINumber - 1;
                Debug.Log("it is arrow number" + (sqINumber));

                switch (sqINumber)
                {
                    case 0:
                        arrowTime(0);
                        break;
                    case 1:
                        arrowTime(1);
                        break;
                    case 2:
                        arrowTime(2);
                        break;
                    case 3:
                        arrowTime(3);
                        break;
                    case 4:
                        arrowTime(4);
                        break;
                }
                Tarrow.SetActive(true);
                Ttext.SetActive(true);
                arrowB = false;
                train = true;
                yield return new WaitForSeconds(5);
                Tarrow.SetActive(false);
                Ttext.SetActive(false);
            }
            else
            {
                TfieldsV(true);

                training_control(-1);
                yield return new WaitForSeconds(0);
            }
            //yield return new WaitForSeconds(5);

        }
    }


}
