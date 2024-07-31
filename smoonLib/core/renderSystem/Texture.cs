using SDL2;

namespace smoonLib.core;

public struct Texture
{
    internal readonly IntPtr textureData = IntPtr.Zero;

    public Texture(string texturePath)
    {
        textureData = CreateTextureFromImage(texturePath);
    }

    public static void DestroyTextureFromMemory(Texture textureToDestroy)
    {
        DestroyTextureFromMemory(textureToDestroy.textureData);
    }
    
    internal static void DestroyTextureFromMemory(IntPtr textureToDestroy)
    {
        SDL.SDL_DestroyTexture(textureToDestroy);
    }

    private IntPtr CreateTextureFromImage(string imagePath)
    {
        IntPtr texture;
        if (!MemoryManager.textureCollect.TryGetValue(imagePath, out IntPtr ptrTexture))
        {
            texture = SDL_image.IMG_LoadTexture(MemoryManager.sdlRendererMemory, imagePath);
            MemoryManager.textureCollect[imagePath] = texture;
            return texture;
        }
        foreach (var texturePtr in MemoryManager.textureCollect)
            if (texturePtr.Key == imagePath) return texturePtr.Value;
        return IntPtr.Zero;
    }
}