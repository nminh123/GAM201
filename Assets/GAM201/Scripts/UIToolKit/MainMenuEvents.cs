using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument mDocument;
    private AudioSource mAudio;
    private Button mStartGameButton;
    private Button mSettingsButton;
    private List<Button> mListButton;
    [SerializeField] private GameObject popUp;

    void Awake()
    {
        mDocument = GetComponent<UIDocument>();
        mAudio = GameObject.Find("Sound").GetComponent<AudioSource>();
        mStartGameButton = mDocument.rootVisualElement.Q("StartGame") as Button;
        mSettingsButton = mDocument.rootVisualElement.Q("Settings") as Button;
        mListButton = mDocument.rootVisualElement.Query<Button>().ToList();
    }
    
    void OnEnable()
    {
        mStartGameButton.RegisterCallback<ClickEvent>(OnStartGameClick);
        mSettingsButton.RegisterCallback<ClickEvent>(OnSettingsClick);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].RegisterCallback<ClickEvent>(OnAllButtonCLick);
        }
    }

    void OnDisable()
    {
        mStartGameButton.UnregisterCallback<ClickEvent>(OnStartGameClick);
        mSettingsButton.UnregisterCallback<ClickEvent>(OnSettingsClick);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].UnregisterCallback<ClickEvent>(OnAllButtonCLick);
        }
    }

    void OnStartGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start Game Clicked!!");
    }

    void OnSettingsClick(ClickEvent evt)
    {
        popUp.SetActive(true);
        Debug.Log("Settings Clicked!!");
    }

    void OnAllButtonCLick(ClickEvent evt) => mAudio.Play();
}