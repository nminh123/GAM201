using UnityEngine;
using Scripts.Manager;

namespace Scripts.Object.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Consts consts;
        private float mSpeed;
        private Rigidbody mRigidbody;
        private bool mIsFinish = false;
        public bool isFinish => mIsFinish;
        private bool mIsHit = false;
        public bool isHit => mIsHit;

        void Awake()
        {
            consts = GameObject.Find("Manager").GetComponent<Consts>();
            mRigidbody = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Finish"))
            {
                mIsFinish = true;
            }

            if(other.gameObject.CompareTag("Car"))
            {
                mIsHit = true;
            }
        }
    }
}