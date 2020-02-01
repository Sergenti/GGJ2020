using Code.Item;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class MaterialDisplay : MonoBehaviour
    {
        
    private TextMeshProUGUI _text;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
    
        public void DisplayMaterialName(RepairMaterial material)
        {
            _text.text = material.Name;
        }
    }
}