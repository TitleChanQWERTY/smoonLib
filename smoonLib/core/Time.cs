using SDL2;

namespace smoonLib.core;

public static class Time
{
    private static int _fpsMax = 60;
    private static int _sdlDesiredDelta = 1000 / _fpsMax;
    
    public static int FpsMax
    {
        get => _fpsMax;
        set
        {
            _sdlDesiredDelta = 1000 / value;
            _fpsMax = value;
            fixedDeltaTime = 1f / value;
        }
    }

    internal static uint startTime;
        
    public static float CurrentFps
    {
        get;
        private set;
    }

    internal static uint frameCount;
    
    public static float deltaTime;
    
    public static float fixedDeltaTime = 1f / _fpsMax;

    internal static void LimitFps(uint startLoopTime)
    {
        var currentTime = SDL.SDL_GetTicks();
        
        int delta = (int)(currentTime - startLoopTime);
        
        if (delta < _sdlDesiredDelta) SDL.SDL_Delay((uint)(_sdlDesiredDelta - delta));
        
        currentTime = SDL.SDL_GetTicks();
        
        if (currentTime - startTime >= 1000)
        {
            CurrentFps = frameCount / ((currentTime - startTime) / 1000.0f);
            frameCount = 0;
            startTime = currentTime;
        }
    }
}
