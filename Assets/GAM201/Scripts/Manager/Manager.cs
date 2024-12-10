using Scripts.Object.Player;
using UnityEngine;

namespace Scripts.Manager.Manager
{
    public class Manager : MonoBehaviour
    {
        private Player mPlayer;
        private CameraFollow mCam;

        void Awake()
        {
            mPlayer = FindObjectOfType<Player>();
            mCam = FindObjectOfType<CameraFollow>();
        }

        void Update()
        {
            checkEnd(mPlayer.isFinish);
        }
        
        void checkEnd(bool isFinish)
        {
            if(isFinish == true)
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