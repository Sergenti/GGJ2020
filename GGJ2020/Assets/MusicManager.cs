using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        // prevent gameobject from duplicating because of the DontDestroyOnLoad
		if (FindObjectsOfType<MusicManager>().Length > 1)
		{
			Destroy(this.gameObject);
		}
		// if more then one music player is in the scene
		// destroy ourselves
		else
		{
			DontDestroyOnLoad(gameObject);
		}
    }
}
