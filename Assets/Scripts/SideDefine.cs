using System.Collections.Generic;
using UnityEngine;

public class SideDefine : MonoBehaviour
{
    [SerializeField] private List<Transform> _sides;

    [ContextMenu("Define Side")]
    private void Define()
    {
        Vector3 topPosition = _sides[0].position;
        int sideValue = 1;
        for (int i = 1; i < _sides.Count; i++)
        {
            if (_sides[i].position.y > topPosition.y)
            {
                topPosition = _sides[i].position;
                sideValue = i + 1;
            }
        }

        Debug.Log(sideValue);
    }
}
