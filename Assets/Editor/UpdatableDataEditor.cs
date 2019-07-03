﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace WizardsCode.terrain
{
    [CustomEditor(typeof(UpdatableData), true)]
    public class UpdatableDataEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UpdatableData data = (UpdatableData)target;

            if (GUILayout.Button("Update"))
            {
                data.NotifyOfUpdatedValues();
                EditorUtility.SetDirty(target);
            }
        }

    }
}