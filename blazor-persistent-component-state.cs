public partial class Calc : ComponentBase, IDisposable
{
    private List<AssistantDto> _assistants;
    private PersistingComponentStateSubscription _persistingSubscription;
    [Inject] private PersistentComponentState PersistentComponentState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _persistingSubscription = PersistentComponentState.RegisterOnPersisting(Persist);
        if (PersistentComponentState.TryTakeFromJson<List<AssistantDto>>("Assistants", out var assistants))
        {
            _assistants = assistants;
        }
        else
        {
            _assistants = await AssistantsService.GetAssistants();
        }
    }

    private Task Persist()
    {
        PersistentComponentState.PersistAsJson("Assistants", _assistants);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _persistingSubscription.Dispose();
    }
}