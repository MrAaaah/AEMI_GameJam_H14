using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CraftManager : MonoBehaviour {

	public Texture mSelecter;
	public Texture2D mBodyUI;
	
	public Texture2D mCopper;
	public Texture2D mSilver;
	public Texture2D mGold;
	
	public Texture2D mIconeSword1;
	public Texture2D mIconeSword2;
	public Texture2D mIconeSword3;
	public Texture2D mIconeSword4;
	public Texture2D mIconeArmour1;
	public Texture2D mIconeArmour2;
	public Texture2D mIconeArmour3;
	public Texture2D mIconeBoots1;
	public Texture2D mIconeBoots2;
	public Texture2D mIconeSubWpn1;
	public Texture2D mIconeSubWpn2;
	public Texture2D mIconeSubWpn3;
	public Texture2D mIconeSubWpn4;
	public Texture2D mIconeSubWpn5;
	public Texture2D mIconeSubWpn6;
	public Texture2D mIconePotion1;
	public Texture2D mIconePotion2;
	
	private Rect mBodyGUIRect;

	private Rect mFirstOptionRect;
	private Rect mSecondOptionRect;
	private Rect mThirdOptionRect;

	private Rect mSelecterRect;
	private Rect mTitleRect;
	private Rect mSubTitleRect;
	private Rect mItemNameRect;
	private Rect mItemDescRect;

	private Craftable mSword1;
	private Craftable mSword2;
	private Craftable mSword3;
	private Craftable mSword4;
	private Craftable mArmor1;
	private Craftable mArmor2;
	private Craftable mArmor3;
	private Craftable mBoots1;
	private Craftable mBoots2;
	private Craftable mPotionGentleDrunk;
	private Craftable mPotionSWAG;
	private Craftable mKnives;
	private Craftable mKunai;
	private Craftable mSpitBottle;
	private Craftable mAvalancheHorn;
	private Craftable mLazerCandy;
	private Craftable mDoomDevice;

	private Character mCharacter;

	private List<Craftable> mCraftableCompleteList;
	private List<Craftable> mCraftableAvailableList;
	private List<Craftable> mCraftableChoiceList;

	private int mSelecterIndex = 1;

	private bool mHasOnlyTwoOptions = true;
	private bool mIsActivated = false;
	private bool mAllowMovement = true;
	
	// Use this for initialization
	void Start () {
		mCraftableCompleteList = new List<Craftable>();
		mCraftableAvailableList = new List<Craftable>();
		mCraftableChoiceList = new List<Craftable> ();

		InitCraftable ();

		mCraftableChoiceList.Add (mPotionGentleDrunk);
		mCraftableChoiceList.Add (mPotionSWAG);

		mBodyGUIRect =  new Rect(Screen.width/2 - 256,50,512,512);

		mTitleRect = 	new Rect(mBodyGUIRect.x + 10, mBodyGUIRect.y + 10, 502, 32);
		mSubTitleRect = new Rect(mBodyGUIRect.x + 10, mTitleRect.y + mTitleRect.height + 10, 502, 32);

		mFirstOptionRect =  new Rect(mBodyGUIRect.x + 21 * 1 + 128 * 0, mSubTitleRect.y + mSubTitleRect.height + 25, 128, 128);
		mSecondOptionRect = new Rect(mBodyGUIRect.x + 21 * 3 + 128 * 1, mSubTitleRect.y + mSubTitleRect.height + 25, 128, 128);
		mThirdOptionRect =  new Rect(mBodyGUIRect.x + 21 * 5 + 128 * 2, mSubTitleRect.y + mSubTitleRect.height + 25, 128, 128);

		mSelecterRect = new Rect(mFirstOptionRect.x - 11,mFirstOptionRect.y - 11,150,150);

		mItemNameRect = new Rect(mBodyGUIRect.x + 10, mSubTitleRect.y + mSubTitleRect.height + 178, 502, 32);
		mItemDescRect = new Rect(mBodyGUIRect.x + 10, mItemNameRect.y + mItemNameRect.height + 10, 502, 200);

		mIsActivated = true;
	}
	
	// Update is called once per frame
	void Update () {
				if (mCharacter != null) {
						if (mCharacter.getPlayerNb() == 1) {

								if ((Input.GetKeyDown ("d")) && (mAllowMovement)) {
										switch (mSelecterIndex) {
										case 1:
												mSelecterRect.x = mSelecterRect.x + 128 + 42;
												mSelecterIndex++;
												break;
										case 2:
												if (!mHasOnlyTwoOptions) {
														mSelecterRect.x = mSelecterRect.x + 128 + 42;
														mSelecterIndex++;
												}
												break;
										default:
												break;
										}
										mAllowMovement = false;
								}
								if (Input.GetKeyUp ("d")) {
										mAllowMovement = true;
								}

								if ((Input.GetKeyDown ("a")) && (mAllowMovement)) {
										switch (mSelecterIndex) {
										case 3:
												mSelecterRect.x = mSelecterRect.x - (128 + 42);
												mSelecterIndex--;
												break;
										case 2:
												mSelecterRect.x = mSelecterRect.x - (128 + 42);
												mSelecterIndex--;
												break;
										default:
												break;
										}
										mAllowMovement = false;
								}
								if (Input.GetKeyUp ("a")) {
										mAllowMovement = true;
								}

								if (Input.GetKeyDown ("space")) {
										//TODO: action!
								}

						}
				}
			
	}

	void OnGUI(){
		if (mIsActivated && (mCharacter != null)) {
			int tempPlayerNb = mCharacter.getPlayerNb();
			string tempString = tempPlayerNb.ToString();
			int tempPlayerLvl = mCharacter.getPlayerLvl() + 1;
			string tempString2 = tempPlayerLvl.ToString();

			GUI.Label (mBodyGUIRect, mBodyUI);
			GUI.color = Color.black;
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 20;
			GUI.Label (mTitleRect, "Le joueur " + tempString + " est mort et atteint le niveau " + tempString2 + " !!!");
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 14;
			GUI.Label (mSubTitleRect, "Il lui reste " + "5" + " secondes pour choisir un item a créer!");

			if(mHasOnlyTwoOptions){
				GUI.Label (mFirstOptionRect, mIconeSword1);
				GUI.Label (mSecondOptionRect, mIconeSword1);
			}
			else{
				GUI.Label (mFirstOptionRect, mIconeSword1);
				GUI.Label (mSecondOptionRect, mIconeSword1);
				GUI.Label (mThirdOptionRect, mIconeSword1);
			}

			GUI.DrawTexture(mSelecterRect,mSelecter,ScaleMode.StretchToFill);

			GUI.Label (mItemNameRect, mCraftableChoiceList[mSelecterIndex - 1].getName());
			GUI.Label (mItemDescRect, mCraftableChoiceList[mSelecterIndex - 1].getDesc());

		}
	}

	public void setCharacter(Character _aCharacter){
		mCharacter = _aCharacter;
		CreateAvailableCraftableTable ();
	}

	private void CreateAvailableCraftableTable(){
		int TempMaxValue = mCharacter.getTotalValue ();
		mCraftableAvailableList = new List<Craftable>();

		for (int i = 0; i < mCraftableCompleteList.Count - 1; i++) {
			if(mCraftableCompleteList[i].getValue() <= TempMaxValue){
				mCraftableAvailableList.Add (mCraftableCompleteList[i]);
			}		
		}

		mCraftableChoiceList = new List<Craftable> ();

		if (mCraftableAvailableList.Count - 1 > 2) {
			mHasOnlyTwoOptions = false;
			int j = 0;
			while(j < 3){
				int tempRandom = Random.Range(0, mCraftableAvailableList.Count - 1);
				mCraftableChoiceList.Add (mCraftableAvailableList[tempRandom]);
				mCraftableAvailableList.RemoveAt(tempRandom);
				j++;
			}

		} else {
			mHasOnlyTwoOptions = true;
			mCraftableChoiceList.Add (mPotionGentleDrunk);
			mCraftableChoiceList.Add (mPotionSWAG);
		}
		mIsActivated = true;
	}
	
	private void InitCraftable(){
		mSword1 = new Craftable (3, "Poisson Odorant", "Arme. Mieux qu’un poisson malodorant et c’est tout. Ajoute 15 à l’attaque.", 1, CraftSword1, mIconeSword1);
		mSword1 = new Craftable (4, "Épée de Puissant Gobelin", "Arme. Épée du plus puissant des gobelins. Ça ne veut pas dire grand-chose en fait. Ajoute 25 à l’attaque.", 3, CraftSword2, mIconeSword2);
		mSword1 = new Craftable (5, "Épée - Hache", "Arme très naine. Ne sait pas ce qu’elle veut être. Ajoute + 100 à l’attaque.", 7, CraftSword3, mIconeSword3);
		mSword1 = new Craftable (6, "Big A$$ Sword", "Arme. Aucune traduction française disponible. La meilleure arme ? Ajoute + 150 à l’attaque.", 16, CraftSword4, mIconeSword4);

		mArmor1 = new Craftable (13, "Armure très défectueuse", "Armure. L’ingénierie naine à sont meilleur. Cette armure a passé une lourde batterie de tests pour prouver son efficacité. Ajoute + 50 points de vie.", 3, CraftArmour1, mIconeArmour1);
		mArmor2 = new Craftable (14, "Armure Glamour", "Armure. L’ingénierie naine à sont meilleur. Cette armure n’a PAS passé une lourde batterie de tests pour prouver son efficacité. Elle est juste efficace. Ajoute + 150 points de vie.", 8, CraftArmour2, mIconeArmour2);
		mArmor3 = new Craftable (15, "Protege-Barbe B-2110", "Armure. Protège l’organe le plus important des nains. Périme en 2100. Ajoute + 250 points de vie.", 12, CraftArmour3, mIconeArmour3);

		mBoots1 = new Craftable (1, "Derniers Ressorts", "Bottes. Meilleur que les premiers ressorts… Moins explosifs aussi. Améliore un peu le saut.", 3, CraftBoots1, mIconeBoots1);
		mBoots2 = new Craftable (2, "Botte a Pro-Pulsion", "Bottes. Pulsion professionnelle garantie. Améliore beaucoup le saut.", 8, CraftBoots2, mIconeBoots2);

		mPotionGentleDrunk = new Craftable (16, "Potion de Gentilhomme Ivre", "Consommable. Le meilleur de deux mondes. Très économique. Ajoute 5 à l’attaque.", 0, CraftPotionGentleDrunk, mIconePotion1);
		mPotionSWAG = new Craftable (17, "Potion de SWAG", "Consommable. SWAG veut dire Super-Wagon-A-Gyroscope. Vous pensiez quoi? Ajoute +10 points de vie.", 0, CraftPotionSWAG, mIconePotion2);

		mKnives = new Craftable (7, "Couteaux de Jet", "Arme secondaire. Lance un couteau en ligne droite. Attention au yeux. Utilisable 3 fois.", 3, CraftKnives, mIconeSubWpn1);
		mKunai = new Craftable (8, "Kunais", "Arme secondaire. Lance trois couteaux en face. Recommandé pour les ninjas. Déconseiller pour les nains. Utilisable 3 fois.", 5, CraftKunais, mIconeSubWpn2);
		mSpitBottle = new Craftable (9, "Bouteille de Bave", "Arme secondaire. Excellent pour cracher au visage de vos adversaires! Ne dissous pas les armures. Utilisable 5 fois.", 2, CraftSpitBottle, mIconeSubWpn3);
		mAvalancheHorn = new Craftable (10, "Corne d'Avalanche", "Arme secondaire. Fait tomber des rochers au dessus de l’utilisateur. Cause principale de suicide dans le jeu. Utilisable 3 fois.", 3, CraftHorn, mIconeSubWpn4);
		mLazerCandy = new Craftable (11, "Bonbon au lazer", "Arme secondaire. Délicieux bonbon au laser. Attention : les nains digèrent mal les lasers… Utilisable 2 fois.", 8, CraftCandy, mIconeSubWpn5);
		mDoomDevice = new Craftable (12, "Appareil d'Anéantissement", "Arme secondaire. Le créateur est mort après s’être utilisé comme cobaye. TRÈS DANGEREUX!!! Utilisable 1 fois.", 15,CraftDoomDevice, mIconeSubWpn6);

		mCraftableCompleteList.Add (mSword1);
		mCraftableCompleteList.Add (mSword2);
		mCraftableCompleteList.Add (mSword3);
		mCraftableCompleteList.Add (mSword4);
		mCraftableCompleteList.Add (mArmor1);
		mCraftableCompleteList.Add (mArmor2);
		mCraftableCompleteList.Add (mArmor3);
		mCraftableCompleteList.Add (mBoots1);
		mCraftableCompleteList.Add (mBoots2);
		mCraftableCompleteList.Add (mKnives);
		mCraftableCompleteList.Add (mKunai);
		mCraftableCompleteList.Add (mSpitBottle);
		mCraftableCompleteList.Add (mAvalancheHorn);
		mCraftableCompleteList.Add (mLazerCandy);
		mCraftableCompleteList.Add (mDoomDevice);
		mCraftableCompleteList.Add (mPotionGentleDrunk);
		mCraftableCompleteList.Add (mPotionSWAG);
	}

	public void CraftSword1(){
		mCharacter.setSwordEquipped (1);
	}

	public void CraftSword2(){
		mCharacter.setSwordEquipped (2);
	}

	public void CraftSword3(){
		mCharacter.setSwordEquipped (3);
	}

	public void CraftSword4(){
		mCharacter.setSwordEquipped (4);
	}

	public void CraftArmour1(){
		mCharacter.setArmourEquipped (1);
	}

	public void CraftArmour2(){
		mCharacter.setArmourEquipped (2);
	}

	public void CraftArmour3(){
		mCharacter.setArmourEquipped (3);
	}

	public void CraftBoots1(){
		mCharacter.setBootsEquipped (1);
	}

	public void CraftBoots2(){
		mCharacter.setBootsEquipped (2);
	}

	public void CraftKnives(){
		mCharacter.setSecWpnEquipped (1);
		mCharacter.setAmunitions (3);
	}
	
	public void CraftKunais(){
		mCharacter.setSecWpnEquipped (2);
		mCharacter.setAmunitions (3);
	}
	
	public void CraftSpitBottle(){
		mCharacter.setSecWpnEquipped (3);
		mCharacter.setAmunitions (5);
	}

	public void CraftHorn(){
		mCharacter.setSecWpnEquipped (4);
		mCharacter.setAmunitions (5);
	}
	
	public void CraftCandy(){
		mCharacter.setSecWpnEquipped (5);
		mCharacter.setAmunitions (2);
	}
	
	public void CraftDoomDevice(){
		mCharacter.setSecWpnEquipped (6);
		mCharacter.setAmunitions (1);
	}

	public void CraftPotionGentleDrunk(){
		mCharacter.drinkGentleDrunkPotion ();
	}

	public void CraftPotionSWAG(){
		mCharacter.drinkSWAGPotion ();
	}
}

public class Craftable{
	
	private int mId;
	private string mName;
	private string mDescription;
	private int value;
	private MyFunction craft;
	private Texture2D mTexture;

	public delegate void MyFunction();

	public Craftable(int _Id, string _Name, string _Description, int _value, MyFunction _Function, Texture2D _aTexture){
		mId = _Id;
		mName = _Name;
		mDescription = _Description;
		value = _value;
		mTexture = _aTexture;
	}

	public Texture2D getTexture(){
		return mTexture;
	}

	public string getName(){
		return mName;
	}

	public string getDesc(){
		return mDescription;
	}

	public int getValue(){
		return value;
	}

	public void craftItem(){
		craft();
	}
}