using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] Control player;
    [SerializeField] List<walkable> paths;
    [SerializeField] walkable pathPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var lastPath = paths[paths.Count - 1];
        var firstPath = paths[0];
        if(lastPath.transform.position.z - player.transform.position.z < 120)
        {
            var path = Instantiate(pathPrefab, new Vector3(lastPath.transform.position.x, lastPath.transform.position.y, lastPath.transform.position.z + 20f), Quaternion.identity);
            paths.Add(path);
            path.transform.parent = transform;
        }

        if(player.transform.position.z - firstPath.transform.position.z > 40)
        {
           
            paths.Remove(firstPath);
            Destroy(firstPath.gameObject);

        }
    }
        
}
