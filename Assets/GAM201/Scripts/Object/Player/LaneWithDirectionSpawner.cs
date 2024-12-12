using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LaneWithDirectionSpawner : MonoBehaviour
{
    public GameObject road; // GameObject của con đường
    public int numberOfLanes = 6; // Tổng số làn đường
    public GameObject fowardObject;
    public GameObject backfowardObject;


    public Dictionary<int, float> forwarPos;
    public Dictionary<int, float> backwardPos;
    private List<int> keyOfForwardPos;
    private List<int> keyOfBackWardPos;

    private MeshRenderer roadRenderer;

    private List<float> forwardLanePositions; // Làn thuận chiều
    private List<float> backwardLanePositions; // Làn ngược chiều

    private void Awake()
    {
        keyOfForwardPos = new List<int>();
        keyOfBackWardPos = new List<int>();
        roadRenderer = road.GetComponent<MeshRenderer>();
    }
    void Start()
    {
        // Tính toán làn đường thuận/ngược chiều
        forwardLanePositions = CalculateLanes(road, numberOfLanes, true); // Làn thuận
        backwardLanePositions = CalculateLanes(road, numberOfLanes, false); // Làn ngược


        forwarPos = ConvertListToDictionary(forwardLanePositions);
        forwarPos.Remove(WhoIsMostFarestInDict(forwarPos, false));
        keyOfForwardPos.AddRange(forwarPos.Keys);
        backwardPos = ConvertListToDictionary(backwardLanePositions);
        WhoIsMostFarestInDict(backwardPos, false);
        backwardPos.Remove(WhoIsMostFarestInDict(backwardPos, true));
        keyOfBackWardPos.AddRange(backwardPos.Keys);
    }

    public int GetKeyByValue(Dictionary<int, float> dict, float value)
    {
        // Duyệt qua các cặp key-value trong Dictionary
        foreach (KeyValuePair<int, float> entry in dict)
        {
            if (entry.Value == value)
            {
                return entry.Key; // Trả về key khi tìm thấy giá trị trùng khớp
            }
        }
        // Trả về -1 nếu không tìm thấy giá trị trong Dictionary
        return -1;
    }

    public int WhoIsMostFarestInDict(Dictionary<int, float> roads, bool isForward)
    {
        if (isForward == true)
        {
            float maxPos = roadRenderer.bounds.center.x;
            foreach (float posValue in roads.Values)
            {
                if (posValue > maxPos)
                {
                    maxPos = posValue;
                }
            }
            return GetKeyByValue(roads, maxPos);
        }
        if (isForward == false)
        {
            float minPos = 0;
            for (int i = 0; i < roads.Count; i++)
            {
                if (i == 0)
                {
                    minPos = roads[i+1];
                }
                else
                {
                    if (roads[i+1] < minPos)
                    {
                        minPos = roads[i+1];
}
}
}
            return GetKeyByValue(roads, minPos);
        }
        return -1;
    }

    public float GetRandomPosAtDictByList(List<int> sidePosKey , Dictionary<int,float> PosDict)
    {
        if (sidePosKey.Count == 0 || PosDict.Count == 0)
        {
            Debug.Log("Khong con phan tu nao de lay");
        }
        int randomKey;



        randomKey = sidePosKey[Random.Range(0, sidePosKey.Count)];

        float value = PosDict[randomKey];

        sidePosKey.Remove(randomKey);

        return value;
    }

   

    public void SpwanCarByDict(Transform parentObject)
    {
        // random so luong sinh ra Object trong 1 lane sinh ra, max la 3
        for (int i = 0; i < RandomIndex(numberOfLanes/2); i++)
        {
            // random trong dict vi tri lay ra 1 trong 3 vi tri
            float laneX = GetRandomPosAtDictByList(keyOfForwardPos,forwarPos);
            Vector3 spawnPosition = new Vector3(laneX, road.transform.position.y + 0.2f, road.transform.position.z + 10f);
            if (parentObject != null)
            {
             var car = Instantiate(fowardObject, spawnPosition, Quaternion.identity);
                car.gameObject.transform.SetParent(parentObject);
                car.gameObject.GetComponent<CarBehavior>().SetStartPos(spawnPosition);
            }            
        }

        for (int i = 0; i < RandomIndex(numberOfLanes / 2); i++)
        {
            // random trong dict vi tri lay ra 1 trong 3 vi tri
            float laneX = GetRandomPosAtDictByList(keyOfBackWardPos, backwardPos);
            Vector3 spawnPosition = new Vector3(laneX, road.transform.position.y + 0.2f, road.transform.position.z + 10f);
            var car = Instantiate(backfowardObject, spawnPosition, Quaternion.identity);
            car.gameObject.transform.SetParent(parentObject);
            car.gameObject.GetComponent<CarBehavior>().SetStartPos(spawnPosition);
        }
    }

    public int RandomIndex(int maxValue)
    {
        return Random.Range(1, maxValue);
    }
    public Dictionary<int, float> ConvertListToDictionary(List<float> floatList)
    {
        Dictionary<int, float> floatDict = new Dictionary<int, float>();

        for (int i = 0; i < floatList.Count; i++)
        {
            floatDict.Add(i + 1, floatList[i]); // Key bắt đầu từ 1
        }

        return floatDict;
    }

    List<float> CalculateLanes(GameObject road, int totalLanes, bool isForward)
    {
        List<float> positions = new List<float>();

        // Lấy chiều rộng đường từ MeshRenderer
       
        if (roadRenderer == null)
        {
            Debug.LogError("Road object needs a MeshRenderer!");
            return positions;
        }

        float roadWidth = roadRenderer.bounds.size.x;
        float roadCenterX = roadRenderer.bounds.center.x;

        // Chia số làn thành thuận/ngược chiều
        int forwardLanes = Mathf.CeilToInt(totalLanes / 2f); // Làn thuận
        int backwardLanes = totalLanes - forwardLanes; // Làn ngược
        int lanes = isForward ? forwardLanes : backwardLanes;

        // Chiều rộng mỗi làn
        float laneWidth = roadWidth / totalLanes;

        // Dịch tâm dựa trên hướng (thuận/ngược)
        float startX = isForward
            ? roadCenterX - roadWidth / 2 + laneWidth / 2  // Bên phải
            : roadCenterX + laneWidth * backwardLanes - laneWidth / 2;  // Bên trái

        for (int i = 0; i < lanes; i++)
        {
            float laneX = startX + (isForward ? i * laneWidth : -i * laneWidth);
            positions.Add(laneX);
        }

        return positions;
    }

 

}


