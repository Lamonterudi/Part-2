using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneSpawner : MonoBehaviour

{
    public GameObject PlanespawnerPrefab;
    public Transform spawnPoint;
    float spawnTimer;
    float speed= 1;
        // Start is called before the first frame update
    void Start()
    {
}

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 5f)
        {
            spawnTimer = 0;

            GameObject plane = Instantiate(PlanespawnerPrefab);
            plane.transform.Rotate(new Vector3(0, 0, Mathf.Rad2Deg * Random.Range(0, 360)));
            plane.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            plane.GetComponent<Rigidbody2D>().velocity = Random.Range(1, 3) * transform.up;
        }
    }

}
