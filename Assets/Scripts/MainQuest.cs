using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainQuest : MonoBehaviour {
	public static MainQuest instance;

	private PartOfQuest curPart;

	public bool isWin = false;
	public bool isLose = false;

	public GameObject dialogBox;
	public Text textDialog;
	private string [] message = new string[]{
					"Hi, I am very scared. And I really need your help… I was running away from them… But along the way I lost my medallion. It is my last chance to stay alive.. But I sprained my leg… Help me to find my medallion. Please. I was running from that side of the island…",
					"You really think that I will tell you something about it? But I might give you some information, if you bring me food, bottle of rum and gunpowder. And you will shoot from the gun.",
					"Why should I help you? I’m not sure that I want to help you. But you can try. Bring me the core of the First Kraken. And I will think about your situation.",
					"Yeah, I have heard about it. And I will glad to help you. However, can you help me, too? Could you bring me the letter from the Second Man?",
					"You are in a very unpleasant situation, man. If I were you, I would escape from this island as soon as possible! Very strange things are happening here! Leave! Save your life!"
				};

	public GameObject [] parts;

	public int stage = -1;

	public float time = 10.0f;
	private float timer;

	public void ShowMessage(int fromStage) {
		dialogBox.SetActive(true);
		textDialog.text = GetMessage(fromStage);
		timer = time;
	}

	public string GetMessage(int fromStage) {
		if (fromStage == 0) {
			return message[0];
		}
		if (1 <= fromStage && fromStage <= 5) {
			return message[1];
		}
		if (6 <= fromStage && fromStage <= 8) {
			return message[2];
		}
		if (9 <= fromStage && fromStage <= 13) {
			return message[3];
		}
		if (fromStage == 14) {
			return message[4];
		}
		return "";
	}

	//curPart = parts[stage].GetComponent<PartOfQuest>();
	public void NextStage(int fromStage) {
		if (fromStage == 4 || fromStage == 5 || fromStage == 8 || fromStage == 12 || fromStage == 13)
			parts[fromStage].GetComponent<Gun>().Fire();
		if (fromStage == 0 || fromStage == 1 || fromStage == 6 || fromStage == 9 || fromStage == 14)
			ShowMessage(fromStage);

		// Debug.Log("SetActive false to " + fromStage);
		parts[fromStage].SetActive(false);
		stage = fromStage + 1;
		if (fromStage == 14)
			return;
		parts[stage].SetActive(true);
	}

	private void Awake () {
		instance = this;
		for (int i = 1; i < parts.Length; ++i)
			parts[i].SetActive(false);
	}

	private void Update () {
		if (Input.GetButtonDown("Jump"))
			ShowMessage(stage - 1);

		if (timer >= 0.0f) {
			timer -= Time.deltaTime;
		}
		if (timer < 0.0f) {
			dialogBox.SetActive(false);
		}
	}
}
