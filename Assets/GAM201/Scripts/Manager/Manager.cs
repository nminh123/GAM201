using Scripts.Object.Player;
using UnityEngine;

namespace Scripts.Manager.Manager
{
    public class Manager : MonoBehaviour
    {
        private Player mPlayer;
        private CameraFollow mCam;
        private float mTime = 120f;
        [SerializeField] private GameObject endGameObject;
        public float time => mTime;

        void Awake()
        {
            mCam = FindObjectOfType<CameraFollow>();
            mPlayer = FindObjectOfType<Player>();
        }

        void Update()
        {
            isEndGame();
            mTime = Mathf.Max(0, time - Time.deltaTime); // Decrease time, clamp to 0
        }

        void isEndGame()
        {
            checkEndWin(mPlayer.isFinish);
            checkEndLose(mTime);
        }

        void checkEndWin(bool isFinish)
        {
            if (isFinish == true)
            {
                Time.timeScale = 0;
                endGameObject.SetActive(true);
                mCam.enabled = false;
            }
        }

        void checkEndLose(float t)
        {
            if (t <= 0)
            {
                Time.timeScale = 0;
                endGameObject.SetActive(true);
                mCam.enabled = false;
            }
        }

        void particalEnd()
        {

        }
    }
}