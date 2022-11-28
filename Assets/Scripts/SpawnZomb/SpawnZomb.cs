using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZomb : MonoBehaviour
{
    [SerializeField] Zombie zombiePref;
    [SerializeField] NPc _nPc;
    [SerializeField] List<Zombie> list = new List<Zombie>();
    [SerializeField] List<NPc> listNpc = new List<NPc>();
    [SerializeField] int sizePool;


    [SerializeField] Vector2 randomDmg;

    [SerializeField] Vector2 maxX;

    [SerializeField] Vector2 randomCD;

    [SerializeField] Vector2 randomSpeed;


    float CurrentCD;
    // Start is called before the first frame update
    void Start()
    {
        ObjectPooling.Ins(zombiePref, sizePool,list, transform);
        ObjectPooling.Ins(_nPc, sizePool,listNpc, transform);
        // for (int i = 0; i < sizePool; i++)
        // {
        //     var zom = Instantiate(zombiePref, transform);
        //     zom.gameObject.SetActive(false);
        //     zom.enabled = false;    
        //     list.Add(zom);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.isPaused == true) return;
        if(CurrentCD > 0)
        {
            CurrentCD -= Time.deltaTime;
        }
        else
        {
            var minMaxXNPC = Random.Range(maxX.x, maxX.y);
            CurrentCD = Random.Range(randomCD.x, randomCD.y);
            ZombieSpawned();
            ObjectPooling.Activated(_nPc,true,listNpc,transform,new Vector3(minMaxXNPC, transform.position.y));
        }
    }

    private void ZombieSpawned()
    {
        var minMaxX = Random.Range(maxX.x, maxX.y);

        Zombie obj = ObjectPooling.GetObjectPool(zombiePref, true, list, transform);
        obj.transform.position = new Vector3(minMaxX, transform.position.y);
        obj.gameObject.SetActive(true);
        obj.enabled = true;
        obj.speed = Random.Range(randomSpeed.x, randomSpeed.y);
        obj.damage = (int)Random.Range(randomDmg.x, randomDmg.y);
    }
    //
    // Zombie GetZombiePooled()
    // {
    //     for (int i = 0; i < list.Count; i++)
    //     {
    //         if (!list[i].gameObject.activeInHierarchy)
    //         {
    //             return list[i];
    //         }
    //     }
    //     return null;
    // }
}
