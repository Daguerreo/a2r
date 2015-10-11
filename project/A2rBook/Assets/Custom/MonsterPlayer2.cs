using UnityEngine;
using System.Collections;



public class MonsterPlayer2 : MonoBehaviour {
	
	private Animator anim;
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
		Debug.Log ("oooooooooooooooooooooooooo");
		Debug.Log("aspetto");
		yield return new WaitForSeconds (seconds);
		Debug.Log("ho finito d aspettare");
		currState = state;
		Debug.Log("ASPETTO---->state="+state);
		isWaiting = false;
	}

	void Start () {
		init ();
		anim = gameObject.GetComponentInChildren<Animator>();
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
	}

	// Update is called once per frame
	void Update () {


		if (anim.GetBool ("InizioPar")) {		

			frame++;
			secbyframe = frame / 30.0f;
			Debug.Log ("frame="+frame+"   secbyframe=" + secbyframe);

			if (secbyframe < 3) {

			
			}
			//ho messo il time a 3 cosi taglia il delta in cui non cammina
		
			if (secbyframe >= 3 && secbyframe < 4) {
				anim.SetInteger ("AnimParameter2", 1);//walk
				float translation = cont_h * speed;
				float rotation = cont_v * turnSpeed;
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				transform.Translate (0, 0, translation / 2);
				transform.Rotate (0, 0, 0);
				if(frame%30==0)source.Play();
			}
			//else {anim.SetInteger ("AnimParameter", 1);}//idle

			if (secbyframe >= 4 && secbyframe < 5) { //walk			
				float translation = cont_h * speed;
				float rotation = -cont_v * turnSpeed;
				anim.SetInteger ("AnimParameter2", 1);
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				transform.Translate (-translation / 2, 0, translation / 2);
				transform.Rotate (0, rotation/1.5f , 0);
				//if(frame%25==0)source.Play();
			}
			if (secbyframe >= 5 && secbyframe < 7.4) {
				float translation = cont_h * speed;
				float rotation = -cont_v * turnSpeed;
				anim.SetInteger ("AnimParameter2", 1);
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				transform.Translate (-translation / 5, 0, translation / 2.1f);
				transform.Rotate (0, 0, 0);
		
				if (secbyframe >= 6 && secbyframe < 7) {
					transform.Rotate (0, -1.2f * rotation, 0);
				}
			
			}  //walk

			if (secbyframe > 7.5 && secbyframe <= 12.8) {	
				anim.SetInteger ("AnimParameter2", 2);
				transform.Translate (0, 0, 0);

				if (secbyframe > 11.8 && secbyframe < 12.8)
					{anim.SetInteger ("AnimParameter2", 3);} //taunt{
							
			}
			if (secbyframe > 12.8 && secbyframe<14) 
		{	
			transform.Translate(0, 0, 0);
			anim.SetInteger ("AnimParameter2", 4);}

			if (secbyframe >= 14 && secbyframe<18)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("AnimParameter2", 5);//iniizio
				if (secbyframe >= 17 && secbyframe<18){Reset();}
			} //idle
//			if (secbyframe >= 17 && secbyframe<18)
//			{
//				transform.Translate(0,0,0);
//				anim.SetInteger ("AnimParameter2", 6);//iniizio
//				Reset();
//			} //idle

		}
		
	}
}