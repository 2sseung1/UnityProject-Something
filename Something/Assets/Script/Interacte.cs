using UnityEngine;

[RequireComponent(typeof(ObjectChecker))]
public abstract class Interacte : MonoBehaviour
{
    protected ObjectChecker _checker;

    void Awake()
    {
        _checker = GetComponent<ObjectChecker>();
    }

    public abstract void InteracteObject();
}