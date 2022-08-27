// MainLayout.razor (obvykle)

<ErrorBoundary>
    <ChildContent>
        @Body
    </ChildContent>
    <ErrorContent>
        <p>Error content nebo komponenta</p>
    </ErrorContent>
</ErrorBoundary>