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

- Gebruik nu één en dezelfde event-procedure voor alle 4 de tekstvelden

## Deel 2 - KeyDown
- Maak één ***Range_KeyDown*** event-procedure aan voor de 4 tekstvelden
- Zorg ervoor dat de gebruiker enkel cijfers kan invoeren in de tekstvelden. 
	- Gebruik de *Key*-eigenschap van de *KeyEventArgs*-eventdata om te controleren of de toets een cijfer is
	- Gebruik de *e.Handled*-eigenschap om te voorkomen dat de invoer wordt verwerkt

## Deel 3 - MouseDoubleClick
- Zorg dat de *StartExercise*-methode wordt uitgevoerd wanneer de gebruiker dubbelklikt op het *equalsLabel*. Gebruik het event *MouseDoubleClick* 
- Gebruik de *ChangedButton*-eigenschap van de *MouseButtonEventArgs*-eventdata om te controleren of de linkermuisknop werd gebruikt

## Deel 4 - StartExercise


## Deel X - DateTime
- Toon een messagebox met de huidige datum en tijd wanneer de gebruiker op de *showTimeButton* klikt
- Experimenteer met de aangepaste datum- en tijdnotatie (zie [DateTime.ToString](https://learn.microsoft.com/nl-be/dotnet/standard/base-types/custom-date-and-time-format-strings))

![media/rekensommen-showtime.png](media/rekensommen-showtime.png)




## Extra
- Toon een messagebox wanneer een nieuwe *snelste tijd* behaald wordt. Maak hiervoor een klasse variabele aan met de naam *_highScore* van het type *TimeSpan*
