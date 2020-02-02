using UnityEngine;

namespace Code.Item
{
    [CreateAssetMenu(menuName = "Item/Material")]
    public class RepairMaterial : Item
    {
        [SerializeField] private string repairSound;
        public string RepairSound
        {
            get => repairSound;
            set => repairSound = value;
        }
    }
}