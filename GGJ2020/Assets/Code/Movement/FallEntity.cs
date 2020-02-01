using UnityEngine;

namespace Code.Movement
{
    //This class has just a public method suddenly applying gravity to object ()
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallEntity : MonoBehaviour
    {
        [SerializeField] private float gravity = 1f;

        private Rigidbody2D _rb;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0f; //Before we fall, we don't have any gravity
        }

        public void Fall()
        {
            _rb.gravityScale = gravity;
        }
    }
}
