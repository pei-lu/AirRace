List<Vector3> ParseFile ()
{
		float ScaleFactor = 0.02564103f;
		List<Vector3> positions = new List<Vector3>();
		string content = File.ToString();
		string[] lines = content.Split('\n');
		for (int i = 0; i < lines.Length; i++)
		{
				string[] coords = lines[i].Split(' ');
				Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
				positions.Add(pos * ScaleFactor);
		}
		return positions;
}