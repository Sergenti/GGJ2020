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

        [SerializeField] private FloatEvent turnEvent = null;
        [SerializeField] private float speed = 4f;
        [SerializeField] private Transform lowerStopCheck;
        [SerializeField] private Transform upperStopCheck;
        [SerializeField] private LayerMask rocketMask;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetAxis("Horizontal") > 0f)
            {
               turnEvent.Raise(Input.GetAxis("Horizontal")); 
            }
            
            moveVector = new Vector2(0f,Input.GetAxis("Vertical")); 
        }

        private void FixedUpdate()
        {
           _rb.MovePosition(_rb.position + moveVector * (speed * Time.fixedDeltaTime)); 
        }
    }
}
