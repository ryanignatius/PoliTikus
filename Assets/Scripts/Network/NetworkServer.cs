using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkView))]
public class NetworkServer : MonoBehaviour {
	
	Dictionary<string, int> player_id = new Dictionary<string, int>();
	
	public bool isProxy = false;
	public bool isLocalhost = false;
	
	private int playerCount = 0;
	private const string typeName = "TestNetwork";
	private const string gameName = "TestRoom";
	
	private PlayerController game_master;
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		if (isLocalhost){
			MasterServer.ipAddress = "127.0.0.1";
		}
		game_master = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void StartServer()
	{
		if (isProxy){
			Network.natFacilitatorIP = "cache.itb.ac.id";
			Network.natFacilitatorPort = 8080;
		}
		//if (isProxy) Network.useProxy = true;
		Network.InitializeServer(4, 25000,false);//!Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
		Debug.Log("Init Success");
	}
	
	private void StartGame(){
		game_master.StartGame(playerCount);
	}
	
	void OnGUI(){
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
		}
		if (Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Game"))
				StartGame();
		}
	}
	
	void OnServerInitialized() {
		//SpawnPlayer();
		Debug.Log("Server initialized and ready");
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Player " + (playerCount++) + " connected from " + player.ipAddress + ":" + player.port);
		player_id[player.guid] = playerCount;
		SetPlayerID(playerCount,player);
	}
	void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Player " + (playerCount++) + " disconnected from " + player.ipAddress + ":" + player.port);
		game_master.AbortGame();
	}
	
	public void SetPlayerID(int new_id, NetworkPlayer np){
		game_master.SetPlayerID(new_id,np);
	}
}
