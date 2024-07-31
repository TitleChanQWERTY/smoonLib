using SDL2;

namespace smoonLib.core;

public struct LowTransform
{
    public Vector2 position;
    public SizeFloat size;
    public SizeFloat scale = new SizeFloat(0, 0);

    public LowTransform(Vector2 position, SizeFloat size)
    {
        this.position = position;
        this.size = size;
    }
}