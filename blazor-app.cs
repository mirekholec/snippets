// běžná struktura App.razor
// chybové stavy pokryté komponentami

<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(App).Assembly">
        <Found Context="routeData">
            <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
                <NotAuthorized>
                    <NotAuthorizedDetails></NotAuthorizedDetails>
                </NotAuthorized>
            </AuthorizeRouteView>
            <FocusOnNavigate RouteData="@routeData" Selector="h1"/>
        </Found>
        <NotFound>
            <PageTitle>Page not found!</PageTitle>
            <LayoutView Layout="@typeof(MainLayout)">
                <NotFoundDetails></NotFoundDetails>
            </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>

// css file
h1:focus {
    outline: none;
}