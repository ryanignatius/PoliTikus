using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	public int level = 0;
	public StarClick[] stars;
	private PlayerController play;
	
	public static int[] ap_req = {
		3,3,4,4
	};
	public static int[,] money_req = {
		{0,10,15,20},
		{0,10,15,20},
		{0,10,15,20},
		{0,10,15,20}
	};
	public static int[,] fame_req = {
		{0,1,2,3},
		{0,1,2,3},
		{0,1,2,3},
		{0,1,2,3}
	};

	// Use this for initialization
	void Start () {
		stars = GetComponentsInChildren<StarClick>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ResetStars(){
		level = 0;
		for (int i=0; i<stars.Length; i++){
			stars[i].ResetStar();
		}
	}
	
	public void DoSkill(int skill_id){
		for (int i=0; i<stars.Length; i++){
			level += stars[i].cur;
		}
		
		if (play == null){
			play = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		if (level > 0){
			if (play.main_player[play.cur_player].ap >= ap_req[skill_id] &&
			    play.main_player[play.cur_player].money >= money_req[skill_id,level] &&
			    play.main_player[play.cur_player].cur_fame >= fame_req[skill_id,level]
			){
				play.action_type = (3*skill_id)+level+9;
				play.skills.SetActive(false);
				play.button_selectchar.SetActive(true);
				play.player_select.gameObject.SetActive(true);
				play.player_select.SetID(0);
			}
		}
	}
}
