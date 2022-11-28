using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NPc : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int heal;
    public static int healDealer;
    // Start is called before the first frame update
    void Start()
    {
        healDealer = heal;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        GameManager.GM.currentHp -= (GameManager.GM.currentHp/2);
        gameObject.SetActive(false);
    }
}
