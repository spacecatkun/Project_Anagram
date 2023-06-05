using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Alpha_MK : MonoBehaviour
{
    private string[] Alpha = new string[] { "A", "B", "C", "D", "E" };
    private int R_Alpha = 0;
    private string Select_Alpha = "";
    private string path = "Alpha/";
    private string path_2;
    private GameObject Pre_Alpha;
    private Vector3 pos = new Vector3(15f, 1.5f, 0f);
    public GameObject Quiz;

    public void DropWord()
    {
        RandomAlpha();
        Instantiate(Pre_Alpha, pos, Quaternion.Euler(0, 0, 35f));
        Pre_Alpha = null;
        path_2 = null;
    }
    void RandomAlpha()
    {
        R_Alpha = Random.Range(0, 5);
        Select_Alpha = Alpha[R_Alpha];
        path_2 = path + Select_Alpha;
        Pre_Alpha = Resources.Load<GameObject>(path_2);
    }
    public void MKQuiz()
    {
        Instantiate(Quiz, new Vector3(16f, 0, 0), Quaternion.identity);
    }
}
