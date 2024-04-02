using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] DebugManager debugManager = null;
    [SerializeField] Transform[] allPlatforms = new Transform[0];

    /// <summary>
    /// Chose a random platform from all platforms in "allPlatforms" and send back an array of two Vector3 symbolizing its corners.
    /// </summary>
    /// <returns></returns>
    public Vector3[] GetRandomPlatform()
    {
        Vector3[] _platformSize = new Vector3[2];
        int _random = Random.Range(0, allPlatforms.Length);
        Bounds _bounds = allPlatforms[_random].GetComponent<Renderer>().bounds;
        Vector2 _gridSize = new Vector2(_bounds.extents.x, _bounds.extents.z);
        _platformSize[0] = new Vector3(_gridSize.x + allPlatforms[_random].position.x, _bounds.extents.y + allPlatforms[_random].position.y, _gridSize.y + allPlatforms[_random].position.z);
        _platformSize[1] = new Vector3(-_gridSize.x + allPlatforms[_random].position.x, _bounds.extents.y + allPlatforms[_random].position.y, -_gridSize.y + allPlatforms[_random].position.z);
        return _platformSize;
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