using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation;
using UnityEngine.UIElements;

public class TrackGenerator : MonoBehaviour
{
	public TextAsset file;
	public bool closedLoop;
	public GameObject waypointPrefab;
	public GameObject tunnelPrefab;
	public int tunnelNumber;
	public GameObject player;
	private List<Vector3> waypointPositions;
	private List<Vector3> tunnelPositions;
	private List<Quaternion> tunnelRotations;

	private PathCreator pathCreator;

	void Start()
	{
		waypointPositions = new List<Vector3>();
		tunnelPositions = new List<Vector3>();
		tunnelRotations = new List<Quaternion>();
		pathCreator = GetComponent<PathCreator>();
		ParseFile();
		GeneratePath();
		GenerateTunnel();
		InitPlayer();
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
			waypointPositions.Add(pos * ScaleFactor);
		}
	}

	void GeneratePath()
	{
		foreach (Vector3 waypointPos in waypointPositions)
		{
			Instantiate(waypointPrefab, waypointPos, Quaternion.identity);
		}
		BezierPath bezierPath = new BezierPath(waypointPositions, closedLoop, PathSpace.xyz);
		GetComponent<PathCreator>().bezierPath = bezierPath;
	}

	void GenerateTunnel()
	{
		float delta = 1.0f / (tunnelNumber + 1);
		for (int i = 0; i < tunnelNumber; i++)
		{
			tunnelPositions.Add(pathCreator.path.GetPointAtTime(i * delta));
			tunnelRotations.Add(pathCreator.path.GetRotation(i * delta));
			Instantiate(tunnelPrefab, tunnelPositions[i], tunnelRotations[i]);
		}

	}

	void InitPlayer()
	{
		player.transform.position = waypointPositions[0];
		player.transform.forward = pathCreator.path.GetDirection(0);
	}
}
