using UnityEngine;
using System.Collections;

public class OverGUI : MonoBehaviour {

	public Texture mLifeBox;
	public Texture mLvlBox;
	public Texture mGreenBar;
	public Texture mRedBar;

	private Rect mLifeBoxRect;
	private Rect mLvlBoxRect;
	private Rect mGreenBarRect;
	private Rect mRedBarRect;
	private Rect mLvlRect;

	private Character mCharacterRef;
	private GameObject mObjectRef;
	public bool mIsPlayerOne = true;
	private bool mEnabled = false;
	
	// Use this for initialization
	void Start () {

		if(mIsPlayerOne){
			mCharacterRef = GameObject.Find("Character1").GetComponent<Character>();

		}else{
			mCharacterRef = GameObject.Find("Character2").GetComponent<Character>();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (mEnabled) {

				Camera c = GameObject.Find("Main Camera").gameObject.camera;
				Transform target = mObjectRef.transform;
				Vector2 viewPos = c.WorldToScreenPoint(target.position);
				
				//Debug.Log ("x:" + viewPos.x + "   y:" + viewPos.y);
				float tempHealthLenght = 80 * mCharacterRef.getHealthPercent();
				Debug.Log (tempHealthLenght);
				if (tempHealthLenght <0)
					tempHealthLenght = 0;
				//mLifeBoxRect = 	new Rect (viewPos.x - 35, (Screen.height - viewPos.y) - 32, 70, 16);
				mLvlBoxRect = 	new Rect (viewPos.x - 35, (Screen.height - viewPos.y) + 32, 90, 40);
				mGreenBarRect = new Rect (viewPos.x - 30, (Screen.height - viewPos.y) + 37, tempHealthLenght, 10);
				mRedBarRect = 	new Rect (viewPos.x - 30, (Screen.height - viewPos.y) + 37, 80, 10);
				mLvlRect = 		new Rect (viewPos.x - 30, (Screen.height - viewPos.y) + 50, 80, 20);
		}
	}

	void OnGUI(){
		if (mEnabled) {
			int TempLvl = mCharacterRef.getPlayerLvl();

			//GUI.DrawTexture(mLifeBoxRect, mLifeBox, ScaleMode.StretchToFill);
			GUI.DrawTexture(mLvlBoxRect, mLvlBox, ScaleMode.StretchToFill);
			GUI.DrawTexture(mRedBarRect, mRedBar, ScaleMode.StretchToFill);
			GUI.DrawTexture(mGreenBarRect, mGreenBar, ScaleMode.StretchToFill);
			GUI.Label (mLvlRect,"Level " + TempLvl.ToString("00"));
		}
	}

	public void setCharacter(GameObject _object){
		mObjectRef = _object;
		mEnabled = true;
	} 

}
