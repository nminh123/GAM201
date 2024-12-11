using Scripts.Manager.Manager;
using TMPro;
using UnityEngine;

public class TimeListener : MonoBehaviour
{
    private Manager mManager;
    private TMP_Text timeText;

    void Awake()
    {
        mManager = FindObjectOfType<Manager>();
        timeText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        // Assuming mManager.time is already decreasing elsewhere
        timeText.text = Mathf.Max(0, mManager.time).ToString("F0"); // Display time with 2 decimal places
    }
}