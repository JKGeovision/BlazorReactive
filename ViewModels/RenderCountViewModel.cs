using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace BlazorReactive.ViewModels;

public partial class RenderCountViewModel : ReactiveObject
{
    [Reactive]
    private int _headerRenderCount = 0;

    [Reactive]
    private int _bodyRenderCount = 0;

    [Reactive]
    private int _bodyListRenderCount = 0;

    [Reactive]
    private int _bodySidebarRenderCount = 0;
}
