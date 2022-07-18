using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IApplicable
{
    public void Apply(Transform target);

    public bool CanApplay(Transform target);
}
