using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioManager Manager;
    public LoopManager Loop;
    // Start is called before the first frame update
    void Start()
    {
        
        //Manager.Play("detachement_module"); //change the name in the function to test the song playing 
        Manager.Play("alarme_fuel");
        Loop.Play("thruster");//change the name in the function to test the song playing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
