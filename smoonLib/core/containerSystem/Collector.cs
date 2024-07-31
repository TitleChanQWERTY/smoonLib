namespace smoonLib.core;

public static class Collector
{
    private static readonly List<IContainer> _containers = new();

    private static int _containerIndex = -1;

    private static IContainer _currentContainer;

    public static IContainer AddToCollector(IContainer container)
    {
        _containers.Add(container);
        return container;
    }

    public static int ChangeContainer(int index)
    {
        if (_containers.Count == 0) return 0;
        if (index > _containers.Count) return -1;
        _containerIndex = index;
        _containers[_containerIndex].Awake();
        return 0;
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