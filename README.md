# Rekensommen
Een applicatie die willekeurige rekensommen genereert en de uitkomst controleert.

![media/rekensommen-design.png](media/rekensommen-design.png)

## Deel 1 - Validatie
- Maak een ***Range_TextChanged*** event-procedure aan voor 1 van de 4 tekstvelden die de range van de 2 getallen bepalen
- Zorg ervoor dat de achtergrondkleur gewijzigd wordt naar *LightCoral* wanneer de waarde:
	- kleiner is dan 0
	- groter is dan 100 
	- geen geldig getal is

```
textBox.Background = Brushes.LightCoral;
```
![media/rekensommen-range.png](media/rekensommen-range.png)

- Gebruik nu ��n en dezelfde event-procedure voor alle 4 de tekstvelden

## Deel 2 - KeyDown
- Maak ��n ***Range_KeyDown*** event-procedure aan voor de 4 tekstvelden
- Zorg ervoor dat de gebruiker enkel cijfers kan invoeren in de tekstvelden. 
	- Gebruik de *Key*-eigenschap van de *KeyEventArgs*-eventdata om te controleren of de toets een cijfer is
	- Gebruik de *e.Handled*-eigenschap om te voorkomen dat de invoer wordt verwerkt

## Deel 3 - MouseDoubleClick
- Zorg dat de *StartExercise*-methode wordt uitgevoerd wanneer de gebruiker dubbelklikt op het *equalsLabel*. Gebruik het event *MouseDoubleClick* 
- Gebruik de *ChangedButton*-eigenschap van de *MouseButtonEventArgs*-eventdata om te controleren of de linkermuisknop werd gebruikt

## Deel 4 - StartExercise
- Vervolledig de *StartExercise*-methode zodat deze een willekeurige som genereert en de uitkomst in een variabele bewaart (TODO 1 + 2)

## Deel 5 - KeyDown
- Maak een ***resultTextBox_KeyDown*** event-procedure aan voor de *resultTextBox*
- Zorg ervoor dat de CheckResult-methode wordt uitgevoerd wanneer de gebruiker op de *Enter*-toets drukt

## Deel X - DateTime
- Toon een messagebox met de huidige datum en tijd wanneer de gebruiker op de *showTimeButton* klikt
- Experimenteer met de aangepaste datum- en tijdnotatie (zie [DateTime.ToString](https://learn.microsoft.com/nl-be/dotnet/standard/base-types/custom-date-and-time-format-strings))

![media/rekensommen-showtime.png](media/rekensommen-showtime.png)

## Deel X - Bewerkingen (Operators)
![media/rekensommen-bewerkingen.png](media/rekensommen-bewerkingen.png)
- Voeg een CheckBox toe in de *Bewerkingen*-GroupBox. Gebruik de benamingen:
	- addOperatorCheckBox
	- subtractOperatorCheckBox
- Beide zijn standaard aangevinkt en hebben een marge van 5

## Deel X - GetRandomOperator
- Maak een functie aan met de naam *GetRandomOperator* die een "+" of een "-" bewerking (string) teruggeeft. 
- Gebruik de *Random*-klasse om een willekeurig getal te genereren tussen 0 en 1
	- Bij een waarde 0 wordt "+" teruggegeven
	- Bij een waarde 1 wordt "-" teruggegeven
- Hou rekening met de *addOperatorCheckBox* en *subtractOperatorCheckBox* om te bepalen welke bewerkingen mogelijk zijn
- Gebruik deze functie in de *StartExercise*-methode om de bewerking te bepalen. Tip: ook de berekening van de uitkomst moet aangepast worden

## Extra
- Toon een messagebox wanneer een nieuwe *snelste tijd* behaald wordt. Maak hiervoor een klasse variabele aan met de naam *_highScore* van het type *TimeSpan*
