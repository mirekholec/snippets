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

// Invoker.razor
private async Task Notify()
{
    await Notifier.Update("Hello World!");
}

// Notificator.razor
Notifier.Notify += OnNotify;

    private Task OnNotify(string message)
    {
        Message = message;
        StateHasChanged();

        // po pěti sekundách vymazat message
        Task.Delay(5000).ContinueWith(_ => {
            Message = string.Empty;
            StateHasChanged();
        });

        return Task.CompletedTask;
    }