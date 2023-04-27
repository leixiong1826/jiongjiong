using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	public Texture2D[] textArray;
	public AudioClip clip;
	public AudioClip hitAnimalClip;

	public GameObject knife;

	private GameObject currentKnife;

	private bool mouseDown = false;

	private int cout = 0;
	private int One;
	private int ten;
	private int hundred;
	private int shound;

	int scoreImageX = 25;
	int scoreImageY = 10;
	int coreImageWidth = 15;
	int coreImageHeight = 20;
	int scoreImageSpace = 5;
	//有10点血量
	int blood = 9;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!mouseDown) {
			if (Input.GetMouseButtonDown (0)) {
				mouseDown = true;
				currentKnife = Instantiate (knife);
			}
		} else {
			if (Input.GetMouseButtonUp (0)) {
				mouseDown = false;
				Destroy (currentKnife);
				return;
			}
		}
	
	}
	public void countFall()
	{
		blood--;
		if (blood == 0) {
			Application.LoadLevel (0);
		}
	}
	void gameOver()
	{
		
	}
	public void hitAnimals()
	{
		Debug.Log ("write line");
		GameObject gameObject = new GameObject ();
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = hitAnimalClip;
		source.playOnAwake = false;
		source.loop = false;
		source.Play ();
		Destroy (gameObject, 2);

		Application.LoadLevel (0);

	}
	public void countScore(int score){
		cout += score;
		GameObject gameObject = new GameObject ();
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clip;
		source.playOnAwake = false;
		source.loop = false;
		source.Play ();
		Destroy (gameObject, 2);

		shound = cout / 1000;
		hundred = (cout % 1000) / 100;
		ten = (cout % 100) / 10;
		One = cout % 10;
		Debug.Log ("cout =" + cout);
	}
	void OnGUI(){
		this.paintBlood ();
		if (shound != 0) {
			this.paintThousand ();
		} else if (hundred != 0) {
			this.paintHundred ();
		} else if (ten != 0) {
			this.paintTen ();
		} else {
			this.paintOne ();
		}
		

		
	}
	void paintBlood()
	{
		GUI.DrawTexture (new Rect(50,scoreImageY,coreImageWidth,coreImageHeight),(Texture2D)textArray[blood]);
	}
	void paintOne()
	{
		GUI.DrawTexture (new Rect(Screen.width-scoreImageX-coreImageWidth,scoreImageY,coreImageWidth,coreImageHeight),(Texture2D)textArray[One]);
	}
	void paintTen()
	{
		GUI.DrawTexture (new Rect(Screen.width-scoreImageX-(coreImageWidth*2+scoreImageSpace),scoreImageY,coreImageWidth,coreImageHeight),(Texture2D)textArray[ten]);
		paintOne ();
	}
	void paintHundred()
	{
		GUI.DrawTexture (new Rect(Screen.width-scoreImageX-(coreImageWidth*3+scoreImageSpace*2),scoreImageY,coreImageWidth,coreImageHeight),(Texture2D)textArray[hundred]);
		paintTen ();
	}
	void paintThousand()
	{
		GUI.DrawTexture (new Rect(Screen.width-scoreImageX-(coreImageWidth*4+scoreImageSpace*3),scoreImageY,coreImageWidth,coreImageHeight),(Texture2D)textArray[shound]);
		paintHundred ();
	}

}
