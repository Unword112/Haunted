using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemySpawner : MonoBehaviour {

    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;

    // Random position will be the position we want to place the object
    Vector2 randomPosition;
    public float xRange = 3f;
    // xRange the range in the x axis that the object can be placed
    public float yRange = 3f;
    // yRange the range in the y axis that the object can be placed
 
    // Start is called before the first frame update
    void Start()
    {
        // xPosition and yPosition are set to random values with the ranges
        float xPosition = Random.Range(15 - xRange, 15 + xRange);
        float yPosition = Random.Range(15 - yRange, 15 + yRange);
        // randomPosition is then given values xPosition and yPosition, making it a random vector
        randomPosition = new Vector2(xPosition, yPosition);
        // randomPosition now describes a random position for our object, so it is then moved to it.
        transform.position = randomPosition;
        // now the object has been moved, completeting the process of placing it in a random position
    }

    private void Update(){
         theCountdown -= Time.deltaTime;
         if(theCountdown <= 0)
         {
             Start();
             theCountdown = waitingForNextSpawn;
         }
    }
 }