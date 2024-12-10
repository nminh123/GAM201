using Scripts.Object.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Manager.Manager
{
    public class Manager : MonoBehaviour
    {
        private Player mPlayer;
        private CameraFollow mCam;

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
                mCam.enabled = false;
            }
        }

        void particalEnd()
        {

        }
    }
}