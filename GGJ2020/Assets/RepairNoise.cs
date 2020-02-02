using System;
using System.Collections;
using System.Collections.Generic;
using Code.Item;
using UnityEngine;

public class RepairNoise : MonoBehaviour
{
    [SerializeField] private List<NoiseMaterial> link = new List<NoiseMaterial>();

    private AudioManager manager;

    private void Start()
    {
        manager = GetComponent<AudioManager>();
    }

    public void PlayRightNoise(RepairMaterial type)
    {
        foreach (var noiseMaterial in link)
        {
            if (noiseMaterial.material == type)
            {
               manager.Play(noiseMaterial.sounName); 
            }
        }
    }
    
    [System.Serializable]
    private struct NoiseMaterial
    {
        public RepairMaterial material;
        public string sounName;
    }
}
