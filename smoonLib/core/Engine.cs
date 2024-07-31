using System.Diagnostics;
using SDL2;

namespace smoonLib.core;

public static class Engine
{
    internal static bool IsRunning = true;
    private static Stopwatch _stopwatch;
    
    public static RenderFlag DefaultRenderFlag = RenderFlag.Hardware;
    
    private static void InitEngine()
    {
        SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
        SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG | SDL_image.IMG_InitFlags.IMG_INIT_JPG);
        MemoryManager.sdlWindowMemory = SDL.SDL_CreateWindow(App.AppWindowName, SDL.SDL_WINDOWPOS_CENTERED, 
            SDL.SDL_WINDOWPOS_CENTERED, App.AppWindowSize.width, App.AppWindowSize.height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        MemoryManager.sdlRendererMemory = SDL.SDL_CreateRenderer(MemoryManager.sdlWindowMemory, -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        if (MemoryManager.sdlWindowMemory == IntPtr.Zero) DebugUtility.DebugException("Can't create Window");
        else if (MemoryManager.sdlRendererMemory == IntPtr.Zero) DebugUtility.DebugException("Can't create Renderer");
        MemoryManager.CashedTexture = Texture.CreateEmptyTexture();
        Collector.ChangeContainer(0);
        
        Time.startTime = SDL.SDL_GetTicks();
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }

    public static void RunApp()
    {
        InitEngine();
        UpdateLoop();
    }

    private static void UpdateLoop()
    {
        while (IsRunning)
        {
            // time section
            _stopwatch.Stop();
            var startLoop = SDL.SDL_GetTicks();
            Time.deltaTime = (float)_stopwatch.Elapsed.TotalSeconds;
            _stopwatch.Restart();
            
            // update section
            EventSystem.UpdateEvent();
            SDL.SDL_RenderClear(MemoryManager.sdlRendererMemory);
            Collector.UpdateState();
            Collector.UpdateContainer();
            Rendering.RenderCollection();
            SDL.SDL_RenderPresent(MemoryManager.sdlRendererMemory);
            
            // end section
            Time.frameCount++;
            Time.LimitFps(startLoop);
        }
        _stopwatch.Stop();
        MemoryManager.QuitApp();
    }
}