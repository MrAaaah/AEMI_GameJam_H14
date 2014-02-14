using UnityEditor;


[CustomEditor(typeof(GameStateManager))] 
public class GameStateManagerEditor : Editor {

	public override void OnInspectorGUI() {
	GameStateManager myTarget = (GameStateManager) target;

		string previousState;

		if (myTarget.previousState != null)
			previousState = myTarget.previousState.ToString();
		else
			previousState = "";


		EditorGUILayout.LabelField("Previous state: ", previousState);
		EditorGUILayout.LabelField("Current state: ", myTarget.currentState.ToString());

//		if (UnityEngine.GUI.changed)
//			EditorUtility.SetDirty (target);
	}
}