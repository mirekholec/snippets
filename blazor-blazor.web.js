<script src="_framework/blazor.web.js" autostart="false"></script>
<script>
    Blazor.start({
        ssr: {
            disableDomPreservation: true // disable enhanced navigation
        },
        circuit: {
            reconnectionOptions: {
                maxRetries: 6,
                retryIntervalMilliseconds: (previousAttempts, maxRetries) =>
                        previousAttempts >= maxRetries
                            ? null
                            : previousAttempts * 1000
                },
            },
        webAssembly: {
            applicationCulture: 'cs-CZ'
        }

    });

    // events: enhancedload, enhancednavigationstart, enhancednavigationend
    Blazor.addEventListener('enhancedload', () => {
    });

    // blazor.addEventListener("enhancednavigationstart", {CALLBACK});
    // blazor.addEventListener("enhancednavigationend", {CALLBACK});
    // blazor.addEventListener("enhancedload", {CALLBACK});
    
</script>