using UnityEngine;
using System.Collections;

class Map
{
		public mapLayers layers = new mapLayers ();
		public string orientation;
		public int tileheight;
		public int tilewidth;
		public int version;

		public ArrayList getMapData ()
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

