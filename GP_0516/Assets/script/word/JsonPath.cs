using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonPath : MonoBehaviour
{
    void Start()
    {
        string filePath = "Assets/Resources/Json/c_word.json";
        string json = File.ReadAllText(filePath);
    }
}
