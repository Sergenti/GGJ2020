using UnityEngine;

namespace Code.Movement
{
    public class BackGroundScroll : MonoBehaviour
    {
        [SerializeField] private float verticalSpeed = 0.1f;
        [SerializeField] private float magicValue = 0.925f;

        private float initialHeigh;
        // Start is called before the first frame update
        void Start()
        {
            initialHeigh = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down*verticalSpeed*Time.deltaTime);
            if (transform.position.y < initialHeigh - magicValue)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0f, magicValue * 2 + initialHeigh, 0f),
                    Quaternion.identity);
            }
        }

        public void Stop()
        {
            verticalSpeed = 0f;
        }
    }
}
