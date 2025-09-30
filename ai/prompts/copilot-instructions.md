Komunikace probíhá v českém jazyce. Zdrojový kód je psán výhradně v anglickém jazyce s výjimkou komentářů, které jsou česky.

Kód, který commituješ by mělo být možné zkompilovat. Jsou-li součástí solution i unit testy, všechny existující testy by měly být průchozí.

Navržené změny musí splňovat veškerá stanoveníá kritéria. Pokud nelze z nějakého důvodu řešení dokončit, sestavit nebo otestovat, musíš to reportovat.



## Obecné

- Při review změn kódu dávej pouze návrhy, u nichž máš vysokou míru jistoty
- Čistota, udržitelnost a srozumitelnost kódu má prioritu i před výkonností
- Vždy používej nejnovější verzi jazyka C#; aktuálně funkce C# 13
- Soubor `global.json` nikdy neměň, pokud o to nejsi výslovně požádán
- V případě zakládání projektů nepoužívej nullable-reference types



## Formátování kódu

- Respektuj formátování definované v  `.editorconfig`, pokud existuje
- Upřednostňuj **file-scoped** deklarace jmenného prostoru a direktivy using **na jednom řádku**.
- Zajisti, aby **závěrečný return** v metodě byl **na samostatném řádku**.
- Používej **pattern matching** a **switch výrazy** (switch expressions), kde je to možné.
- Při odkazech na názvy členů používej **nameof** místo **řetězcových literálů**.
- Vždy používej **is null** / **is not null** místo **== null** / **!= null**.
- Upřednostňuj **null-propagation ?.** tam, kde to dává smysl (např. scope?.Dispose()).
- Vkládej **nový řádek před otevírací složenou závorku** každého bloku kódu (např. po if, for, while, foreach, using, try atd.).

## Blazor

- Při psaní code-behind vždy **vytvářej samostatné cs soubory** pro každou komponentu a nikdy nevytvářej inline programový kód pomocí @code
- Nepoužívej v komponentách proměnné, ale výhradně properties
- Kde je to možné, používej v konstruktorech dependency injection místo atributu [Inject]
- U komponent vždy implementuj pouze asynchronní verze metod, například OnInitializedAsync



## REST API & Minimal APIs

Pro návrh API endpointů používej technologii Minimal APIs. 

- Nepoužívej atributy při deklaraci endpointů metodami `MapGet`, `Map[Method]`

Pokud generuješ  endpointy na základě OAS (Open API Specification), tak:

- OperationId použij pro extension `WithName` u endpointů
- Veškerá desetinná čísla mapuj na CLR typ `decimal`
- Všechny vlastnosti na kontraktních třídách definuj jako NULLable
- Případné TAGy mapuj na Minimal API groups `app.MapGroup("tagname")`
