using System;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementHandler : MonoBehaviour
    {
        private Rigidbody2D _rb = null;
        private Vector2 moveVector = Vector2.zero;
        private bool _isFalling = false;

        [SerializeField] private FloatEvent turnEvent = null;
        [SerializeField] private float speed = 4f;
        [SerializeField] private float turnSpeed = 0.5f;
        [SerializeField] private Transform lowerStopCheck;
        [SerializeField] private Transform upperStopCheck;
        [SerializeField] private LayerMask rocketMask;
        [SerializeField] private VoidEvent fallEvent;

        public bool debug = false;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (debug)
            {
                Fall();
                debug = false;
            }
            
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0f)
            {
               turnEvent.Raise(Input.GetAxis("Horizontal")*Time.deltaTime*turnSpeed); 
            }
            
            moveVector = new Vector2(0f,Input.GetAxis("Vertical")); 
        }

        private void FixedUpdate()
        {
            if(!_isFalling){
           _rb.MovePosition(_rb.position + moveVector * (speed * Time.fixedDeltaTime)); 
           }
        }

        public void Fall()
        {
            _isFalling = true;
            _rb.gravityScale = 10f;
        }
    }
}
