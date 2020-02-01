using UnityEngine;

namespace Code.Movement
{
    public class SpriteTurn : MonoBehaviour
    {
        [SerializeField] private SpriteMask mask;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Turn(float amount)
        {
           transform.Translate(new Vector3(-amount,0f));
           if (mask != null)
           {
               mask.transform.Translate(new Vector3(amount,0f));
           }
        }
    }
}
