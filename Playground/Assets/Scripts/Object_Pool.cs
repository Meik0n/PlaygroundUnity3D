using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    public static Object_Pool shared_instance;
    public List<GameObject> pooled_objects;
    public GameObject object_to_pool;
    public int amount_to_pool;

    void Awake()
    {
        shared_instance = this;
    }
    void Start()
    {
        pooled_objects = new List<GameObject>();
        GameObject temp;

        for (int i = 0; i < amount_to_pool; ++i)
        {
            temp = Instantiate(object_to_pool);
            temp.SetActive(false);
            pooled_objects.Add(temp);
        }
    }

    public GameObject Get_Pooled_Object()
    {
        for (int i = 0; i < amount_to_pool; ++i)
        {
            if (!pooled_objects[i].activeInHierarchy)
            {
                return pooled_objects[i];
            }
        }
        return null;
    }
}
