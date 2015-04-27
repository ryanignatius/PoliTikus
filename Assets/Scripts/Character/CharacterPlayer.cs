using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovePlayer))]
public class CharacterPlayer : MonoBehaviour {
	
	public MainPlayer main_player;
	
	public bool is_active;
	
	public MovePlayer mv;
	
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
		mv.Move(mv.player_tower,mv.player_post+speed);
		/*
		if (mv.player_tower == 2){
			
		}
		*/
	}
	
}
