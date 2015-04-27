using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	private float move_time = 1f;
	
	public int player_id;
	
	public int player_tower;
	public int player_post;
	
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(Tower.GetPostX(player_tower,player_post),
		                                      Tower.GetPostY(player_tower,player_post),
		                                      0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Move(int tow, int post){
		int cur = Tower.GetMovePost(player_tower, player_post, tow, post);
		int dif = cur-player_post;
		
		Debug.Log (cur+" "+ dif);
		//player_tower = tow;
		//player_post = post;
		for (int i=0; i<dif; i++){
			Invoke("MoveAnim",(i*move_time));
		}
	}
	
	public void MoveAnim(){
		float dir = Tower.GetDir(player_tower,player_post);
		float dx = Tower.GetDistX(player_tower,player_post);
		float dy = Tower.GetDistY(player_tower,player_post);
		dx *= dir;
		Vector3 vec = new Vector3(
			this.transform.position.x + dx,
			this.transform.position.y + dy,
			this.transform.position.z
		);
		StartCoroutine(WaitAndMove(vec));
		player_post++;
	}
	
	IEnumerator WaitAndMove(Vector3 dest){
		//yield return new WaitForSeconds(delayTime); // start at time X
		float startTime=Time.time; // Time.time contains current frame time, so remember starting point
		while(Time.time-startTime<=move_time){ // until one second passed
			transform.position=Vector3.Lerp(transform.position,dest,Time.time-startTime); // lerp from A to B in one second
			yield return 1; // wait for next frame
		}
	}
}
