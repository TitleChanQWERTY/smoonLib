using System.Runtime.InteropServices;
using SDL2;

namespace smoonLib.core;

public static class Rendering
{
    private static readonly Dictionary<Texture, LowTransform> _textureCollect = new();
    
    public static void RenderingTexture(Texture texture, LowTransform lowTransform)
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

    public static void RenderCopy(Texture texture, LowTransform lowTransform)
    {
        _textureCollect[texture] = lowTransform;
    }

    internal static void RenderCollection()
    {
        foreach (var texture in _textureCollect)
        {
            RenderingTexture(texture.Key, texture.Value);
        }
        _textureCollect.Clear();
    }
}

public enum RenderFlag : uint
{
    Software = SDL.SDL_RendererFlags.SDL_RENDERER_SOFTWARE,
    Hardware = SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED
}
