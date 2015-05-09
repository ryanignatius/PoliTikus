using UnityEngine;
using System.Collections;

public class ChanceCard : MonoBehaviour {

	public static Card cards;
	
	public static string[] tools_name = {
		"Percobaan Pembunuhan",
		"Transfer Departemen",
		"Pencemaran Nama Baik",
		"Jimat Tolak Bala",
		"Convert Pion?"
	};
	public static int[] tools_number = {
		1,
		1,
		2,
		2,
		1
	};
	public static string[] events_name = {
		// positif
		"Komisi Badan Usaha",
		"Surplus Anggaran Daerah",
		"Promosi Jabatan",
		"Semua Naik?",
		"Semua Tambah Uang?",
		"Pemenangan Tender Proyek",
		"Dukungan Publik",
		"Manuver Politik",
		"Curi Tool?",
		// negatif
		"Hutang Politik",
		"Pajak Pendapatan",
		"Pemeriksaan Keuangan",
		"Random Turun?",
		"Pemeriksaan Badan Antikorupsi",
		"Buang Pion?",
		"Krisis Moneter",
		"Apatisme Masyarakat",
		// netral
		"Perputaran Takdir",
		"Restrukturisasi Departemen",
		"Aksi Paksa?",
		"Keseimbangan?",
		"Drop Effect & Tool?"
	};
	public static int[] events_number = {
		// positif
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		1,
		1,
		// negatif
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		// netral
		2,
		1,
		1,
		2,
		1
	};
	
	public static int total_cards;
	public static int[] card_id;
	public static string[] cards_list;
	public static int[] index;
	
	// Use this for initialization
	void Start () {
		ChanceCard.card_id = new int[50];
		ChanceCard.cards_list = new string[50];
		ChanceCard.index = new int[50];
		int a = 0;
		ChanceCard.total_cards = 0;
		for (int i=0; i<ChanceCard.tools_name.Length; i++){
			for (int j=0; j<ChanceCard.tools_number[i]; j++){
				ChanceCard.card_id[a] = i;
				ChanceCard.cards_list[a] = ChanceCard.tools_name[i];
				ChanceCard.total_cards++;
				a++;
			}
		}
		for (int i=0; i<ChanceCard.events_name.Length; i++){
			for (int j=0; j<ChanceCard.events_number[i]; j++){
				ChanceCard.card_id[a] = i+ChanceCard.tools_name.Length;
				ChanceCard.cards_list[a] = ChanceCard.events_name[i];
				ChanceCard.total_cards++;
				a++;
			}
		}
		bool[] used = new bool[total_cards];
		for (int i=0; i<ChanceCard.total_cards; i++){
			used[i] = false;
		}
		for (int i=0; i<ChanceCard.total_cards; i++){
			do {
				a = Random.Range(0,total_cards);
			} while (used[a]);
			used[a] = true;
			ChanceCard.index[i] = a;
		}
		ChanceCard.cards = new Card();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
