using UnityEngine;

[CreateAssetMenu()]
public class UpdatableData : ScriptableObject
{
    public event System.Action OnValuesUpdated;
    public bool autoUpdate;

    protected virtual void OnValidate() {
        if (autoUpdate) {
            UnityEditor.EditorApplication.update += UpdateValues;
        }
    }

    public void UpdateValues() {
        UnityEditor.EditorApplication.update -= UpdateValues;
        if (OnValuesUpdated != null) {
            OnValuesUpdated();
        }
    }
}
