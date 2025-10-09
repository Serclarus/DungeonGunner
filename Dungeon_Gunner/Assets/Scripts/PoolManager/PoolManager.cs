using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Tooltip("Put this array with prefabs that you want to add to the pool, and specify the number of gameobjects to be created for each.")]
    [SerializeField] private Pool[] poolArray = null;
    private Transform objectPoolTransform;
    private Dictionary<int, Queue<Component>> poolDictionary = new Dictionary<int, Queue<Component>>();

    [System.Serializable]
    public struct Pool
    {
        public int poolSize;
        public GameObject prefab;
        public string componentType;
    }

    private void Start()
    {
        // This singleton gameobject will be the object pool parent
        objectPoolTransform = this.gameObject.transform;

        // Create object pools on start
        for (int i = 0; i < poolArray.Length; i++)
        {
            CreatePool(poolArray[i].prefab, poolArray[i].poolSize, poolArray[i].componentType);
        }
    }


    void CreatePool(GameObject prefab, int poolSize, string componentType)
    {
        int poolKey = prefab.GetInstanceID();

        string prefabName = prefab.name; // get prefab name

        GameObject parentGameObject = new GameObject(prefabName + "Anchor"); // create parent gameObject to parent the child objects to
        parentGameObject.transform.SetParent(objectPoolTransform);

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<Component>());
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(prefab, parentGameObject.transform) as GameObject;

            newObject.SetActive(false);

            poolDictionary[poolKey].Enqueue(newObject.GetComponent(Type.GetType(componentType)));
        }
    }

    public Component ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if (poolDictionary.ContainsKey(poolKey))
        {
            // Get object from pool queue
            Component componentToReuse = GetComponentFromPool(poolKey);

            ResetObject(position, rotation, componentToReuse, prefab);

            return componentToReuse;
        }
        else
        {
            Debug.Log("No pool for " + prefab);
            return null;
        }
    }

    private Component GetComponentFromPool(int poolKey)
    {
        Component componentToReuse = poolDictionary[poolKey].Dequeue();
        poolDictionary[poolKey].Enqueue(componentToReuse);

        if (componentToReuse.gameObject.activeSelf == true)
        {
            componentToReuse.gameObject.SetActive(true);
        }

        return componentToReuse;
    }

    private void ResetObject(Vector3 position, Quaternion rotation, Component componentToReuse, GameObject prefab)
    {
        componentToReuse.transform.position = position;
        componentToReuse.transform.rotation = rotation;
        componentToReuse.gameObject.transform.localScale = prefab.transform.localScale;
    }

    #region Validation

    /// <summary>
    /// Called when the script is loaded or a value changes in the Inspector
    /// </summary>
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(poolArray), poolArray);
    }

    #endregion

}
