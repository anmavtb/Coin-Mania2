using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] Transform[] allPlatforms = new Transform[0];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3[] GetRandomPlatform()
    {
        Vector3[]  _platformSize = new Vector3[2];
        int _random = Random.Range(0, allPlatforms.Length);
        Bounds _bounds = allPlatforms[_random].GetComponent<Renderer>().bounds;
        _platformSize[0] = new Vector3(_bounds.extents.x, allPlatforms[_random].position.y, _bounds.extents.z);
        _platformSize[1] = new Vector3(-_bounds.extents.x, allPlatforms[_random].position.y, -_bounds.extents.z);
        return _platformSize;
    }

    private void OnDrawGizmos()
    {
        int _size = allPlatforms.Length;
        for (int i = 0; i < _size; i++)
        {
            Bounds _bounds = allPlatforms[i].GetComponent<Renderer>().bounds;
            Vector2 _gridSize = new Vector2(_bounds.extents.x * 2, _bounds.extents.z * 2);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(allPlatforms[i].position, new Vector3(_gridSize.x, 1, _gridSize.y));
            Gizmos.color = Color.white;
        }
    }
}
