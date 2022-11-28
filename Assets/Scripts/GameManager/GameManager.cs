using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int point;
    public int hp;
    public int currentHp;
    public bool isPaused = false;
    string json;
    JsonPoint data;

    private void Awake()
    {
        GM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        json = File.ReadAllText(Application.persistentDataPath + "/DataPoint.bdi");
        data = JsonUtility.FromJson<JsonPoint>(json);
    }

    void Update()
    {
        Dead();
    }
    
    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
    }

    public void Dead()
    {
        if(currentHp < 1)
        {
            isPaused = true;
            UIManager.UIM.GameOver();
            if (point > data.point)
            {
                SaveJson();
            }
        }
    }
    public void SaveJson()
    {
        data = new JsonPoint();
        data.point = point;
        json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/DataPoint.bdi", json);
    }
}
