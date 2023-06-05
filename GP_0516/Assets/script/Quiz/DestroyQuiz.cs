using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyQuiz : MonoBehaviour
{
    public GameObject Quiz;
    void Update()
    {
        if(QuizManager.lasttime == 0)
        {
            Destroy(Quiz);
            Debug.Log("111");
        }
    }
}
