using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGameEvent : MonoBehaviour
{
    private UIDocument mDocument;
    private Button mTryAgainButton;
    private Button mGotoMainMenuButton;
    private AudioSource mAudio;
    private Camera mCam;
    private List<Button> mListButton;

    void Awake()
    {
        mDocument = GetComponent<UIDocument>();
        mTryAgainButton = mDocument.rootVisualElement.Q("TryAgain") as Button;
        mGotoMainMenuButton = mDocument.rootVisualElement.Q("Exit") as Button;
        mAudio = GameObject.Find("sound").GetComponent<AudioSource>();
        mCam = FindObjectOfType<Camera>();
        mListButton = mDocument.rootVisualElement.Query<Button>().ToList();
    }

    void OnEnable()
    {
        mTryAgainButton.RegisterCallback<ClickEvent>(OnClickTryAgain);
        mGotoMainMenuButton.RegisterCallback<ClickEvent>(OnClickGotoMenu);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }

    void OnDisable()
    {
        mTryAgainButton.UnregisterCallback<ClickEvent>(OnClickTryAgain);
        mGotoMainMenuButton.UnregisterCallback<ClickEvent>(OnClickGotoMenu);
        for (int i = 0; i < mListButton.Count; i++)
        {
            mListButton[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }

    void OnClickTryAgain(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        mCam.enabled = true;
        Debug.Log("OnClickTryAgain");
    }

    void OnClickGotoMenu(ClickEvent evt)
    {
        SceneManager.LoadScene(0);
        Debug.Log("OnClickGotoMenu");
    }

    void OnAllButtonClick(ClickEvent evt)
    {
        mAudio.Play();
    }
}