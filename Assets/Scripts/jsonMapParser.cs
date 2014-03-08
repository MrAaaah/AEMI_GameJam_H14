using UnityEngine;
using System.Collections;
using System.IO;

public class jsonMapParser : MonoBehaviour
{

		public ArrayList maps = new ArrayList ();

		// Use this for initialization
		void Start ()
		{
				string[] levelDirectories = Directory.GetDirectories (Application.dataPath + "/Maps");
				foreach (string levelDirectory in levelDirectories) {
						string [] jsonMapFiles = Directory.GetFiles (levelDirectory, "*.json");
						foreach (string jsonMap in jsonMapFiles) {
								createAndAddMapFromJson (jsonMap);
						}
				}
				
		Debug.Log (maps.Count + " Maps loaded!");
		          
		}

		void createAndAddMapFromJson (string mapPath)
		{
				try {
						maps.Add (createMap (mapPath));
				} catch (System.Exception ex) {
						Debug.LogError (ex.ToString ());
						Debug.LogError ("map was " + mapPath);
				}		
		}

		Map createMap (string mapFullPath)
		{
				string jsonEncodedMap = Helpers.fileToString (mapFullPath);
				JSONObject j = new JSONObject (jsonEncodedMap);
				
				// fill map data (map array)
				Map tempMap = new Map ();
				JSONObject layers = j.GetField ("layers").list [0];
				JSONObject data = layers.GetField ("data");

				foreach (JSONObject i in data.list) {
						tempMap.layers.data.Add ((int)i.n);
				}

				tempMap.layers.height = (int)layers.GetField ("height").n;
				tempMap.layers.name = layers.GetField ("name").str;
				tempMap.layers.opacity = layers.GetField ("opacity").n;
				tempMap.layers.type = layers.GetField ("type").str;
				tempMap.layers.visible = layers.GetField ("visible").b;
				tempMap.layers.width = (int)layers.GetField ("width").n;
				tempMap.layers.x = (int)layers.GetField ("x").n;
				tempMap.layers.y = (int)layers.GetField ("y").n;
				
				tempMap.orientation = j.GetField ("orientation").str;
				tempMap.tileheight = (int)j.GetField ("tileheight").n;
				tempMap.tilewidth = (int)j.GetField ("tilewidth").n;
				tempMap.version = (int)j.GetField ("version").n;
				return tempMap;
		}

		//access data (and print it)
		void logCompleteJsonFile (JSONObject obj)
		{
				switch (obj.type) {
				case JSONObject.Type.OBJECT:
						for (int i = 0; i < obj.list.Count; i++) {
								string key = (string)obj.keys [i];
								JSONObject j = (JSONObject)obj.list [i];
								Debug.Log (key);
								logCompleteJsonFile (j);
						}
						break;
				case JSONObject.Type.ARRAY:
						foreach (JSONObject j in obj.list) {
								logCompleteJsonFile (j);
						}
						break;
				case JSONObject.Type.STRING:
						Debug.Log (obj.str);
						break;
				case JSONObject.Type.NUMBER:
						Debug.Log (obj.n);
						break;
				case JSONObject.Type.BOOL:
						Debug.Log (obj.b);
						break;
				case JSONObject.Type.NULL:
						Debug.Log ("NULL");
						break;
			
				}
		}

		// Update is called once per frame
		void Update ()
		{
	
		}
}
