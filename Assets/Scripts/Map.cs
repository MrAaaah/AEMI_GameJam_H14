using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Map
{
		public string jsonMapFilePath;
		public mapLayers layers = new mapLayers ();
		public string orientation;
		public int tileheight;
		public int tilewidth;
		public int version;

		public Map (string jsonMapFilePath)
		{

				string jsonEncodedMap = Helpers.fileToString (jsonMapFilePath);
				JSONObject j = new JSONObject (jsonEncodedMap);
				JSONObject layers = j.GetField ("layers").list [0];
				JSONObject data = layers.GetField ("data");
			
				foreach (JSONObject i in data.list) {
						this.layers.data.Add ((int)i.n);
				}
			
				this.layers.height = (int)layers.GetField ("height").n;
				this.layers.name = layers.GetField ("name").str;
				this.layers.opacity = layers.GetField ("opacity").n;
				this.layers.type = layers.GetField ("type").str;
				this.layers.visible = layers.GetField ("visible").b;
				this.layers.width = (int)layers.GetField ("width").n;
				this.layers.x = (int)layers.GetField ("x").n;
				this.layers.y = (int)layers.GetField ("y").n;
				
				this.orientation = j.GetField ("orientation").str;
				this.tileheight = (int)j.GetField ("tileheight").n;
				this.tilewidth = (int)j.GetField ("tilewidth").n;
				this.version = (int)j.GetField ("version").n;
		}

		public List<int> getMapTiles ()
		{
				return this.layers.data;
		}
		
		public int getHeight ()
		{
				return this.layers.height;
		}

		public int getWidth ()
		{
				return this.layers.width;
		}

}

