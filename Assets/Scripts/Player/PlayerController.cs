using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class PlayerController : MonoBehaviour
{
	public int move_ap = 2;
	public int hire_ap = 2;
	public int hire_money = 10;
	
	public int id = 0;
	public bool isAct;
	
	public int cur_player;
	private int max_player;
	
	private NetworkView netView;
	
	public MainPlayer[] main_player;
	public CharacterPlayer[] chars;
	public GameObject spinner;
	public GameObject button;
	public GameObject button_selectchar;
	public GameObject[] button_chars;
	public GameObject button_selecttower;
	public GameObject player_select;
	public GameObject skills;
	public int action_type;
	
	private bool levelWasLoaded = false;
	private void OnLevelWasLoaded(int iLevel)
	{
		levelWasLoaded = true;
	}
	
	void Start(){
		isAct = false;
		netView = GetComponent<NetworkView>();
	}
	
	void Update()
	{
		/*
		if (netView.isMine){
			// do something
		}
		*/
	}
	
	void OnGUI(){
		/*
		if (isAct)
		{
			if (GUI.Button(new Rect(50, 100, 250, 100), "Move Satu"))
				MoveCharacter((id-1)*7+0);
			if (GUI.Button(new Rect(50, 250, 250, 100), "Move Dua"))
				MoveCharacter((id-1)*7+1);
			if (GUI.Button(new Rect(400, 100, 250, 100), "Move Tiga"))
				MoveCharacter((id-1)*7+2);
			if (GUI.Button(new Rect(400, 250, 250, 100), "End Turn"))
				EndTurn();
		}
		*/
	}
	
	// called by server
	public void StartGame(int num_player){
		netView.RPC("StartGame2", RPCMode.All, num_player);
		//max_player = num_player;
		//cur_player = 0;
		//StartTurn(cur_player+1);
	}
	
	[RPC]
	public IEnumerator StartGame2(int num_player){
		max_player = num_player;
		cur_player = 0;
		Debug.Log ("load level");
		Application.LoadLevel("InGame");
		while (!levelWasLoaded)
			yield return 1;
		levelWasLoaded = false;
		chars = new CharacterPlayer[30];
		main_player = new MainPlayer[5];
		Debug.Log ("after init");
		for (int i=1; i<=4; i++){
			main_player[i-1] = GameObject.Find("Character "+i).GetComponent<MainPlayer>();
			main_player[i-1].player_status = GameObject.Find ("Player "+i).GetComponent<TextMesh>();
			main_player[i-1].id = i;
			if (i > max_player){
				main_player[i-1].gameObject.SetActive(false);
			}
		}
		for (int i=1; i<=7*max_player; i++){
			chars[i-1] = GameObject.Find("penguin "+i).GetComponent<CharacterPlayer>();
			if ((i-1)%7 >= 3){
				chars[i-1].is_active = false;
				chars[i-1].gameObject.SetActive(false);
			} else chars[i-1].is_active = true;
		}
		button_chars = new GameObject[8];
		for (int i=1; i<=7; i++){
			button_chars[i-1] = GameObject.Find ("Char "+i);
		}
		button = GameObject.Find("Button");
		if (!isAct) button.SetActive(false);
		spinner = GameObject.Find("Spinner");
		//spinner.SetActive(false);
		skills = GameObject.Find("Skills");
		skills.SetActive(false);
		button_selectchar = GameObject.Find("Button Select Char");
		button_selectchar.SetActive(false);
		button_selecttower = GameObject.Find("Button Select Tower");
		button_selecttower.SetActive(false);
		player_select = GameObject.Find("Player Select");
		player_select.SetActive(false);
		StartTurn(cur_player+1);
	}
	
	public void SetPlayerID(int new_id, NetworkPlayer np){
		netView.RPC("SetPlayerID2",np,new_id);
	}
	
	public void RenderText(){
		netView.RPC("RenderText2", RPCMode.All);
	}
	
	[RPC]
	public void RenderText2(){
		for (int i=0; i<max_player; i++){
			main_player[i].RenderText();
		}
	}
	
	[RPC]
	public void SetPlayerID2(int new_id){
		id = new_id;
	}
	
	// first called by server
	[RPC]
	public void StartTurn(int player_id){
		
		if (id == 0){
			for (int i=0; i<max_player; i++){
				netView.RPC("StartTurn", RPCMode.Others, player_id);
			}
		}
		main_player[player_id-1].ap = 10;
		for (int i=0; i<7; i++){
			chars[cur_player*7+i].is_move = false;
		}
		RenderText();
		Debug.Log("player id : "+player_id);
		if (id == player_id){
			isAct = true;
			button.SetActive(true);
		} else {
			button.SetActive(false);
		}
	}
	
	// first called by client
	[RPC]
	public void EndTurn(){
		if (id > 0){
			// this client
			netView.RPC("EndTurn2", RPCMode.All);
			isAct = false;
		}
		/* else {
			// server
			cur_player++;
			cur_player %= max_player;
			StartTurn(cur_player+1);
		}
		*/
	}
	
	[RPC]
	public void EndTurn2(){
		main_player[cur_player].money_income = 0;
		main_player[cur_player].max_fame = 1;
		bool is_chance = false;
		for (int i=0; i<7; i++){
			if (chars[cur_player*7+i].is_active){
				if (chars[cur_player*7+i].mv.player_tower == 0){
					main_player[cur_player].max_fame += Tower.GetFame(chars[cur_player*7+i].mv.player_post);
				}
				if (chars[cur_player*7+i].mv.player_tower == 1){
					is_chance = is_chance || Tower.GetChanceCard(chars[cur_player*7+i].mv.player_post);
				}
				if (chars[cur_player*7+i].mv.player_tower == 2){
					main_player[cur_player].money_income += Tower.GetMoneyIncome(chars[cur_player*7+i].mv.player_post);
				}
			}
		}
		if (is_chance){
			// todo chance card effect
		}
		main_player[cur_player].ap = 0;
		main_player[cur_player].money += main_player[cur_player].money_income;
		main_player[cur_player].cur_fame = main_player[cur_player].max_fame;
		cur_player++;
		cur_player %= max_player;
		if (id == 0){
			// server
			StartTurn(cur_player+1);
		}
	}
	
	public void AbortGame(){
		netView.RPC("AbortGame2", RPCMode.All);
	}
	
	[RPC]
	public void AbortGame2(){
		Application.LoadLevel("MainMenu");
	}
	
	public void MoveCharacter(int id){
		netView.RPC("InitMoveCharacter",RPCMode.All,id);
	}
	
	[RPC]
	public void InitMoveCharacter(int id){
		main_player[id/7].ap -= move_ap;
		chars[id].Move ();
	}
	
	public void HireCharacter(int tow){
		netView.RPC("InitHireCharacter",RPCMode.All,tow);
	}
	
	[RPC]
	public void InitHireCharacter(int tow){
	Debug.Log ("hire new at tower : "+tow);
		main_player[cur_player].num_char++;
		main_player[cur_player].ap -= hire_ap;
		main_player[cur_player].money -= hire_money;
		if (tow == 3) main_player[cur_player].money_income += 2;
		for (int i=1; i<=7; i++){
			if (!chars[(cur_player)*7+i].is_active){
				chars[(cur_player)*7+i].is_active = true;
				chars[(cur_player)*7+i].gameObject.SetActive(true);
				chars[(cur_player)*7+i].mv.player_tower = tow-1;
				chars[(cur_player)*7+i].transform.position = 
					new Vector3(
						Tower.GetPostX(chars[(cur_player)*7+i].mv.player_tower,chars[(cur_player)*7+i].mv.player_post),
						Tower.GetPostY(chars[(cur_player)*7+i].mv.player_tower,chars[(cur_player)*7+i].mv.player_post),
				        0);
				break;
			}
		}
	}
}
