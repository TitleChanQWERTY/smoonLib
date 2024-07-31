using SDL2;

namespace smoonLib.core;

public static class Rendering
{
    public static void RenderCopy(Texture texture, LowTransform lowTransform)
    {
        SDL.SDL_FRect fRect = new()
        {
            x = lowTransform.position.x,
            y = lowTransform.position.y,
            w = lowTransform.size.width,
            h = lowTransform.size.height
        };
        SDL.SDL_RenderCopyF(MemoryManager.sdlRendererMemory, texture.textureData, IntPtr.Zero, ref fRect);
    }
}