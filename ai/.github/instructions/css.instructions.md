---
applyTo: "**/*.css"
---
# Standardy pro CSS

Cílem je udržet CSS jednotné, čitelné a snadno udržovatelné. 

### Bloky a odsazení

- Každý selektor nebo skupina selektorů má otevírací složenou závorku na stejném řádku a zavírá se  také na stejném řádku.
- Za každou deklarací včetně té poslední se vždy uvádí středník
- Po dvojtečce následuje vždy mezera
- Barvy se uvádí jako kompletní hexadecimální kód (#FFFFFF místo #FFF)
- Po čárce za selektorem následuje jedna mezera `html, body`

### Řazení selektorů

- na začátku souboru je CSS reset
- dále následují obecná nastavení (h1-h6, p, img, a)
- poté se definuje hlavní layout (header, main, footer)
- následují sekce se specifickými nastaveními, například:
  - header, header nav, header nav h1
  - main, main article, main section .xx
  - footer, footer nav, footer nav li
  - media queries

### Řazení deklarací v bloku

Uvntř bloku řaď vlastnosti tímto pořadím:

1. box model (display, position, top, ... box-sizing, overflow, z-index)
2. odsazení (margin, padding)
3. typografie (font, color)
4. vzhled (border, background, border-radius, box-shadow, opacity)
5. efekty a animace
6. ostatní deklarace

### Hodnoty

- barvy primárně definuj hexadecimálně šestimístně
- u nul neuváděj jednotku, například `margin: 0`;
- u čísel uváděj vedoucí nulu, například `0.9` místo `.9`
- u názvů fontů vždy uveď název do uvozovek, např.: `font-family: "Arial"`

### Ostatní

- media queries udržuj na konci CSS souboru a používej minimálně nutné breakpointy a jasná pravidla 
- preferuj shorthand zápisy, například `margin: 0` nebo `margin: 0 10px`
- větší sekce CSS od sebe odděl komentářem

```
/* Typography */
/* Layout */
/* Components: Header, Footer, Gallery */
/* Utilities */
/* Media Queries */
```
