using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapManager : MonoBehaviour
{
		public string level_path;
		private Map map;
		public GameObject[] tiles;
		private int height;
		private int width;
		private List<int> mapTiles;
		public int offsetx = 0;
		public int offsety = 0;
		private Vector2[] doors = new Vector2[2];
		private Vector2[] spawn = new Vector2[2];

		public mapManager (string level_path, int offsetx = 0, int offsety = 0)
		{
				this.offsetx = offsetx;
				this.offsety = offsety;
				this.level_path = level_path;
		}

		public void Start ()
		{
		level_path = Application.dataPath + "/Maps/Lvl1/Lvl1_00.json";
				this.map = new Map (level_path);
				drawMap ();
		}

		public void drawMap ()
		{
				height = this.map.getHeight ();
				width = this.map.getWidth ();
				mapTiles = this.map.getMapTiles ();

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
												GameObject tile = (GameObject)Instantiate (
						this.tiles [tilesvalue]
												);

												tile.transform.Translate (new Vector3 (j,height - 1 - i, 0));
												tile.transform.parent = transform;
										}
								} catch (System.Exception ex) {
										Debug.LogError (ex.ToString ());
										Debug.LogWarning ((int)mapTiles [i * width + j]);
								}
						}
				}
		}

		public void placePlayer ()
		{

		}

		public Vector3 getCamPos ()
		{
				float z = map.getWidth () / (2 * Mathf.Atan (Mathf.Deg2Rad * 30));
				return  new Vector3 (offsetx + map.getWidth () / 2 - 0.5f, offsety + map.getHeight () / 2 - 0.5f, -z);
		}

		public float getFieldOfView ()
		{
				return 30;
		}
}
