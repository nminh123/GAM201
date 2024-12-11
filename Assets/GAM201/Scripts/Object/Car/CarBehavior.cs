using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Same,
    Opposite
}
public class CarBehavior : MonoBehaviour
{
    public float movingSpeed;
    public Vector3 startPos;
    public Direction dirCarVersusPlayer;
    private Vector3 directionVector;
   
    public bool isOnRoad;

    // Start is called before the first frame update
    void Start()
    {
         directionVector = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovingCar(movingSpeed, dirCarVersusPlayer, directionVector);
    }

    // moving car without the direction
    private void MovingCar(float movingSpeed, Direction direction, Vector3 directionVector)
    {
        directionVector = direction == Direction.Same ? directionVector : -directionVector;
        gameObject.transform.position += directionVector.normalized * movingSpeed * Time.deltaTime;

    }

    public void SetStartPos(Vector3 postion)
    {
        startPos = postion;
    }


}
