using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordMKController : MonoBehaviour
{
    public TMP_Text MKword;
    public string word_1;
    public string word_2;
    public string word_3;
    public string word_4;
    public string word_5;
    private string mkingword;

    void Update()
    {
        mkingword = word_1 + word_2 + word_3 + word_4 + word_5;
        MKword.text = mkingword;
    }
}
