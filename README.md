# AssignmentEWay

## :triangular_flag_on_post: Vypracovanie zadania
Na základe zaslaného zadania, som vypracoval tento jednoduchý projekt.

## 📝 Popis projektu
Tento projekt je WPF aplikácia vytvorená v **.NET 8**, ktorá umožňuje vyhľadávať kontakty podľa emailovej adresy prostredníctvom **eWay-CRM API**. Aplikácia zároveň uchováva históriu vyhľadávaných kontaktov a umožňuje ich opätovné zobrazenie s aktuálnymi dátami.

## 🚀 Funkcionalita
- Vyhľadanie kontaktu podľa emailovej adresy
- Zobrazenie detailov kontaktu (vizitka)
- Uchovanie histórie vyhľadávania do JSON súboru
- Možnosť kliknúť na uložený kontakt v histórii a opätovne ho načítať

## 📂 Štruktúra riešenia
Riešenie **AssignmentEWay** je rozdelené do viacerých projektov:

- **AssignmentEWay.Data** - Modely a služby pre ukladanie histórie vyhľadávaných kontaktov do JSON súboru
- **AssignmentEWay.Domain** – Implementácia služby pre komunikáciu s eWay-CRM API
- **AssignmentEWay.Shared** – Zdieľané komponenty a pomocné triedy
- **AssignmentEWay.WPF** – Frontend aplikácie s hlavnými view modelmi a UI

## 📸 Ukážka používateľského rozhrania
1. **Hlavné okno** – Zadajte emailovú adresu a presmeruje Vás to do detail okna.
2. **Detail kontaktu** – Po kliknutí na kontakt v hlavnom okne sa zobrazia podrobnosti

## 🔧 Požiadavky
Na správne spustenie aplikácie je potrebné:
- **.NET 8 SDK**
- **Visual Studio 2022** (alebo iný kompatibilný IDE s WPF podporou)
- Internetové pripojenie pre komunikáciu s **eWay-CRM API**

## 📥 Inštalácia a spustenie
1. **Naklonujte repozitár:**
   ```sh
   git clone https://github.com/tvoj-username/AssignmentEWay.git
   ```
2. **Otvorte riešenie v Visual Studio**
3. **Nainštalujte závislosti cez NuGet** (automaticky pri buildnutí projektu)
4. **Buildnite a spustite aplikáciu**

## 📚 Použité technológie
- **.NET 8**
- **WPF (Windows Presentation Foundation)**
- **MVVM architektúra**
- **Newtonsoft.Json** (pre prácu so súbormi)
- **eWay-CRM API**





