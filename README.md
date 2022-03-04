# ApplicationParameter_copy

Hej!

Tack för att ni tar er tid att titta på min kod!

Jag har förberett lite frågeställning kring några funderingar jag har.

1. Som koden är skriven anropas databasen i en foreach loop när de dynamiska gridviews skapas i FillDataDynamically(), jag har funderat på om man kan läsa in all data en gång      och istället filtrera med hjälp av Dataview men stötte på lite problem med att allokera rätt data till rätt gridview. Kan hända att när man inför en klass som DTO underlättar 
   detta.

2. Tre olika formulär finns och är beroende av vilken typ av parameter som öppnas (bool, int eller lista), eftersom jag inte har en klass att skicka in blir det mycket kod 
   som upprepas i CellDoubleClick(),  undviker man detta genom att läsa in data som en klass istället? Har också märkt att parametrar som bara tar in ett strängvärde som
   inte är true/false öppnas i formuläret för listor, detta måste jag hitta en lösning på då dessa parametrar inte är skapade för att ta in semikoliseparerade listor.
   
3. Samma komponenter används i flera formulär, hade man kunnat skapa en komponent och bara återanvänt?


En refreshfunktion är tillagd mest för att kunna verifiera att parametrarna ändras med önskat utfall, lösningen är inte speciellt snygg men fungerar (finns ju en befintlig funktion i Prodex)

Databasfilen finns uppladdad i projektet som dbcopy.sql.

Vad gällande UI så är det ett förslag, här finns utrymme för förbättringar men som ni alla känner till, design är svårt :)

Jag önskar input på hur koden är skriven, alternativa lösningar, strukturen etc etc. Vill försöka fånga upp så mycket som möjligt innan koden lyfts över till Prodex!

Ha en fin vecka
Micke 





   
