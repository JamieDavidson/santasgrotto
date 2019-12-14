using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameDataStore))]
public sealed class GameDataStoreEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Populate store"))
        {
            var myTarget = (GameDataStore) target;

            var baseToys = GetAssetsByType<BaseToy>("t:BaseToy");

            var attachments = GetAssetsByType<ToyAttachment>("t:ToyAttachment");

            var paintJobs = GetAssetsByType<PaintJob>("t:PaintJob");

            myTarget.PopulateStore(baseToys, attachments, paintJobs);
        }

        EditorUtility.SetDirty(target);
    }

    private static IEnumerable<T> GetAssetsByType<T>(string typeFilter)
    {
        return AssetDatabase.FindAssets(typeFilter)
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(t => AssetDatabase.LoadAssetAtPath(t, typeof(T)))
            .Cast<T>();
    }
}
