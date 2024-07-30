namespace smoonLib.core;

public static class Collector
{
    private static readonly List<IContainer> _containers = new();

    private static int _containerIndex = -1;

    private static IContainer _currentContainer;

    public static void AddToCollector(IContainer container)
    {
        _containers.Add(container);
    }

    public static void ChangeContainer(int index)
    {
        if (_containers.Count == 0) return;
        if (index > _containers.Count) DebugUtility.DebugException("Index more than containers list");
        _containerIndex = index;
        _containers[_containerIndex].Awake();
    }

    internal static void UpdateState()
    {
        if (_currentContainer == _containers[_containerIndex]) return;
        _currentContainer = _containers[_containerIndex];
        _currentContainer.Start();
    }

    internal static void UpdateContainer()
    {
        _containers[_containerIndex].Update();
    }
}