Převeď požadovanou C# třídu do podoby JSON. Jako notaci použij výhradně camelCase. Hodnoty uveď náhodně dle níže definovaných pravidel:

- int hodnoty jsou kladná čísla od 0 do 10000
- decimal jsou hodnoty s maximálně 4 desetinnými čísly
- decimal u vlastností, které odkazují na cenu mají dvě desetinná čísla
- u názvů a jmen používej české názvy, jména, příjmení, atd.
- je-li vlastnost DateTime se suffixem On, bude se jednat pouze o datum bez času
- u ostatních DateTime vždy použij datum + čas
- datum uváděj jako ISO 8861 v UTC
- bool má výchozí hodnotu 0

Je-li u properties defnováno nějaké pravidlo pomocí atributů, např.: [Range], pak generuj takové hodnoty, aby vzniklá struktura byla validní.

Pořadí properties zachovej dle C# třídy s tím, že jako první uveď vlastnosti, které reprezentují identifikátor. 

U vlastností, které jsou kolekcí (array, list, atd.) uváděj pouze prázdné pole.

Pokud je vlastnost enum (zřejmě vše se suffixem type, state odkazující na jinou třídu), použij řetězec s relevantním názvem stavu nebo typu. 

Výsledek vrátíš jako canvas pro další kolaboraci.
