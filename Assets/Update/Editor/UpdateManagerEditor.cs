#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Update.System;
using System;

[CustomEditor(typeof(UpdateManager))]
public class UpdateManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        UpdateManager updateManager = (UpdateManager)target;

        GUI.enabled = false;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Script");
        updateManager = (UpdateManager)EditorGUILayout.ObjectField(updateManager, typeof(UpdateManager), false);
        EditorGUILayout.EndHorizontal();
        GUI.enabled = true;

        GUILayout.Space(10);
        GUI.backgroundColor = Color.green;
        GUILayout.Label($"Update  { updateManager.Updates.Count}");
        for (int i = 0; i < updateManager.Updates.Count; i++)
        {
            updateManager.Updates[i].Foldout = EditorGUILayout.Foldout(updateManager.Updates[i].Foldout
                , $"Item {i} | Name {updateManager.Updates[i].Name}");
            if (updateManager.Updates[i].Foldout)
            {
                GUI.enabled = false;
                EditorGUILayout.IntField("Script Execution Order", updateManager.Updates[i].ScriptExecutionOrder);
                EditorGUILayout.IntField("Order Count", updateManager.Updates[i].OrderCount);
                EditorGUILayout.IntField("Call Count", updateManager.Updates[i].CallCount);
                GUI.enabled = true;
            }
        }

        GUILayout.Space(10);
        GUI.backgroundColor = Color.yellow;
        GUILayout.Label($"LateUpdate  { updateManager.LateUpdates.Count}");
        for (int i = 0; i < updateManager.LateUpdates.Count; i++)
        {
            updateManager.LateUpdates[i].Foldout = EditorGUILayout.Foldout(updateManager.LateUpdates[i].Foldout
                , $"Item {i} | Name {updateManager.LateUpdates[i].Name}");
            if (updateManager.LateUpdates[i].Foldout)
            {
                GUI.enabled = false;
                EditorGUILayout.IntField("Script Execution Order", updateManager.LateUpdates[i].ScriptExecutionOrder);
                EditorGUILayout.IntField("Order Count", updateManager.LateUpdates[i].OrderCount);
                EditorGUILayout.IntField("Call Count", updateManager.LateUpdates[i].CallCount);
                GUI.enabled = true;
            }
        }

        GUILayout.Space(10);
        GUI.backgroundColor = Color.blue;
        GUILayout.Label($"FixedUpdate  { updateManager.FixedUpdates.Count}");
        for (int i = 0; i < updateManager.FixedUpdates.Count; i++)
        {
            updateManager.FixedUpdates[i].Foldout = EditorGUILayout.Foldout(updateManager.FixedUpdates[i].Foldout
                , $"Item {i} | Name {updateManager.FixedUpdates[i].Name}");
            if (updateManager.FixedUpdates[i].Foldout)
            {
                GUI.enabled = false;
                EditorGUILayout.IntField("Script Execution Order", updateManager.FixedUpdates[i].ScriptExecutionOrder);
                EditorGUILayout.IntField("Order Count", updateManager.FixedUpdates[i].OrderCount);
                EditorGUILayout.IntField("Call Count", updateManager.FixedUpdates[i].CallCount);
                GUI.enabled = true;
            }
        }
    }
}

#endif
