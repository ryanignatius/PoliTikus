using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {

	public int id;
	public int ap;
	public int ap_gain;
	public int money;
	public int money_income;
	public int cur_fame;
	public int max_fame;
	public int num_tools;
	public int[] tools;
	
	public int num_char;
	
	public TextMesh player_status;

	// Use this for initialization
	void Start () {
		// initial status
		ap = 0;
		ap_gain = 10;
		money = 20;
		money_income = 2;
		cur_fame = 1;
		max_fame = 1;
		num_char = 3;
		num_tools = 0;
		tools = new int[2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RenderText(){
		player_status.text = "Player "+id+"\n"+"AP : "+ap+"\n"+"Money : "+money+"\n"+"Fame : "+cur_fame+" / "+max_fame+"\n";
	}
}
