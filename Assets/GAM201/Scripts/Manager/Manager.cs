using Scripts.Object.Player;
using UnityEngine;

namespace Scripts.Manager.Manager
{
    public class Manager : MonoBehaviour
    {
        private Player mPlayer;
        private CameraFollow mCam;
        [SerializeField] private GameObject endGameObject;

        void Awake()
        {
            mCam = FindObjectOfType<CameraFollow>();
            mPlayer = FindObjectOfType<Player>();
        }

        void Update()
        {
            checkEnd(mPlayer.isFinish);
        }

        void checkEnd(bool isFinish)
        {
            if (isFinish == true)
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