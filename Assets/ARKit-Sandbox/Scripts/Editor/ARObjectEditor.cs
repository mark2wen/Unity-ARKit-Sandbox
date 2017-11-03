using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ARObject))]
public class LevelScriptEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        ARObject obj = (ARObject)target;

        SerializedProperty title = this.serializedObject.FindProperty("Title");
        EditorGUILayout.PropertyField(title, true);
		serializedObject.ApplyModifiedProperties();
       
        if (GUILayout.Button("Add reflection"))
        {
			CCReflectFloat f = new CCReflectFloat();
			obj.ReflectFloats.Add(f);
        } 
		else if (GUILayout.Button("Clear reflections"))
        {
			obj.ReflectFloats.Clear();
        }
		else {
			SerializedProperty reflectFloats = this.serializedObject.FindProperty("ReflectFloats");
			EditorGUILayout.PropertyField(reflectFloats, true);
			serializedObject.ApplyModifiedProperties();
		}
		



    }
}