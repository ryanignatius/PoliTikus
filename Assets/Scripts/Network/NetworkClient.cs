using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]

public class NetworkClient : MonoBehaviour {
	
	public bool isProxy = false;
	public bool isLocalhost = false;
	
	private const string typeName = "TestNetwork";
	private const string gameName = "TestRoom";
	
	private HostData[] hostList;
	
	private PlayerController player;
	private NetworkView networkView;
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
		networkView = GetComponent<NetworkView>();
		networkView.group = 1;
		//Application.LoadLevel(disconnectedLevel);
	}
	
	// Use this for initialization
	void Start () {
		if (isLocalhost){
			MasterServer.ipAddress = "127.0.0.1";
		}
		player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void JoinServer(HostData hostData)
	{
		//if (isProxy) Network.useProxy = true;
		Network.Connect(hostData);
	}
	
	void OnGUI(){
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
	
	void OnConnectedToServer() {
		Debug.Log("Connected to server");
	}
	
	void OnDisconnectedFromServer ()
	{
		player.AbortGame();
	}
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
}
