using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {


    public static AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void removeSound()
    {
        source.Play();
    }
}
