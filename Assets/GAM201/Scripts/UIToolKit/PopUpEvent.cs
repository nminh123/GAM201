using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopUpEvent : MonoBehaviour
{
    private UIDocument mDocument;
    private AudioManager mMusic;
    private AudioSource mSound;
    private Button mExit;
    private Button mSoundButton;
    private Button mMusicButton;
    private List<Button> mListButton;
    [SerializeField] private GameObject popUp;

    void Awake()
    {
        mSound = GameObject.Find("Sound").GetComponent<AudioSource>();
        mMusic = FindObjectOfType<AudioManager>();
        mDocument = GetComponent<UIDocument>();
        mExit = mDocument.rootVisualElement.Q("Exit") as Button;
        mSoundButton = mDocument.rootVisualElement.Q("Sound") as Button;
        mMusicButton = mDocument.rootVisualElement.Q("Music") as Button;
        mListButton = mDocument.rootVisualElement.Query<Button>().ToList();


        if (mExit == null || mSoundButton == null || mMusicButton == null)
        {
            Debug.LogError("Một hoặc nhiều nút trong UI Toolkit không được tìm thấy!");
        }
    }

    void OnEnable()
    {
        mExit.RegisterCallback<ClickEvent>(OnClickExit);
        mSoundButton.RegisterCallback<ClickEvent>(OnClickSound);
        mMusicButton.RegisterCallback<ClickEvent>(OnClickMusic);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].RegisterCallback<ClickEvent>(OnAllButtonCLick);
        }

        // if (mExit != null) mExit.clicked += OnClickExit;
        // if (mSoundButton != null) mSoundButton.clicked += OnClickSound;
        // if (mMusicButton != null) mMusicButton.clicked += OnClickMusic;
    }


    void OnDisable()
    {
        mExit.UnregisterCallback<ClickEvent>(OnClickExit);
        mSoundButton.UnregisterCallback<ClickEvent>(OnClickSound);
        mMusicButton.UnregisterCallback<ClickEvent>(OnClickMusic);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].UnregisterCallback<ClickEvent>(OnAllButtonCLick);
        }

        // if (mExit != null) mExit.clicked -= OnClickExit;
        // if (mSoundButton != null) mSoundButton.clicked -= OnClickSound;
        // if (mMusicButton != null) mMusicButton.clicked -= OnClickMusic;
    }

    void OnClickExit(ClickEvent evt)
    {
        popUp.SetActive(false);
        Debug.Log("Exit Popup Clicked!!");
    }

    void OnClickSound(ClickEvent evt)
    {
        Debug.Log("Sound Clicked!!");
    }

    void OnClickMusic(ClickEvent evt)
    {
        Debug.Log("Music Clicked!!");
    }

    void OnAllButtonCLick(ClickEvent evt) => mSound.Play();

    // void OnClickExit()
    // {
    //     // Ẩn PopUp
    //     if (popUp != null)
    //     {
    //         popUp.SetActive(false);
    //         Debug.Log("Exit Popup Clicked!!");
    //     }
    // }

    // void OnClickSound()
    // {
    //     Debug.Log("OnClickSound");
    // }

    // void OnClickMusic()
    // {
    //     Debug.Log("OnClickMusic");
    // }
}