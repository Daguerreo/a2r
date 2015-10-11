using UnityEngine;
using System.Collections;



public class player : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	private AudioSource source;

	public float speed;
	public float turnSpeed;
	//private Vector3 moveDirection;
	//public float Vector3 inizio;
	public float gravity;
	public float cont_h;
	public float cont_v;
	public bool isWaiting;
	public int currState;
	public int frame;
	public float secbyframe;
	//public	Vector3 reset = new Vector3 (0,0,0);//(-0.34f,0.01f,0.16f);
	public Vector3 startPos;
	public Vector3 startRot;
	public AudioClip tauntSound;

	public void init(){
		speed = 40.0f;
		turnSpeed = 40.0f;
		//moveDirection = Vector3.zero;
		gravity = 20.0f;
		cont_h = 10.0f;
		cont_v =1.1f;
		isWaiting = false;
		currState = 0;
		frame = 0;
		secbyframe = 0;
	}

	//public bool isPlaying = false;
	public IEnumerator aspetta(int seconds, int state){
		
		isWaiting = true;
		//Debug.Log ("oooooooooooooooooooooooooo");
		//Debug.Log("aspetto");
		yield return new WaitForSeconds (seconds);
		//Debug.Log("ho finito d aspettare");
		currState = state;
		//Debug.Log("ASPETTO---->state="+state);
		isWaiting = false;
	}

	//public vec3 scaling = (10.0f, 10.0f, 10.0f );
	// Use this for initialization
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
		if (anim.GetBool("InizioPar"))
		{
			frame++;
			secbyframe = frame / 30.0f;
			//Debug.Log ("frame="+frame+"   secbyframe=" + secbyframe);
				if (secbyframe < 3) {
				//Debug.Log ("frame"+ frame);
				}
		
				if (secbyframe >= 3 && secbyframe < 4.5) {
					anim.SetInteger ("AnimParameter", 1);//walk
					float translation = cont_h*speed;
					float rotation = cont_v*turnSpeed;
					translation *= Time.deltaTime;
					rotation *= Time.deltaTime;
					transform.Translate(0, 0, translation/2);
					transform.Rotate(0, 0, 0);
					//if(frame%12==0)source.Play();
				}
		
			if (secbyframe >= 4.5 && secbyframe < 8) 
				{	
				transform.Translate(0, 0, 0);
				anim.SetInteger ("AnimParameter", 2);//taunt
				if(frame%25==0)source.Play();
			} 

			if (secbyframe >= 8 && secbyframe < 10) 
				{anim.SetInteger ("AnimParameter", 3);} //scratch
		
			if (secbyframe >= 10 && secbyframe < 14) //walk
				{			
					float translation = cont_h*speed;
					float rotation = cont_v*turnSpeed;
					anim.SetInteger ("AnimParameter", 4);
					translation *= Time.deltaTime;
					rotation *= Time.deltaTime;
					if(secbyframe>10.3 && secbyframe<14){
					transform.Translate(-translation/3,0,translation/3);
					//if(frame%12==0)source.Play();
				}
					if(secbyframe<=10.3){
						transform.Rotate(0,-1.5f*rotation,0);
						transform.Translate(-translation/3,0,translation/3);
					//if(frame%12==0)source.Play();
					//if(secbyframe>=11.8){transform.Translate(-translation/3,0,translation/3);}
					}
				}
		
 			if (secbyframe >= 14 && secbyframe<15)
				{
				transform.Translate(0,0,0);
				anim.SetInteger ("AnimParameter", 5);
			}
			if (secbyframe >= 15 && secbyframe<16)
				{
				transform.Translate(0,0,0);
				anim.SetInteger ("AnimParameter", 6);//iniizio
				Reset();
				} //idle


	}

	}
}