// běžná struktura Routes.razor
// chybové stavy pokryté komponentami

<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
            <NotAuthorized>
                <NotAuthorizedDetails></NotAuthorizedDetails>
            </NotAuthorized>
        </AuthorizeRouteView>
        <FocusOnNavigate RouteData="@routeData" Selector="html"/>
    </Found>
    <NotFound>
        <PageTitle>Page not found!</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <NotFoundDetails></NotFoundDetails>
        </LayoutView>
    </NotFound>
</Router>