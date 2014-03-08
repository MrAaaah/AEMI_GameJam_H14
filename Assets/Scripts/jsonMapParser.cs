using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class jsonMapParser : MonoBehaviour
{

		private List<Map> maps = new List<Map> ();

		// Use this for initialization
		void Start ()
		{
				string[] levelDirectories = Directory.GetDirectories (Application.dataPath + "/Maps");
				foreach (string levelDirectory in levelDirectories) {
						
						string [] jsonMapFiles = Directory.GetFiles (levelDirectory, "*.json");
						foreach (string jsonMapFile in jsonMapFiles) {
								appendNewMap (jsonMapFile);
						}
				}
				
				Debug.Log (maps.Count + " Maps loaded!");
		          
		}

		void appendNewMap (string mapPath)
		{
				try {
						maps.Add (new Map (mapPath));
				} catch (System.Exception ex) {
						Debug.LogError (ex.ToString ());
						Debug.LogError ("map was " + mapPath);
				}		
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
