using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text Moneytext;
    // Update is called once per frame
    void Update()
    {
        Moneytext.text = "$ " + PlayerStats.Money;
    }
}
