using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapManager
{
		public string level_path;
		private Map map;
		public GameObject[] tiles;
		private int height;
		private int width;
		private List<int> mapTiles;
		public int offsetx = 0;
		public int offsety = 0;
		private GameObject parent;
		private bool drawn = false;
		private Vector2[] doors = new Vector2[2];
		private Vector2[] spawn = new Vector2[2];

		public mapManager (string level_path)
		{
				this.level_path = level_path;

				GameObject parent = GameObject.Instantiate (Resources.Load ("EmptyGameObject")) as GameObject;
				parent.transform.position = new Vector3 (offsetx, offsety);
				parent.name = "Level";
				
				
				
				this.map = new Map (level_path);
		}

		public GameObject getLevelObject ()
		{
				if (!drawn) {
			parent.SetActive(false);
						height = this.map.getHeight ();
						width = this.map.getWidth ();
						mapTiles = this.map.getMapTiles ();

		        
						//Draw non door and player tiles
						for (int i = 0; i < height; i++) {
								for (int j = 0; j < width; j++) {
								
										try {
												var tilesvalue = mapTiles [i * width + j];
												if (tilesvalue == 2 || tilesvalue == 3) {
														doors [tilesvalue - 2] = new Vector2 (j, i);
												} else if (tilesvalue == 4 || tilesvalue == 5) {
														spawn [tilesvalue - 4] = new Vector2 (j, i);
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
						drawn = true;
				}


				return parent;
		}

		public void placePlayer ()
		{

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
