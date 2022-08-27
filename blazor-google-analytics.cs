// Index.cshtml / _Host.cshtml

<script>
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
ga('create', 'UA-6469042-200', 'auto');
// ga('send', 'pageview');

window.googleAnalytics = {
    trackPageView: function () {
        ga('send', 'pageview', {});
    }
}

window.showAlert = (text) => {
    return "Text: " + text;
}

</script>



// App.razor
protected override void OnAfterRender(bool firstRender)
{
    if (firstRender)
    {
        NavigationManager.LocationChanged += async (sender, args) =>
        {
            await JsRuntime.InvokeVoidAsync("googleAnalytics.trackPageView");
            string result = await JsRuntime.InvokeAsync<string>("showAlert", "ahoj");
        };
    }

    base.OnAfterRender(firstRender);
}