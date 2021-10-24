#pragma warning disable CS0234 // The type or namespace name 'Smart2DWaypoints' does not exist in the namespace 'Assets.Plugins' (are you missing an assembly reference?)
using Assets.Plugins.Smart2DWaypoints.Scripts;
#pragma warning restore CS0234 // The type or namespace name 'Smart2DWaypoints' does not exist in the namespace 'Assets.Plugins' (are you missing an assembly reference?)
using UnityEditor;

namespace Assets.Plugins.Editor.Smart2DWaypoints
{
#pragma warning disable CS0246 // The type or namespace name 'RigidbodyMover' could not be found (are you missing a using directive or an assembly reference?)
    [CustomEditor(typeof(RigidbodyMover))]
#pragma warning restore CS0246 // The type or namespace name 'RigidbodyMover' could not be found (are you missing a using directive or an assembly reference?)
    public class RigidbodyMoverEditor : WaypointsMoverEditor
    {
		protected override void DrawIsAlignToDirection ()
		{
			base.DrawIsAlignToDirection ();

			RigidbodyMover rigidbodyMover = _waypointsMover as RigidbodyMover;
			rigidbodyMover.RotationSpeed = EditorGUILayout.FloatField("Rotation speed", rigidbodyMover.RotationSpeed);
		}
    }
}
