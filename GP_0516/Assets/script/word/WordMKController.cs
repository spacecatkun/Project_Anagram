using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WordMKController : MonoBehaviour
{
    public TMP_Text MKword;
    public string word_1;
    public string word_2;
    public string word_3;
    public string word_4;
    public string word_5;
    private string mkingword;
    private string[] c_word = { "ABCDE" };
    private string index;
    private GameObject tower;
    private string path = "M_word/";

    void FixedUpdate()
    {
        mkingword = word_1 + word_2 + word_3 + word_4 + word_5;
        MKword.text = mkingword;
    }

    public void MKbutton()
    {
        index = Array.Find(c_word, element => element == mkingword);
        if(index != null)
        {
            path = path + mkingword;
            tower = Resources.Load<GameObject>(path);
            Instantiate(tower);
        }
        else
        {
            Debug.Log("not");
        }
    }
}