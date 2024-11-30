using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RestartClickEvent : MonoBehaviour
{
    private UIDocument mDocument;
    private Button mRestartButton;

    void Awake()
    {
        mDocument = GetComponent<UIDocument>();
        mRestartButton = mDocument.rootVisualElement.Q("RestartButton") as Button;
        mRestartButton.RegisterCallback<ClickEvent>(OnRestartButtonClick);
    }

    void OnDisable()
    {
        mRestartButton.UnregisterCallback<ClickEvent>(OnRestartButtonClick);
    }

    private void OnRestartButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(0);
        Debug.Log("You Pressed Restart Button");
    }
}