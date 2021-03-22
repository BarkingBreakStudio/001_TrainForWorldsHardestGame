using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class NorLibExtensions
{
    public static bool CompareTags(this Component component, IEnumerable<string> tags)
    {
        return tags.Contains(component.tag);
    }

    public static bool CompareTags(this GameObject gameObject, IEnumerable<string> tags)
    {
        return tags.Contains(gameObject.tag);
    }

}
