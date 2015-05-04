using UnityEngine;
using System.Collections;

public class ChanceCard : MonoBehaviour {

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
	public static string[] cards_list;
	public static int[] index;
	
	// Use this for initialization
	void Start () {
		int a = 0;
		total_cards = 0;
		for (int i=0; i<tools_name.Length; i++){
			cards_list[a] = tools_name[i];
			total_cards += tools_number[i];
			a++;
		}
		for (int i=0; i<events_name.Length; i++){
			cards_list[a] = events_name[i];
			total_cards += events_number[i];
			a++;
		}
		bool[] used = new bool[total_cards];
		for (int i=0; i<total_cards; i++){
			used[i] = false;
		}
		for (int i=0; i<total_cards; i++){
			do {
				a = Random.Range(0,total_cards);
			} while (used[a]);
			used[a] = true;
			index[i] = a;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
