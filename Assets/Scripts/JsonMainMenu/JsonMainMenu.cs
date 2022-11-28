using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class JsonMainMenu : MonoBehaviour
{
    private JsonPoint data;
    private string json;
    
    [SerializeField] TMP_Text hishscoreTxt;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/DataPoint.bdi"))
        {
            data = new JsonPoint();
            json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/DataPoint.bdi", json);
        }
        loadJson();
    }

    private void loadJson()
    {
        json = File.ReadAllText(Application.persistentDataPath + "/DataPoint.bdi");
        data = JsonUtility.FromJson<JsonPoint>(json);
        hishscoreTxt.text = data.point.ToString();
    }
}
