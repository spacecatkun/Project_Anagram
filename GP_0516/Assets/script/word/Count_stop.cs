using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_stop : MonoBehaviour
{
    public GameObject R_button;
    private void Update()
    {
        if(count > 30)
        {
            DisE_button();
        }
        else
        {
            E_button();
        }
    }
    private int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        Debug.Log("in" + count);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        Debug.Log("out" + count);
    }
    private void DisE_button()
    {
        R_button.GetComponent<Button>().interactable = false;
    }
    private void E_button()
    {
        R_button.GetComponent<Button>().interactable = true;
    }
}