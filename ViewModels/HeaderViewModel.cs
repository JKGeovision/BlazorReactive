using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace BlazorReactive.ViewModels;

public partial class HeaderViewModel : ReactiveObject
{
    [Reactive]
    private string _filter = string.Empty;

    [Reactive]
    private bool _sidebarExpanded = true;
}
