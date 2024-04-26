using Microsoft.Maui.Handlers;

namespace Rive.Maui;

public partial class RivePlayerHandler() : ViewHandler<RivePlayer, CustomRiveView>(PropertyMapper, CommandMapper)
{
    protected override CustomRiveView CreatePlatformView()
    {
        var platformView = new CustomRiveView();

        platformView.ArtboardName = VirtualView.ArtboardName;
        platformView.AnimationName = VirtualView.AnimationName;
        platformView.StateMachineName = VirtualView.StateMachineName;
        platformView.AutoPlay = VirtualView.AutoPlay;
        platformView.Fit = VirtualView.Fit.AsRive();
        platformView.Alignment = VirtualView.Alignment.AsRive();
        platformView.Loop = VirtualView.Loop.AsRive();
        platformView.Direction = VirtualView.Direction.AsRive();

        platformView.SetRiveResource(VirtualView.ResourceName);
        platformView.Control.SetTarget(VirtualView);
        platformView.Frame = VirtualView.Bounds;

        return platformView;
    }

    protected override void DisconnectHandler(CustomRiveView platformView)
    {
        platformView.Dispose();

        base.DisconnectHandler(platformView);
    }

    private static void MapAnimationProperties(RivePlayerHandler handler, RivePlayer view)
    {
        if (!string.IsNullOrWhiteSpace(view.AnimationName))
        {
            handler.PlatformView.Loop = view.Loop.AsRive();
            handler.PlatformView.Direction = view.Direction.AsRive();
            handler.PlatformView.PlayAnimation(view.AnimationName);
        }
    }

    public static void MapArtboardName(RivePlayerHandler handler, RivePlayer view)
    {
        if (!string.Equals(handler.PlatformView.ArtboardName, view.ArtboardName, StringComparison.OrdinalIgnoreCase))
        {
            handler.PlatformView.ArtboardName = view.ArtboardName;
            handler.PlatformView.ResetProperties(false);
            handler.PlatformView.UpdateAnimation();
        }
    }

    private static void MapStateMachineName(RivePlayerHandler handler, RivePlayer view)
    {
        if (!string.Equals(handler.PlatformView.StateMachineName, view.StateMachineName, StringComparison.OrdinalIgnoreCase))
        {
            handler.PlatformView.StateMachineName = view.StateMachineName;
            handler.PlatformView.ResetProperties(false);
            handler.PlatformView.UpdateAnimation();
        }
    }

    private static void MapResourceName(RivePlayerHandler handler, RivePlayer view)
        => handler.PlatformView.SetRiveResource(view.ResourceName);

    private static void MapAutoPlay(RivePlayerHandler handler, RivePlayer view)
        => handler.PlatformView.AutoPlay = view.AutoPlay;

    private static void MapFit(RivePlayerHandler handler, RivePlayer view)
        => handler.PlatformView.Fit = view.Fit.AsRive();

    private static void MapAlignment(RivePlayerHandler handler, RivePlayer view)
        => handler.PlatformView.Alignment = view.Alignment.AsRive();

    private static void MapStateChangedCommand(RivePlayerHandler handler, RivePlayer view)
    {
    }

    private static void MapPlay(RivePlayerHandler handler, RivePlayer view, object? args)
        => handler.PlatformView.Play();

    private static void MapPause(RivePlayerHandler handler, RivePlayer view, object? args)
        => handler.PlatformView.Pause();

    private static void MapStop(RivePlayerHandler handler, RivePlayer view, object? args)
        => handler.PlatformView.Stop();

    private static void MapReset(RivePlayerHandler handler, RivePlayer view, object? args)
        => handler.PlatformView.Reset();

    public static void MapSetInput(RivePlayerHandler handler, RivePlayer view, object? args)
    {
        if (args is not StateMachineInputArgs inputArgs)
            return;

        switch (inputArgs.Value)
        {
            case double doubleValue:
                handler.PlatformView.SetInput(inputArgs.StateMachineName, inputArgs.InputName, (float)doubleValue);
                break;
            case float floatValue:
                handler.PlatformView.SetInput(inputArgs.StateMachineName, inputArgs.InputName, floatValue);
                break;
            case bool boolValue:
                handler.PlatformView.SetInput(inputArgs.StateMachineName, inputArgs.InputName, boolValue);
                break;
        }
    }

    public static void MapTriggerInput(RivePlayerHandler handler, RivePlayer view, object? args)
    {
        if (args is StateMachineTriggerInputArgs triggerInputArgs)
        {
            handler.PlatformView.TriggerInput(triggerInputArgs.StateMachineName, triggerInputArgs.InputName);
        }
    }
}