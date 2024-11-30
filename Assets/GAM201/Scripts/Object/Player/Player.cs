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

        void Awake()
        {
            consts = GameObject.Find("Manager").GetComponent<Consts>();
            mRigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            mSpeed = consts.gSpeed;
        }

        void Update()
        {
            Input();
        }

        void Input()
        {
            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");

            Vector3 move = new Vector3(horizontal, 0, vertical);
            mRigidbody.velocity = move * mSpeed;
        }
    }
}