using UnityEngine;

[CreateAssetMenu()]
public class TerrainData : UpdatableData
{
    public float uniformScale;

    [Header ("Mesh Settings")]
    public float meshHeightMultiply;
    public AnimationCurve meshHeightCurve;

    protected override void OnValidate() {
        if (meshHeightMultiply < 1) {
            meshHeightMultiply = 1;
        }
        base.OnValidate();
    }

    public float minHeight {
        get { return uniformScale * meshHeightMultiply * meshHeightCurve.Evaluate(0);}
    }

    public float maxHeight {
        get { return uniformScale * meshHeightMultiply * meshHeightCurve.Evaluate(1);}
    }
}
