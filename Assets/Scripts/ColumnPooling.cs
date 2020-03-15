using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPooling : MonoBehaviour
{

    private GameObject[] Columns;
    public int PoolSize = 5;
    public GameObject ColumnPrefab;
    private Vector2 PoolPosition = new Vector2(-15f, -25f);

    public float SpawnRate = 4f;
    public float ColumnMin = 5f;
    public float ColumnMax = 10f;
    private float SpawnXPosition = 10f;
    private float SpawnYPosition;
    public float TimeSinceLastRespawned;
    public int CurrentColumn;


    void Start()
    {
        Columns = new GameObject[PoolSize];
        for (int i = 0; i < PoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(ColumnPrefab, PoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        TimeSinceLastRespawned += Time.deltaTime;

        if(GameController.instance.IsBirdDead == false)
        {
            if(TimeSinceLastRespawned >= SpawnRate)
            {
                TimeSinceLastRespawned = 0;
                SpawnYPosition = Random.Range(ColumnMin,ColumnMax);     
                Columns[CurrentColumn].transform.position = new Vector2(SpawnXPosition,SpawnYPosition);
                CurrentColumn++;
                if(CurrentColumn >= PoolSize)
                {
                    CurrentColumn = 0;
                }           
            }
        }
    }
}
