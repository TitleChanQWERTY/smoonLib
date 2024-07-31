using System.Runtime.InteropServices;
using SDL2;

namespace smoonLib.core;

public struct Color
{
    public byte R;
    public byte G;
    public byte B;

    public Color(byte red, byte green, byte blue)
    {
        R = red;
        G = green;
        B = blue;
    }
    
    // It's fucking surface! Hate hate hate! I hate this code moment! блять!
    internal static UInt32 MapRGB(IntPtr surface, Color color)
    {
        return SDL.SDL_MapRGB(Marshal.PtrToStructure<SDL.SDL_Surface>(surface).format, color.R, color.G, color.B);
    }
    
    public static readonly Color White = new Color(255, 255, 255);
    public static readonly Color Red = new Color(240, 0, 0);
}
