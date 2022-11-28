using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "Player")
    {
      GameManager.GM.currentHp += NPc.healDealer;
      col.gameObject.SetActive(false);
    }
    if (col.tag == "Enemy")
    {
      GameManager.GM.currentHp -= Zombie.damageDealer;
      col.gameObject.SetActive(false);
    }

  }
}
