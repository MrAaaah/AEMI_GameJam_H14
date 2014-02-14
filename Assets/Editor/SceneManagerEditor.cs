using UnityEditor;

[CustomEditor(typeof(SceneManager))] 
public class SceneManagerEditor : Editor {
	
	public override void OnInspectorGUI() {
		SceneManager myTarget = (SceneManager) target;
		
		EditorGUILayout.LabelField("Previous level: ", myTarget.previousLevel.ToString());
		EditorGUILayout.LabelField("Current level: ", myTarget.currentLevel.ToString());
	}
}