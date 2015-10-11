using UnityEngine;
using System.Collections;



public class playerMonster1 : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	public float speed;
	public float turnSpeed;
	private Vector3 moveDirection;
	public float gravity;
	public float cont_h;
	public float cont_v;
    public bool isWaiting;
    public int currState;
	public int frame=0;
	public int step=10;

	public void init(){
		speed = 100.0f;
		turnSpeed = 5.0f;
		moveDirection = Vector3.zero;
		gravity = 20.0f;
		cont_h = 100.0f;
		cont_v =1.0f;
        isWaiting = false;
        currState = 0;

	}

	//public bool isPlaying = false;
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


	// Use this for initialization
	void Start () {
		init ();
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController> ();

	}

    void Reset()
    {
        init();
        anim.SetBool("Reset", false);
   }

	// Update is called once per frame
	void Update () {

		if (anim.GetBool ("Reset")) {
            Reset();
		}
        if (anim.GetBool("InizioPar"))
        {
            switch (anim.GetInteger("AnimParameter"))
            {
                case 0: //to idle
					if(frame>30 && frame<210){
						Debug.Log("walk");
						Debug.Log("CASE:0<---->Parametro="+anim.GetInteger("AnimParameter"));
						float translation = cont_h*speed;
						float rotation = cont_v*turnSpeed;
						//translation *= frame/30;
						//rotation *= Time.deltaTime;
						
						transform.Translate(0, 0, 100);
						transform.Rotate(0, 0, 0);
						Debug.Log("CASE:0<---->Parametro="+anim.GetInteger("AnimParameter"));
					}
				else
				{
					anim.SetInteger("AnimParameter", 1);//walk

				}
					//aspetta(2,1);
                    break;
                case 1:
					if(frame>210){
					Debug.Log("CASE:1<---->Parametro="+anim.GetInteger("AnimParameter"));
					anim.SetInteger("AnimParameter", 2); //taunt
					Debug.Log("CASE:1<---->Parametro="+anim.GetInteger("AnimParameter"));
//					Debug.Log("taunt");
//					aspetta (2,2);
//					Debug.Log("taunt_currState="+currState);
//					float translation = cont_h*speed;
//					float rotation = cont_v*turnSpeed;
//					translation *= Time.deltaTime;
//					rotation *= Time.deltaTime;
//					transform.Translate(0, 0, translation+frame);
//					transform.Rotate(0, 0, 0);
				}
                    break;
				case 2:
				if(frame>400){
					Debug.Log("CASE:2<---->Parametro="+anim.GetInteger("AnimParameter"));
					anim.SetInteger("AnimParameter", 3);//scratch
					transform.Translate(0, 0, 0);
					transform.Rotate(0, 0, 0);
					Debug.Log("CASE:2<---->Parametro="+anim.GetInteger("AnimParameter"));
				}
					break;
				case 3:
				if(frame>600){
					Debug.Log("CASE:3<---->Parametro="+anim.GetInteger("AnimParameter"));
					anim.SetInteger("AnimParameter", 4);//walk
					transform.Translate(0, 0, 0);
					transform.Rotate(0, 0, 0);
					Debug.Log("CASE:3<---->Parametro="+anim.GetInteger("AnimParameter"));
				}
					break;
			case 4:
				if(frame>800){
					Debug.Log("CASE:4<---->Parametro="+anim.GetInteger("AnimParameter"));
					anim.SetInteger("AnimParameter", 5);//idle
					transform.Translate(0, 0, 0);
					transform.Rotate(0, 0, 0);
					Debug.Log("CASE:4<---->Parametro="+anim.GetInteger("AnimParameter"));
				}	
			break;
			default:
                Reset();
                break;
            
			}
			step+=5;
			frame++;
        }

/*
        
		if (anim.GetBool("InizioPar")) {

			//while(!anim.GetBool("AnimPause")){
			StartCoroutine (aspetta (3));
			anim.SetInteger ("AnimParameter", -1);//idle
			StartCoroutine (aspetta (4));
			anim.SetInteger ("AnimParameter", 1);//walk
			float translation = 10*cont_h*speed;
			float rotation = cont_v*turnSpeed;
			}
    */

			

		}
//
//		if (Time.time < 3) {
//			anim.SetInteger ("AnimParameter", -1);
//
//		}
//		//ho messo il time a 3 cosi taglia il delta in cui non cammina
//
//		if (Time.time >= 3 && Time.time < 7) {
//			anim.SetInteger ("AnimParameter", 1);//walk
//			float translation = cont_h*speed;
//			float rotation = cont_v*turnSpeed;
//			translation *= Time.deltaTime;
//			rotation *= Time.deltaTime;
//			transform.Translate(0, 0, translation/2);
//			transform.Rotate(0, 0, 0);
//		}
//		//else {anim.SetInteger ("AnimParameter", 1);}//idle
//
//		if (Time.time > 7 && Time.time < 9) 
//		{	
//			transform.Translate(0, 0, 0);
//			anim.SetInteger ("AnimParameter", 2);} //taunt
//		if (Time.time >= 9 && Time.time < 10.5) 
//		{anim.SetInteger ("AnimParameter", 3);} //scratch
//
//		if (Time.time >= 10.5 && Time.time < 12) //walk
//		{			
//			float translation = cont_h*speed;
//			float rotation = -cont_v*turnSpeed;
//			anim.SetInteger ("AnimParameter", 4);
//			translation *= Time.deltaTime;
//			rotation *= Time.deltaTime;
//			transform.Translate(-translation/2,0,translation/2);
//			if(Time.time<=11){transform.Rotate(0,rotation/8,0);}
//		} //walk
//
//		if (Time.time >= 12 && Time.time < 20) 
//		{anim.SetInteger ("AnimParameter", 5);
//		//	transform.localScale-=(scaling);
//		} //idle



	}

