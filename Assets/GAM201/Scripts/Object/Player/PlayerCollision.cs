using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleNameTag
{
    Road,
    Building
}
public class PlayerCollision : MonoBehaviour
{
    public bool isOnGround;
    public HashSet<GameObject> roadCollides = new HashSet<GameObject>();

    public bool IsPlayerOnGround()
    {
        return isOnGround;
    }

    private void Update()
    {
        if(roadCollides != null)
        {
            CheckDistanceWithRoad(roadCollides);
        }
    }

    private void CheckDistanceWithRoad(HashSet<GameObject> roads)
    {
        foreach (var item in roads)
        {
            float maxSize = 30f;
            if(GetDistance(item) > maxSize)
            {
                item.gameObject.GetComponent<Road>().RemoveALlCar();
                
            }
            if (GetDistance(item) < maxSize && item.gameObject.GetComponent<Road>().isRemoveAllCar == true)
            {
                item.gameObject.GetComponent<Road>().OpenAllCar();
            }
        }
    }

    public float GetDistance(GameObject roadInHash)
    {
        return Vector3.Distance(gameObject.transform.position, roadInHash.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ObstacleNameTag.Road.ToString()))
        {
            if (!roadCollides.Contains(collision.gameObject))
            {
                roadCollides.Add(collision.gameObject);
                //spwan
                collision.gameObject.GetComponent<LaneWithDirectionSpawner>().SpwanCarByDict(collision.gameObject.transform);
            }
      
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(ObstacleNameTag.Road.ToString()))
        {
            isOnGround = true;
   
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(ObstacleNameTag.Road.ToString()))
        {
            isOnGround = false;
        }
    }
}

