using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUI : MonoBehaviour
{
    public Sprite playMusic;
    public Sprite stopMusic;
    private AudioSource audioSource;
    private bool isPlayingMusic = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Music()
    {
	if (isPlayingMusic)
        {
	        
		Debug.Log("button Click1");
                audioSource.Pause();
                isPlayingMusic = false;
 		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = stopMusic;
        }
        else
        {
		Debug.Log("button Click2");
                audioSource.Play();
                isPlayingMusic = true;
     		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = playMusic;
        }
    }
}
