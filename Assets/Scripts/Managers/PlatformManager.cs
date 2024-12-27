using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] DebugManager debugManager = null;
    [SerializeField] Transform[] allPlatforms = new Transform[0];

    public Transform[] GetAllPlatforms() { return allPlatforms; }

    public Vector3[] GetPlatformCorners(Transform platform)
    {
        Bounds bounds = platform.GetComponent<Renderer>().bounds;
        Vector2 gridSize = new Vector2(bounds.extents.x, bounds.extents.z);

        Vector3[] corners = new Vector3[2];
        corners[0] = new Vector3(gridSize.x + platform.position.x, bounds.extents.y + platform.position.y, gridSize.y + platform.position.z);
        corners[1] = new Vector3(-gridSize.x + platform.position.x, bounds.extents.y + platform.position.y, -gridSize.y + platform.position.z);

        return corners;
    }

    private void OnDrawGizmos()
    {
        int _size = allPlatforms.Length;
        for (int i = 0; i < _size; i++)
        {
            Bounds _bounds = allPlatforms[i].GetComponent<Renderer>().bounds;
            Vector2 _gridSize = new Vector2(_bounds.extents.x, _bounds.extents.z);
            AnmaGizmos.DrawCube(allPlatforms[i].position, new Vector3(_gridSize.x * 2, _bounds.extents.y * 2, _gridSize.y * 2), Color.magenta, AnmaGizmos.DrawMode.Wire, debugManager.debugPlatforms);
            AnmaGizmos.DrawSphere(new Vector3(_gridSize.x + allPlatforms[i].position.x, _bounds.extents.y + allPlatforms[i].position.y, _gridSize.y + allPlatforms[i].position.z), 1, Color.blue, AnmaGizmos.DrawMode.Wire, debugManager.debugPlatforms);
            AnmaGizmos.DrawSphere(new Vector3(-_gridSize.x + allPlatforms[i].position.x, _bounds.extents.y + allPlatforms[i].position.y, -_gridSize.y + allPlatforms[i].position.z), 1, Color.red, AnmaGizmos.DrawMode.Wire, debugManager.debugPlatforms);
        }
    }
}