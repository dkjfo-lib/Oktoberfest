using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Spawner[] spawners;
    [Space]
    public Door[] doors;
    [Space]
    public bool activated = false;
    public bool done = false;
    [Space]
    public DayTimeController Addon_DayTimeController;
    [Range(0, 1f)] public float dayTime = 1f;

    void ActivateRoom()
    {
        activated = true;
        if (Addon_DayTimeController != null) Addon_DayTimeController.SetDayTime(dayTime, 10, .1f);

        foreach (var spawner in spawners)
        {
            spawner.StartSpawning();
        }

        foreach (var door in doors)
        {
            door.Close();
        }

        StartCoroutine(WaitToDeactivate());
    }

    IEnumerator WaitToDeactivate()
    {
        yield return new WaitUntil(() => spawners.All(s => !s.isSpawning && s.spawnedObjects.All(ss => ss == null)));
        DeactivateRoom();
    }

    void DeactivateRoom()
    {
        done = true;

        foreach (var door in doors)
        {
            door.Open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            ActivateRoom();
        }
    }
}
