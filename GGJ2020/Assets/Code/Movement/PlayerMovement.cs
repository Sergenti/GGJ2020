using System;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Space,Header("speed and event")]
        [SerializeField] private FloatEvent turnEvent = null; 
        [SerializeField] private float speed = 4f;
        [SerializeField] private float turnSpeed = 0.5f;
        
        [Space,Header("Walkable area check")]
        [SerializeField] private Transform lowerStopCheck;
        [SerializeField] private Transform upperStopCheck;
        [SerializeField] private LayerMask rocketMask;
        [SerializeField] private float radius = 0.5f;

        private Rigidbody2D _rb;
        private Vector2 moveVector; //Direction and strength of movement
        private bool _isAtTop = false;
        private bool _isAtBottom = false;
        
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0f; //We don't have any gravity in our game (at least if we don't fall)
        }

        // Update is called once per frame
        void Update()
        {
            CheckPosition();
            
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0f)
            {
                //If we turn, raise an event that will trigger the rotation of the objects of the scene
                turnEvent.Raise(Input.GetAxis("Horizontal")*Time.deltaTime*turnSpeed); 
            } 
            
            //Compute vertical move vector
            if (Math.Abs(Input.GetAxis("Vertical")) > 0 && !_isAtBottom && !_isAtTop) //We can move freely
            {
              moveVector = new Vector2(0f,Input.GetAxis("Vertical"));  
            }
            else if (Input.GetAxis("Vertical") < 0 && _isAtTop) //We can move down at the top
            {
               moveVector = new Vector2(0f,Input.GetAxis("Vertical"));  
            }
            else if (Input.GetAxis("Vertical") > 0 && _isAtBottom) //We can move up at the bottom
            {
                moveVector = new Vector2(0f,Input.GetAxis("Vertical")); 
            }
            else
            {
                moveVector = Vector2.zero;
            }
        }

        //Check if we are at the top or bottom or none of these
        private void CheckPosition()
        {
            _isAtTop = true;
            foreach (var collider in Physics2D.OverlapCircleAll(upperStopCheck.position, radius, rocketMask))
            {
                //If we detect anything (since it's on the rocket layer) it means we are not at the top
                _isAtTop = false;
            }
            
            _isAtBottom = true;
            foreach (var collider in Physics2D.OverlapCircleAll(lowerStopCheck.position, radius, rocketMask))
            {
                //If we detect anything (since it's on the rocket layer) it means we are not at the top
                _isAtBottom= false;
            }
        }
        
        //We have to apply the translation here because unity stuff
       private void FixedUpdate()
       {
           {
               _rb.MovePosition(_rb.position + moveVector * (speed * Time.fixedDeltaTime)); 
           }
        } 
    }
}
