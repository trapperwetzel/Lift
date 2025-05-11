using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    public Transform parent;

    public void RegisterExistingObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            string key = obj.name;
            if (!poolDictionary.ContainsKey(key))
            {
                poolDictionary[key] = new Queue<GameObject>();
            }

            obj.SetActive(false);
            poolDictionary[key].Enqueue(obj);
        }
    }

    public GameObject GetObject(string key)
    {
        if (poolDictionary.ContainsKey(key) && poolDictionary[key].Count > 0)
        {
            GameObject obj = poolDictionary[key].Dequeue();
            obj.SetActive(true);
            return obj;
        }

        Debug.LogWarning($"No object of type {key} in the pool!");
        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        string key = obj.name;
        obj.SetActive(false);

        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new Queue<GameObject>();
        }

        poolDictionary[key].Enqueue(obj);
    }
}
