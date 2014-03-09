using UnityEngine;
using System.Collections;

public class Character:MonoBehaviour
{

		private const int BASE_DMG = 5;
		private const int BASE_HEALTH = 15;
		public int mStartingCopper = 0;
		public int mStartingSilver = 0;
		public int mStartingGold = 0;
		private int mMaxHealthPoints = BASE_HEALTH;
		private int mCurrentHealthPoints;
		private int mDamage = BASE_DMG;
		private int mLvl = 1;
		private int mJumpLvl = 1;
		private bool mIsAlive = true;
		private int mSwordEquipped = 0;
		private int mBootsEquipped = 0;
		private int mArmourEquipped = 0;
		private int mSecWpnEquipped = 0;
		private int mSecWpnAmunitions = 0;
		private int mCopperPiecesOwned = 0;
		private int mSilverPiecesOwned = 0;
		private int mGoldenPiecesOwned = 0;
		public int mPlayerNb = 1;
		private CraftManager crafterRef;

		void Start ()
		{
				mCurrentHealthPoints = mMaxHealthPoints;
				mCopperPiecesOwned = mStartingCopper;
				mSilverPiecesOwned = mStartingSilver;
				mGoldenPiecesOwned = mStartingGold;

				crafterRef = GameObject.Find ("CraftyObject").GetComponent<CraftManager> ();
				crafterRef.setCharacter (this);
		}

		void Update ()
		{

		}

		public PlayerControl GetCorrespondingGameObject ()
		{
				PlayerControl[] pcs = FindObjectsOfType<PlayerControl> ();
				foreach (PlayerControl pc in pcs) {
						if (pc.PlayerNumber == mPlayerNb)
								return pc;
				}
				return null;
		}

		public int getTotalValue ()
		{
				return (mCopperPiecesOwned * 1) + (mSilverPiecesOwned * 2) + (mGoldenPiecesOwned * 5);
		}

		public void respawn ()
		{
				LevelController lc = FindObjectOfType<LevelController> ();
				lc.currentMap.respawn (mPlayerNb);
		}

		public void LevelUpAndRevive ()
		{
				mLvl ++;
				mMaxHealthPoints = mMaxHealthPoints + 10;
				mCurrentHealthPoints = mMaxHealthPoints;
				mDamage = mDamage + 5;
				mIsAlive = true;
				GetCorrespondingGameObject ().gameObject.GetComponentInChildren<GrowingHatCommands> ().grow ();
				respawn ();
		}

		public void drinkGentleDrunkPotion ()
		{
				mDamage = mDamage + 5;
		}

		public void drinkSWAGPotion ()
		{
				mMaxHealthPoints = mMaxHealthPoints + 10;
		}

		public int getCharacterDamage ()
		{
				int tempWeaponStr = 0;
				switch (mSwordEquipped) {
				case 1:
						tempWeaponStr = 15;
						break;
				case 2:
						tempWeaponStr = 25;
						break;
				case 3:
						tempWeaponStr = 100;
						break;
				case 4:
						tempWeaponStr = 150;
						break;
				default:
						tempWeaponStr = 0;
						break;
				}
				return mDamage + tempWeaponStr;
		}

		public int getJumpLevel ()
		{
				return mJumpLvl + mBootsEquipped;
		}

		public void InflictDmgOnCharacter (int _AnAmountOfDamage)
		{
				mCurrentHealthPoints = mCurrentHealthPoints - _AnAmountOfDamage;
				if (mCurrentHealthPoints <= 0) {
						mIsAlive = false;
				}
				LevelUpAndRevive ();
		}

		public bool OwnsBoots1 ()
		{
				if (mBootsEquipped == 1) {
						return true;
				}
				return false;
		}

		public bool OwnsBoots2 ()
		{
				if (mBootsEquipped == 2) {
						return true;
				}
				return false;
		}

		public bool OwnsWpn1 ()
		{
				if (mSwordEquipped == 1) {
						return true;
				}
				return false;
		}

		public bool OwnsWpn2 ()
		{
				if (mSwordEquipped == 2) {
						return true;
				}
				return false;
		}

		public bool OwnsWpn3 ()
		{
				if (mSwordEquipped == 3) {
						return true;
				}
				return false;
		}

		public bool OwnsWpn4 ()
		{
				if (mSwordEquipped == 4) {
						return true;
				}
				return false;
		}

		public bool OwnsArmour1 ()
		{
				if (mArmourEquipped == 1) {
						return true;
				}
				return false;
		}

		public bool OwnsArmour2 ()
		{
				if (mArmourEquipped == 2) {
						return true;
				}
				return false;
		}

		public bool OwnsArmour3 ()
		{
				if (mArmourEquipped == 3) {
						return true;
				}
				return false;
		}

		public void setSwordEquipped (int _Id)
		{
				mSwordEquipped = _Id;
		}

		public int getSwordEquipped ()
		{
				return mSwordEquipped;
		}

		public void setBootsEquipped (int _Id)
		{
				mBootsEquipped = _Id;
		}
	
		public int getBootsEquipped ()
		{
				return mBootsEquipped;
		}

		public void setArmourEquipped (int _Id)
		{
				mArmourEquipped = _Id;
		}
	
		public int getArmourEquipped ()
		{
				return mArmourEquipped;
		}

		public void setSecWpnEquipped (int _Id)
		{
				mSecWpnEquipped = _Id;
		}
	
		public int getSecWpnEquipped ()
		{
				return mSecWpnEquipped;
		}

		public void setAmunitions (int _NbOfAmunitions)
		{
				mSecWpnAmunitions = _NbOfAmunitions;
		}

		public int getAmunitions ()
		{
				return mSecWpnAmunitions;
		}

		public void addAPieceOfCopper ()
		{
				mCopperPiecesOwned++;
		}

		public void addAPieceOfSilver ()
		{
				mSilverPiecesOwned++;
		}

		public void addAPieceOfGold ()
		{
				mGoldenPiecesOwned++;
		}

		public int getNbCopperOwned ()
		{
				return mCopperPiecesOwned;
		}

		public int getNbSilverOwned ()
		{
				return mSilverPiecesOwned;
		}

		public int getNbGoldOwned ()
		{
				return mGoldenPiecesOwned;
		}

		public int getPlayerNb ()
		{
				return mPlayerNb;
		}

		public void setPlayerNb (int _PlayerNb)
		{
				mPlayerNb = _PlayerNb;
		}

		public int getPlayerLvl ()
		{
				return mLvl;
		}

	static public Character get(int i){
		Character[] characters = FindObjectsOfType<Character> ();

		foreach (Character c in characters) {
			if (c.getPlayerNb () == i) {
				c.InflictDmgOnCharacter (99999);
				return c;
			}
		}
		return null;
	}
}
