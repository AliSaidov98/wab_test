using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private float pointCount;

    [SerializeField] private int minRotSCount;
    [SerializeField] private int maxRotSCount;

    
    [SerializeField]
    private GameObject parentPoint;
    
    [SerializeField]
    private GameObject currentPoint;

    [SerializeField] private float pointLength;

    [SerializeField] private GameObject pointForward;
    [SerializeField] private GameObject pointLeft;
    [SerializeField] private GameObject pointRight;

    private int forwardPointsCount = 0;
    
    private bool leftSpawned = false;
    private bool rightSpawned = false;

    private int randomSpawn;
    
    private void Start()
    {
       Spawn();
    }

    private void Update()
    {
        
    }

    private void Spawn()
    {
        randomSpawn = Random.Range(minRotSCount, maxRotSCount);
        
        for (int i = 0; i < pointCount; i++)
        {
            Vector3 newPosition = currentPoint.transform.position + currentPoint.transform.forward * pointLength;
            
            
            if (forwardPointsCount == randomSpawn)
            {
                LeftOrRight(newPosition);
                forwardPointsCount = 0;
                randomSpawn = Random.Range(minRotSCount, maxRotSCount);
            }
            else
            {
                SpawnRoad(pointForward, newPosition, currentPoint.transform.rotation);
                forwardPointsCount++;
            }
        }
    }

    private void SpawnRoad(GameObject pointType, Vector3 position, Quaternion rotation)
    {
        currentPoint = Instantiate(pointType, position, rotation);
        currentPoint.transform.parent = parentPoint.transform;
    }

    private void LeftOrRight(Vector3 position)
    {
        int random = Random.Range(0, 2);
        if (random > 0 && !leftSpawned)
        {
            SpawnRoad(pointLeft, position, RotatePoint(-90));
            rightSpawned = false;
            leftSpawned = true;
        }
        else if(random <= 0 && !rightSpawned)
        {
            SpawnRoad(pointRight, position, RotatePoint(90));
            rightSpawned = true;
            leftSpawned = false;
        }
    }

    private Quaternion RotatePoint(int angle)
    {
        return Quaternion.Euler(currentPoint.transform.eulerAngles + Vector3.up * angle);
    }
}
