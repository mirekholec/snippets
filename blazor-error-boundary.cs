// MainLayout.razor (obvykle)

<ErrorBoundary @ref="_errorBoundary">
    <ChildContent>
        @Body
    </ChildContent>
    <ErrorContent Context="exception">
        <p>Error content nebo komponenta</p>
        <code>@exception.ToString()</code>
        <p @onclick="() => _errorBoundary.Recover()">Zotavit</p>
    </ErrorContent>
</ErrorBoundary>

@code {
    private ErrorBoundary _errorBoundary;
}