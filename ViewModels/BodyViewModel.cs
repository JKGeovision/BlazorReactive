using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System.Collections.ObjectModel;

namespace BlazorReactive.ViewModels;

public partial class BodyViewModel : ReactiveObject, IDisposable
{
    [Reactive]
    private ObservableCollection<string> _items = [];

    [Reactive]
    private ReadOnlyObservableCollection<string> _filteredItems = new([]);

    [Reactive]
    private bool _sidebarExpanded = true;

    private IDisposable _filterSubscription;

    private IDisposable _sidebarExpandedSubscription;

    public BodyViewModel(HeaderViewModel headerViewModel)
    {
        this
            .WhenAnyValue(x => x.Items)
            .Subscribe(items =>
            {
                FilteredItems = new(new(items.Where(item => item.Contains(headerViewModel.Filter))));
            });

        _filterSubscription = headerViewModel
            .WhenAnyValue(x => x.Filter)
            .Subscribe(filter =>
            {
                FilteredItems = new(new(Items.Where(item => item.Contains(filter))));
            });

        _sidebarExpandedSubscription = headerViewModel
            .WhenAnyValue(x => x.SidebarExpanded)
            .Subscribe(expanded =>
            {
                SidebarExpanded = expanded;
            });

        Items = new(Enumerable.Range(1, 100).Select(index => $"item {index}"));
    }

    public void Dispose()
    {
        _filterSubscription.Dispose();
        _sidebarExpandedSubscription.Dispose();
    }
}
