using UnityEngine;
using System.Collections;

public class PlayingTimeCaller : MonoBehaviour {
    public PlayingTimeTextScript pTime;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        pTime.TextUpdate();

    }
}
