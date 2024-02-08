using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject DaggerPrefab;
    // Start is called before the first frame update
    public void DaggerSpawner()
    {
        Instantiate(DaggerPrefab);
    }
}
