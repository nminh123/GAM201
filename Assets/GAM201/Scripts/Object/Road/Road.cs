using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public bool isRemoveAllCar = false;
    public void RemoveALlCar()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            isRemoveAllCar = true;
        }
    }

    public void OpenAllCar()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            child.gameObject.transform.position = child.gameObject.GetComponent<CarBehavior>().startPos;
            isRemoveAllCar = false;
        }
    }

}


