using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooling
{
    public static void Ins<G>(G prefabs, int size, List<G> list, Transform parent) where G : Component
    {
        for (int i = 0; i < size; i++)
        {
            G obj = GameObject.Instantiate(prefabs, parent);
            obj.gameObject.SetActive(false);
            list.Add(obj);
        }
    }

    public static G GetObjectPool<G>(G prefabs, bool expandable, List<G> list, Transform parent) where G : Component
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy) return list[i];
        }

        if (expandable)
        {
            G obj = GameObject.Instantiate(prefabs, parent);
            obj.gameObject.SetActive(false);
            list.Add(obj);
        }
        return null;
    }

    public static void Activated<G>(G prefabs, bool expandable, List<G> list, Transform parent, Vector3 titikSpawn) where G : Component
    {
        G obj = GetObjectPool<G>(prefabs, expandable, list, parent);
        if (obj != null)
        {
            obj.transform.position = titikSpawn;
            obj.gameObject.SetActive(true);
        }
    }
}
