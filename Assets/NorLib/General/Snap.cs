using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{

    static Vector3? s_globalGridSize = null;
    Vector3 localGridSize = Vector3.one;

    [SerializeField]
    bool useGlobalGrid = true;
    bool old_useGlobalGrid;
    [SerializeField]
    Vector3 gridSize;
    [SerializeField]
    bool SnapRelativeToParent = true;
    [SerializeField]
    bool deactivateInPlayMode = true;

    //write to Gridsite
    Vector3? oldGridSize = null;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && deactivateInPlayMode)
            return;

        SnapToGrid();
        Debug.Log("OnDrawGizmos");
    }

    private void OnValidate()
    {
        Debug.Log("OnValidate");
        if (old_useGlobalGrid == useGlobalGrid)
        {
            if (oldGridSize != null && oldGridSize != gridSize)
            {
                Debug.Log("Override");
                GridSize = gridSize;
            }
        }
        old_useGlobalGrid = useGlobalGrid;
        gridSize = GridSize;
    }

    void SnapToGrid()
    {
        Vector3 pos = SnapRelativeToParent ? transform.localPosition : transform.position;
        Vector3 grid = GridSize;
        oldGridSize = GridSize;
        old_useGlobalGrid = useGlobalGrid;
        Vector3 newPosition = Vector3.Scale(grid , new Vector3(Mathf.Round(pos.x / grid.x), Mathf.Round(pos.y / grid.y), Mathf.Round(pos.z / grid.z)));
        if (SnapRelativeToParent)
            transform.localPosition = newPosition;
        else
            transform.position = newPosition;

        gridSize = GridSize;
    }


    public Vector3 GridSize
    {
        get => useGlobalGrid ? GlobalGridSize : localGridSize;
        set
        {
            if (value.x > 0.00001 && value.y > 0.00001 && value.z > 0.00001)
            {
                if (useGlobalGrid)
                    GlobalGridSize = value;
                else
                    localGridSize = value;
            }
        }
    }

    public Vector3 GlobalGridSize
    {
        get
        {
            if(s_globalGridSize.HasValue)
            {
                return s_globalGridSize.Value;
            }
            else
            {
                /*string data = UnityEditor.EditorPrefs.GetString("globalGridSize", "");
                if(data != "")
                {
                    s_globalGridSize = JsonUtility.FromJson<Vector3>(data);
                }
                else
                {
                    s_globalGridSize = Vector3.one;
                }
                return s_globalGridSize.Value;*/
                return Vector3.one;
            }
        }
        set
        {
            if(value != s_globalGridSize)
            {
                s_globalGridSize = value;
                //UnityEditor.EditorPrefs.SetString("globalGridSize", JsonUtility.ToJson(s_globalGridSize));
            }
        }
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}

