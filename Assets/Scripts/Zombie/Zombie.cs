using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float speed;
    int point = 1;
    public int damage;
    public static int damageDealer;
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        damageDealer = damage;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.isPaused == true) 
        { 
            _animator.SetBool("IsRun", false); 
            return;
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
        _animator.SetBool("IsRun", true);
    }

    private void OnMouseDown()
    {
        SoundManager.SM.SfxPlay("SFXClick");
        gameObject.SetActive(false);
        GameManager.GM.point += point;
    }
}
