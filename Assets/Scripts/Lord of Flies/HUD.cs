using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture2D mSecondaryWeapon;
	public Texture2D mCopperOre;
	public Texture2D mSilverOre;
	public Texture2D mGoldenOre;

	public Texture2D mBuffBoots1;
	public Texture2D mBuffBoots2;
	public Texture2D mBuffWpn1;
	public Texture2D mBuffWpn2;
	public Texture2D mBuffWpn3;
	public Texture2D mBuffWpn4;
	public Texture2D mBuffArmour1;
	public Texture2D mBuffArmour2;
	public Texture2D mBuffArmour3;

	public int mOreSize = 32;

	public bool mIsAlignedRight = false;

	private Rect mPlayerIdRect;
	private Rect mSecondaryWpnRect;
	private Rect mSecondaryWpnAmountRect;
	private Rect mCopperOreRect;
	private Rect mSilverOreRect;
	private Rect mGoldenOreRect;
	private Rect mCopperAmountRect;
	private Rect mSilverAmountRect;
	private Rect mGoldenAmountRect;

	private Rect mFirstBuffRect;
	private Rect mSecondBuffRect;
	private Rect mThirdBuffRect;

	private Texture2D mFirstBuffTexture;
	private Texture2D mSecondBuffTexture;
	private Texture2D mThirdBuffTexture;

	private int mNbBuff = 0;

	private const int mVerticalOffset = 15;
	private const int mHorizontalOffset = 15;

	private string mPlayerNameText = "J1";
	public bool mUpdateGUI = false;

	//TODO private Player mPlayerLink;

	void Start () {
		//TODO init mPlayerLink;

		if(mIsAlignedRight == false){
			mPlayerIdRect = new Rect(mHorizontalOffset, mVerticalOffset, 64, 64);
			mSecondaryWpnRect = new Rect (mHorizontalOffset + 64 * 1 + 10, mVerticalOffset, 64, 64);
			mSecondaryWpnAmountRect = new Rect (mSecondaryWpnRect.x + mSecondaryWpnRect.width, mVerticalOffset + mSecondaryWpnRect.height/2 - 10, 64, 64);

			mCopperOreRect = new Rect (mHorizontalOffset, mVerticalOffset + mSecondaryWeapon.height + 10 * 1 + mOreSize * 0, mOreSize, mOreSize);
			mSilverOreRect = new Rect (mHorizontalOffset, mVerticalOffset + mSecondaryWeapon.height + 10 * 2 + mOreSize * 1, mOreSize, mOreSize);
			mGoldenOreRect = new Rect (mHorizontalOffset, mVerticalOffset + mSecondaryWeapon.height + 10 * 3 + mOreSize * 2, mOreSize, mOreSize);

			mCopperAmountRect = new Rect (mHorizontalOffset + mOreSize + 10, mVerticalOffset + mSecondaryWeapon.height + 10 * 1 + mOreSize * 0 + 5, mOreSize, mOreSize);
			mSilverAmountRect = new Rect (mHorizontalOffset + mOreSize + 10, mVerticalOffset + mSecondaryWeapon.height + 10 * 2 + mOreSize * 1 + 5, mOreSize, mOreSize);
			mGoldenAmountRect = new Rect (mHorizontalOffset + mOreSize + 10, mVerticalOffset + mSecondaryWeapon.height + 10 * 3 + mOreSize * 2 + 5, mOreSize, mOreSize);

			mFirstBuffRect = new Rect( mHorizontalOffset + 32 * 0 + 10 * 0, Screen.height - (mVerticalOffset + 32),32,32);
			mSecondBuffRect = new Rect( mHorizontalOffset + 32 * 1 + 10 * 1, Screen.height - (mVerticalOffset + 32),32,32);
			mThirdBuffRect = new Rect( mHorizontalOffset + 32 * 2 + 10 * 2, Screen.height - (mVerticalOffset + 32),32,32);
		}
		else{
			mPlayerNameText = "J2";

			mPlayerIdRect = new Rect(Screen.width - (mHorizontalOffset + 54), mVerticalOffset, 64, 64);
			mSecondaryWpnRect = new Rect (mPlayerIdRect.x - (64 + 10 + 20 + 10) , mVerticalOffset, 64, 64);
			mSecondaryWpnAmountRect = new Rect (mSecondaryWpnRect.x + mSecondaryWpnRect.width, mVerticalOffset + mSecondaryWpnRect.height/2 - 10, 64, 64);
			
			mCopperOreRect = new Rect (Screen.width - (mHorizontalOffset + mOreSize), mVerticalOffset + mSecondaryWeapon.height + 10 * 1 + mOreSize * 0, mOreSize, mOreSize);
			mSilverOreRect = new Rect (Screen.width - (mHorizontalOffset + mOreSize), mVerticalOffset + mSecondaryWeapon.height + 10 * 2 + mOreSize * 1, mOreSize, mOreSize);
			mGoldenOreRect = new Rect (Screen.width - (mHorizontalOffset + mOreSize), mVerticalOffset + mSecondaryWeapon.height + 10 * 3 + mOreSize * 2, mOreSize, mOreSize);
			
			mCopperAmountRect = new Rect (mCopperOreRect.x - 10 - 23, mVerticalOffset + mSecondaryWeapon.height + 10 * 1 + mOreSize * 0 + 5, mOreSize, mOreSize);
			mSilverAmountRect = new Rect (mSilverOreRect.x - 10 - 23, mVerticalOffset + mSecondaryWeapon.height + 10 * 2 + mOreSize * 1 + 5, mOreSize, mOreSize);
			mGoldenAmountRect = new Rect (mGoldenOreRect.x - 10 - 23, mVerticalOffset + mSecondaryWeapon.height + 10 * 3 + mOreSize * 2 + 5, mOreSize, mOreSize);

			mFirstBuffRect = new Rect( Screen.width - (mHorizontalOffset + 32 * 1 + 10 * 0), Screen.height - (mVerticalOffset + 32),32,32);
			mSecondBuffRect = new Rect( Screen.width - (mHorizontalOffset + 32 * 2 + 10 * 1), Screen.height - (mVerticalOffset + 32),32,32);
			mThirdBuffRect = new Rect( Screen.width - (mHorizontalOffset + 32 * 3 + 10 * 2), Screen.height - (mVerticalOffset + 32),32,32);
		}
		mFirstBuffTexture = mBuffBoots1;
		mSecondBuffTexture = mBuffBoots1;
		mThirdBuffTexture = mBuffBoots1;

		mNbBuff = 3;
	}
	
	// Update is called once per frame
	void Update () {
		updateBuffs ();
		UpdateSecondaryWeaponState ();
		updateRessources ();
	}

	void OnGUI () {
		//GUI.Button (new Rect (10,10,100,20), new GUIContent ("Click me", mSecondaryWeapon, "This is the tooltip"));
		//GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
		if (mUpdateGUI) {
						GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 48;
						GUI.Label (mPlayerIdRect, mPlayerNameText);

						GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 14;
						GUI.Label (mSecondaryWpnRect, mSecondaryWeapon);

						//TODO change tempNb to get desired number

						int tempNb = 2; 
						string tempString = tempNb.ToString ("00");
						GUI.Label (mSecondaryWpnAmountRect, "x " + tempString);

						GUI.Label (mCopperOreRect, mCopperOre);
						tempNb = 12; 
						tempString = tempNb.ToString ("00");
						GUI.Label (mCopperAmountRect, tempString);

						GUI.Label (mSilverOreRect, mSilverOre);
						tempNb = 3; 
						tempString = tempNb.ToString ("00");
						GUI.Label (mSilverAmountRect, tempString);

						GUI.Label (mGoldenOreRect, mGoldenOre);
						tempNb = 2; 
						tempString = tempNb.ToString ("00");
						GUI.Label (mGoldenAmountRect, tempString);

						if (mNbBuff >= 3)
								GUI.Label (mThirdBuffRect, mThirdBuffTexture);
						if (mNbBuff >= 2)
								GUI.Label (mSecondBuffRect, mSecondBuffTexture);
						if (mNbBuff >= 1)
								GUI.Label (mFirstBuffRect, mFirstBuffTexture);
		}
	}

	private void updateRessources(){
		//TODO update amount of ressources? Could be done in OnGUI()
	}

	private void UpdateSecondaryWeaponState(){
		//TODO check player's secondary weapon status

		//TODO check to change imag if needed

		//TODO update amount of munition? Could be done in OnGUI()
	}

	private void updateBuffs()
	{
		//TODO check player's buffs

		//mNbBuff = 0;

		/*if(Player1HUD owns boots 2){
			mFirstBuffTexture = mBuffBoots2;
			mNbBuff++;
		}
		else if(Player1HUD owns boots 2){
			mFirstBuffTexture = mBuffBoots1;
			mNbBuff++;
		}

		if(Player1HUD owns sword 1){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffWpn1;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffWpn1;
			}
		}
		else if(Player1HUD owns sword 2){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffWpn2;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffWpn2;
			}
		}
		else if(Player1HUD owns sword 3){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffWpn3;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffWpn4;
			}
		}
		else if(Player1HUD owns sword 4){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffWpn4;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffWpn4;
			}
		}


		if(Player1HUD owns armour 1){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffArmour1;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffArmour1;
			}
			else if (mNbBuff == 3){
				mSecondBuffTexture = mBuffArmour1;
			}
		}
		else if(Player1HUD owns armour 2){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffArmour2;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffArmour2;
			}
			else if (mNbBuff == 3){
				mSecondBuffTexture = mBuffArmour2;
			}
		}
		else if(Player1HUD owns armour 3){
			mNbBuff++;
			if(mNbBuff == 1){
				mFirstBuffTexture = mBuffArmour3;
			}
			else if (mNbBuff == 2){
				mSecondBuffTexture = mBuffArmour3;
			}
			else if (mNbBuff == 3){
				mSecondBuffTexture = mBuffArmour3;
			}
		}
		*/
	}
}
