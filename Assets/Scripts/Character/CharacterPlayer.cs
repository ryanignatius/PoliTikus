using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovePlayer))]
public class CharacterPlayer : MonoBehaviour {
	
	public bool is_active;
	public bool is_move;
	
	public MovePlayer mv;
	public PlayerController player;
	
	private int speed;
	
	// Use this for initialization
	void Start () {
		mv = GetComponent<MovePlayer>();
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Move(){
		is_move = true;
		mv.Move(mv.player_tower,mv.player_post+speed);
	}
	
	public void Kampanye(int level){
		mv.Move(mv.player_tower,mv.player_post+level*3);
	}
	public void Sabotase(int level){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		player.main_player[(mv.player_id-1)/7].ap_gain -= level*2;
	}
	public void Gosip(int level){
		mv.Move2(mv.player_tower,mv.player_post-level*3);
	}
	public void Peras(int level){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		player.main_player[(mv.player_id-1)/7].money -= level*5;
		player.main_player[player.cur_player].money += level*5;
	}
}
