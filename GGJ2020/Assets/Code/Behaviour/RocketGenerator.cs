using System.Collections.Generic;
using UnityEngine;

namespace Code.Behaviour
{
    public class RocketGenerator : MonoBehaviour
    {
        
        [SerializeField] private List<GameObject> objPossible = new List<GameObject>();
        [SerializeField] private int amount = 4;
        [SerializeField] private float SIZE = 1f;
        
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < amount; i++)
            {
                int type = Random.Range(0, objPossible.Count - 1);
                var newRocket = Instantiate(objPossible[type], new Vector3(0f, i * SIZE, 0f), Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
