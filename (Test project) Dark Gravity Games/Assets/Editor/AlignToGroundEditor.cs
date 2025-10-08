using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AlignToGround))]
public class AlignToGroundEditor : Editor
{
    private AlignToGround _alignToGround;

    private void OnEnable()
    {
        _alignToGround = target as AlignToGround;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Align to Ground"))
        {
            _alignToGround.PlaceObject();
        }
    }
}
