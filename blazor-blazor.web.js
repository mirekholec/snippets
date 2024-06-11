<script src="_framework/blazor.web.js" autostart="false"></script>
<script>
    Blazor.start({
        ssr: {
            disableDomPreservation: true // disable enhanced navigation
        },
        circuit: {
            reconnectionOptions: {
                maxRetries: 3,
                retryIntervalMilliseconds: 2000
            },
            reconnectionHandler: {
                onConnectionDown: (options, error) => {
                    Blazor.defaultReconnectionHandler.onConnectionDown(options, error);
                    Blazor.defaultReconnectionHandler._reconnectionDisplay.rejected = function () {
                        window.location.reload();
                    }
                }
            }
        },
        webAssembly: {
            applicationCulture: 'cs-CZ'
        }

    });

    window.addEventListener('pagehide', () => {
        Blazor.disconnect();
    });
    
</script>