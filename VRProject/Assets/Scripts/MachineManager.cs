using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MachineManager : MonoBehaviour {

    private GameObject screen;
    private VideoPlayer screenPlayer;
    
    public VideoClip tempClip;
    public VideoClip snowscreen;
    private VideoClip currentMeme;

    void Start () {
        screen = this.gameObject.transform.GetChild(1).gameObject;
        screenPlayer = screen.GetComponent<VideoPlayer>();

        //Temp
        currentMeme = tempClip;
        StartCoroutine(Delay());
    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        //currentMeme = other.GetComponent<Item>().clip;
        //var item = other.gameObject;
        Destroy(other);
    }

    public void ButtonPressed()
    {
        Delay();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        StartMeme();
    }

    void StartMeme()
    {
        screenPlayer.clip = snowscreen;
        screenPlayer.Play();
        screenPlayer.loopPointReached += PlayMeme;
    }

    void PlayMeme(UnityEngine.Video.VideoPlayer vp)
    {
        vp.clip = currentMeme;
        screenPlayer.Play();
    }

    
}
