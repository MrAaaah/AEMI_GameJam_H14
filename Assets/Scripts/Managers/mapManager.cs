using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapManager
{
		public string level_path;
		private Map map;
		public GameObject[] tiles;
		private List<int> mapTiles;
		private GameObject parent;
		private GameObject doors_parent;
		private bool drawn = false;
		private Vector2[] doors = new Vector2[2];
		private Vector2[] spawn = new Vector2[2];
		private bool spawned = false;
		private GameObject[] players = new GameObject[2];

		public mapManager (string level_path, GameObject[] tileset)
		{
				this.level_path = level_path;
				this.tiles = tileset;

				parent = GameObject.Instantiate (Resources.Load ("EmptyGameObject")) as GameObject;
				parent.name = "Level";

				doors_parent = GameObject.Instantiate (Resources.Load ("EmptyGameObject")) as GameObject;
				doors_parent.name = "Doors";
				doors_parent.transform.parent = parent.transform;
				
				this.map = new Map (level_path);
		}

		public GameObject getLevelObject ()
		{
				if (!drawn) {
						//parent.SetActive (false);
						int height = this.map.getHeight ();
						int width = this.map.getWidth ();
						mapTiles = this.map.getMapTiles ();

		        
						//Draw non door and player tiles
						for (int i = 0; i < height; i++) {
								for (int j = 0; j < width; j++) {
								
										try {
												var tilesvalue = mapTiles [i * width + j];
												if (tilesvalue == 2 || tilesvalue == 3) {
														doors [tilesvalue - 2] = new Vector2 (j, i);
												} else if (tilesvalue == 4 || tilesvalue == 5) {
														spawn [tilesvalue - 4] = new Vector2 (j-1, i-1);
												} else if (tilesvalue == 0) {
												} else {
														GameObject tile = (GameObject)GameObject.Instantiate (
						this.tiles [tilesvalue]
														);

														tile.transform.Translate (new Vector3 (j, height - 1 - i, 0));
														tile.transform.parent = parent.transform;
												}
										} catch (System.Exception ex) {
												Debug.LogError (ex.ToString ());
												Debug.LogWarning ((int)mapTiles [i * width + j]);
										}
								}
		
						}

						for (int i = 0; i < 2; i++) {
								GameObject tile = (GameObject)GameObject.Instantiate (
					this.tiles [i + 2]
								);

								Vector2 pos = doors [i];
				
								tile.transform.Translate (new Vector3 (pos.x, height - 1 - pos.y, 0));
								tile.transform.parent = doors_parent.transform;
						}
						drawn = true;
				}


				return parent;
		}

		public void spawnPlayer ()
		{
				destroyPlayer ();
				for (int i = 0; i < 2; i++) {
						players [i] = (GameObject)GameObject.Instantiate (
				this.tiles [i + 4]);
						Vector2 pos = spawn [i];
				
						players [i].transform.Translate (new Vector3 (pos.x, this.map.getHeight () - 1 - pos.y, 0));
						players [i].transform.parent = parent.transform;
						players [i].GetComponent<PlayerControl> ().PlayerNumber = i + 1;
			players [i].layer = 9 + i;

				}
				spawned = true;
		}

		public void destroyPlayer ()
		{
				if (spawned) {
						GameObject.Destroy (players [0]);
						GameObject.Destroy (players [1]);
				}
		}

		public Vector3 getCamPos ()
		{
				float z = map.getWidth () / (2 * Mathf.Atan (Mathf.Deg2Rad * 30));
				return  new Vector3 (map.getWidth () / 2 - 0.5f, map.getHeight () / 2 - 0.5f, -z);
		}

		public float getFieldOfView ()
		{
				return 30;
		}
}
