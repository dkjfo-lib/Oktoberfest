using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroySpawn : MonoBehaviour
{
    public List<SpawnObject> spawnList;

    private void OnDestroy()
    {
        foreach (var item in spawnList)
        {
            var newitem = Instantiate(item.item, transform.position, Quaternion.identity);
            if (item.deleteAfter > 0)
            {
                Destroy(newitem.gameObject, item.deleteAfter);
            }
        }
    }
}

[System.Serializable]
public struct SpawnObject
{
    public GameObject item;
    public float deleteAfter;
}