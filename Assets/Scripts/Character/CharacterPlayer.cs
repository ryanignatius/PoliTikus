using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovePlayer))]
public class CharacterPlayer : MonoBehaviour {
	
	public bool is_active;
	public bool is_move;
	
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
		is_move = true;
		mv.Move(mv.player_tower,mv.player_post+speed);
	}
	
}
