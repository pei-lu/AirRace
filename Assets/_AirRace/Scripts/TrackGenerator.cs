using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation;

public class TrackGenerator : MonoBehaviour
{
	public TextAsset file;
	public bool closedLoop = true;

	private List<Vector3> waypoints;

	void Start()
	{
		waypoints = new List<Vector3>();
		ParseFile();
		BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
		GetComponent<PathCreator>().bezierPath = bezierPath;
	}

	void ParseFile()
	{
		float ScaleFactor = 0.02564103f;
		string content = file.ToString();
		string[] lines = content.Split('\n');
		for (int i = 0; i < lines.Length; i++)
		{
			string[] coords = lines[i].Split(' ');
			Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
			waypoints.Add(pos * ScaleFactor);
		}
	}
}
