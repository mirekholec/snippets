public class NotifierService
{
    public event Func<string, Task> Notify;
    public async Task Update(string message)
    {
        if (Notify != null)
        {
            await Notify.Invoke(message);
        }
    }
}

// Caller.razor
private async Task Notify()
{
    await Notifier.Update("Hello World!");
}

// Target.razor
Notifier.Notify += OnNotify;

private async Task OnNotify(string message)
{
    NotificationMessage = message;
    StateHasChanged();
}