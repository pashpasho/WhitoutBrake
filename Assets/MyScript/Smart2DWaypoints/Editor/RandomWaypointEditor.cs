#pragma warning disable CS0234 // The type or namespace name 'Smart2DWaypoints' does not exist in the namespace 'Assets.Plugins' (are you missing an assembly reference?)
using Assets.Plugins.Smart2DWaypoints.Scripts;
#pragma warning restore CS0234 // The type or namespace name 'Smart2DWaypoints' does not exist in the namespace 'Assets.Plugins' (are you missing an assembly reference?)
using UnityEditor;
using UnityEngine;

namespace Assets.Plugins.Editor.Smart2DWaypoints
{
#pragma warning disable CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
	[CustomEditor(typeof(RandomWaypoint))]
#pragma warning restore CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
	public class RandomWaypointEditor : UnityEditor.Editor
	{
		private const int RandomPointsCount = 10;
		private static readonly Vector3[] _ellipsePositions = new Vector3[RandomWaypoint.EllipseResolution + 1];

		public void OnSceneGUI()
		{
			DrawSceneGUI(target as RandomWaypoint);
		}

#pragma warning disable CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		public static void DrawSceneGUI(RandomWaypoint waypoint)
#pragma warning restore CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		{
			DrawEllipse(waypoint);
			DrawHandles(waypoint);
		}

#pragma warning disable CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		private static void DrawHandles(RandomWaypoint waypoint)
#pragma warning restore CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		{
			Handles.color = Color.cyan;
			float handleSize = HandleUtility.GetHandleSize(waypoint.transform.position) * 0.1f;
			Quaternion q = Quaternion.AngleAxis(waypoint.Rotation, Vector3.forward);

			Vector3 newPosX = Handles.FreeMoveHandle(
				q * (new Vector3(waypoint.RadiusX, 0, 0)) + waypoint.transform.position,
				Quaternion.identity, handleSize, Vector3.one, Handles.CubeHandleCap);
			waypoint.RadiusX = Mathf.Abs((Quaternion.Inverse(q) * (newPosX - waypoint.transform.position)).x);

			Vector3 newPosY = Handles.FreeMoveHandle(
				q * (new Vector3(0, waypoint.RadiusY, 0)) + waypoint.transform.position,
				Quaternion.identity, handleSize, Vector3.one, Handles.CubeHandleCap);
			waypoint.RadiusY = Mathf.Abs((Quaternion.Inverse(q) * (newPosY - waypoint.transform.position)).y);


			Vector3 newPosRotation = Handles.FreeMoveHandle(
				q * (new Vector3(0, -waypoint.RadiusY, 0)) + waypoint.transform.position,
				Quaternion.identity, handleSize*1.25f, Vector3.one, Handles.SphereHandleCap);
			Vector3 pos = Quaternion.Inverse(q) * (newPosRotation - waypoint.transform.position);

			float angle = Vector3.Angle(new Vector3(0, -waypoint.RadiusY, 0), pos);
			waypoint.Rotation = (waypoint.Rotation + Mathf.Sign(pos.x)* angle)%360f;
		}

#pragma warning disable CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		private static void DrawEllipse(RandomWaypoint waypoint)
#pragma warning restore CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		{
			Handles.color = Color.blue;
			waypoint.UpdateEllipsePoints(_ellipsePositions);
			Handles.DrawPolyLine(_ellipsePositions);
			GenerateRandomPoint(waypoint);			
		}

#pragma warning disable CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		private static void GenerateRandomPoint(RandomWaypoint waypoint)
#pragma warning restore CS0246 // The type or namespace name 'RandomWaypoint' could not be found (are you missing a using directive or an assembly reference?)
		{
			float size = HandleUtility.GetHandleSize(waypoint.transform.position)*0.01f;
			for (int i = 0; i < RandomPointsCount; i++)
				Handles.DrawSolidDisc(waypoint.GenerateRandomPoint(), Vector3.forward, size);
		}

	}
}
