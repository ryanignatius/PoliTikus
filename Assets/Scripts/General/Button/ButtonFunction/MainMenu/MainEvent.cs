using UnityEngine;
using System.Collections;

public class MainEvent : ButtonEvent {

	private NetworkClient client;
	private GameObject cam;
	private Loading load;

	// Use this for initialization
	void Start () {
		client = GameObject.Find ("PlayerController").GetComponent<NetworkClient>();
		cam = GameObject.Find("Main Camera");
		load = GameObject.Find("Loading").GetComponent<Loading>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		//client.RefreshHostList();
		client.JoinServer();
		cam.transform.Translate(0,10,0);
		load.StartLoad();
	}
	
	public override void DoEnter(){
		client.RefreshHostList();
		transform.Translate(0f,0f,-5f);
	}
	
	public override void DoExit(){
		transform.Translate(0f,0f,5f);
	}
}
