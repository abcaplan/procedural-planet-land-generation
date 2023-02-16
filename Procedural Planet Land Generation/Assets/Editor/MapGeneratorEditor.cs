using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (NoiseMapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        NoiseMapGenerator mapGen = (NoiseMapGenerator) target;

        if (DrawDefaultInspector()) {
            if (mapGen.autoUpdate) {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }
    }
}
