using System.Collections.Generic;
using UnityEngine;

public class PoolDictionary 
{
    private static Dictionary<string, Queue<GameObject>> _pool = new Dictionary<string, Queue<GameObject>>();
    
    private static Dictionary<string, GameObject> _resourceCache = new Dictionary<string, GameObject>();

    public static GameObject GetGameObject(string objectName)
    {
        if (_pool.TryGetValue(objectName, out var queue))
        {
            if (queue.Count == 0)
            {
                return CreateNewGameObject(objectName);
            }
            else
            {
                var result = queue.Dequeue();
                result.SetActive(true);
                return result;
            }
        }

        return CreateNewGameObject(objectName);
    }

    private static GameObject CreateNewGameObject(string objectName)
    {
        if (_resourceCache.TryGetValue(objectName, out var prefabCache))
        {
            var result = GameObject.Instantiate(prefabCache);
            result.name = objectName;
            return result;
        }
        else
        {
            var prefab = Resources.Load<GameObject>(objectName);
            _resourceCache.Add(objectName, prefab);

            var result = GameObject.Instantiate(prefab);
            result.name = objectName;
            return result;
        }  
    }

    public static void ReturnGameObject(GameObject gameObject)
    {
        if (_pool.TryGetValue(gameObject.name, out var queue))
        {
            queue.Enqueue(gameObject);
        }
        else
        {
            var newQueue = new Queue<GameObject>();
            newQueue.Enqueue(gameObject);
            _pool.Add(gameObject.name, newQueue);
        }

        gameObject.SetActive(false);
    }
}
