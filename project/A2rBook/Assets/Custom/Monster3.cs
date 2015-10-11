using UnityEngine;
using System.Collections;


public class Monster3 : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	private AudioSource source;

	public float speed = 30.0f;
	public float turnSpeed = 5.0f;
	public float gravity = 20.0f;
	public float cont_h = 1.0f;
	public float cont_v =1.0f;
	public bool isWaiting;
	public int currState;
	public int frame;
	public float secbyframe;
	public Vector3 startPos;
	public Vector3 startRot;
	public AudioClip tauntSound;

	
	public void init(){
		speed = 40.0f;
		turnSpeed = 40.0f;
		gravity = 20.0f;
		cont_h = 10.0f;
		cont_v =1.1f;
		isWaiting = false;
		currState = 0;
		frame = 0;
		secbyframe = 0;
	}
	
	public IEnumerator aspetta(int seconds, int state){
		
		isWaiting = true;
		//Debug.Log ("oooooooooooooooooooooooooo");
		Debug.Log("aspetto");
		yield return new WaitForSeconds (seconds);
		Debug.Log("ho finito d aspettare");
		currState = state;
		//Debug.Log("ASPETTO---->state="+state);
		isWaiting = false;
	}
	
	void Start () {
		init ();
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController> ();
		startPos = transform.position;
		startRot = transform.eulerAngles;
		source = GetComponent<AudioSource>();

	}
	
	void Reset()
	{
		init();
		transform.position = startPos;
		transform.eulerAngles = startRot;
		anim.SetBool("InizioPar", false);
		Debug.Log ("horesettato................");
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (anim.GetBool ("Reset")) {
//			Reset();
//		}
		if (anim.GetBool ("InizioPar")) {
			frame++;
			secbyframe = frame / 30.0f;
			//Debug.Log ("frame="+frame+"   secbyframe=" + secbyframe);

			if(secbyframe>4 && secbyframe<5){
				anim.SetInteger ("AnimPar3", 1); //attack
			}
			if(frame>=150 && frame<160){

				anim.SetInteger ("AnimPar3", 2); //hit
				Debug.Log ("frame="+frame+"   secbyframe=" + secbyframe);
				if(frame==150)source.Play();
			}
			if(frame>=160){
				anim.SetInteger ("AnimPar3", 3); //die
			}

			if (secbyframe >= 10 && secbyframe<11)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("AnimPar3", 4);//iniizio
				Reset();
			} //idle

		}
		
	}
}