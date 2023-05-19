using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_MV : MonoBehaviour
{
    private Vector3 battle = new Vector3(0f, 0f, -10f);
    private Vector3 MK = new Vector3(19.5f, 0f, -10f);
    private bool check_s = true;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(check_s == true)
            {
                transform.position = MK;
                check_s = false;
            }
            else if(check_s == false)
            {
                transform.position = battle;
                check_s = true;
            }
        }
    }
}
