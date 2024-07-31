using SDL2;

namespace smoonLib.core;

public struct Texture
{
    internal readonly IntPtr textureData = IntPtr.Zero;

    public Texture(Color color)
    {
        textureData = MemoryManager.CashedTexture;
        ChangeTextureColor(this, color);
    }
    
    public Texture()
    {
        textureData = MemoryManager.CashedTexture;
    }
    
    public Texture(string texturePath)
    {
        textureData = CreateTextureFromImage(texturePath);
    }

    public static void DestroyTextureFromMemory(Texture textureToDestroy)
    {
        DestroyTextureFromMemory(textureToDestroy.textureData);
    }

    public static void ChangeTextureColor(Texture texture, Color color)
    {
        SDL.SDL_SetTextureColorMod(texture.textureData, color.R, color.G, color.B);
    }
    
    internal static void DestroyTextureFromMemory(IntPtr textureToDestroy)
    {
        SDL.SDL_DestroyTexture(textureToDestroy);
    }

    internal static IntPtr CreateEmptyTexture()
    {
        IntPtr surface = SDL.SDL_CreateRGBSurface(0, 1, 1, 32, 0, 0, 0, 0);
        var color = Color.MapRGB(surface, Color.White);
        SDL.SDL_FillRect(surface, IntPtr.Zero, color);
        var texture = SDL.SDL_CreateTextureFromSurface(MemoryManager.sdlRendererMemory, surface);
        return texture;
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