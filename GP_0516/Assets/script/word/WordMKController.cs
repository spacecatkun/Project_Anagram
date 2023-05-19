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
    public int MK_remove = 0;
    public int MK_reset = 0;
    public int MK_count = 0;


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
            MK_remove = MK_count;
            word_1 = null;
            word_2 = null;
            word_3 = null;
            word_4 = null;
            word_5 = null;
            MK_count = 0;
        }
        else
        {
            MK_reset = MK_count;
            word_1 = null;
            word_2 = null;
            word_3 = null;
            word_4 = null;
            word_5 = null;
            MK_count = 0;
        }
    }
}