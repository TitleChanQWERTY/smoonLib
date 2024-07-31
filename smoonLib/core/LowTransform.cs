using SDL2;

namespace smoonLib.core;

public struct LowTransform
{
    public Vector2 position;
    public SizeFloat size;
    public SizeFloat scale;

    public LowTransform(Vector2 position, SizeFloat size, SizeFloat? scale = null)
    {
        this.position = position;
        this.size = size;
        this.scale = scale ?? new SizeFloat(0, 0);
    }
}