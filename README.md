# ApplicationParameter_copy

Hej!

Tack för att ni tar er tid att titta på min kod!

Jag har förberett en liten frågeställning där jag själv är intresserad av hur man hade kunnat lösa problemen.

1. Som det är nu anropas databasen i en foreach loop när de dynamiska gridviews skapas i FillDataDynamically(), jag har funderat på om man kan läsa in all data en gång och 
   istället filtrera med hjälp av Dataview men stötte på lite problem med att allokera rätt data till rätt gridview.

2. Tre olika formulär finns och är beroende av vilken typ av parameter som öppnas (bool, int eller lista), eftersom jag inte har en klass att skicka in blir det mycket kod 
   som upprepas i CellDoubleClick(),  undviker man detta genom att läsa in data som en klass istället? Har också märkt att vissa parametrar som bara tar in ett strängvärde som
   inte är true/false öppnas i formuläret för lista, detta måste jag hitta en lösning på då vissa parametrar inte är skapade för att ta in semikoliseparerade listor.
   
3. Samma komponenter används i flera formulär, hade man kunnat skapa en komponent och bara återanvänt?


En refreshfunktion är tillagd mest för att kunna verifiera att parametrarna ändras med önskat utfall, lösningen är inte speciellt snygg men fungerar (finns ju en befintlig i Prodex)

Vad gällande UI så är det ett exempel, här finns det utrymme för förbättringar men som ni alla känner till, design är svårt :)

Jag önskar input på hur koden är skriven, alternativa lösningar, strukturen etc etc. Vill försöka fånga upp så mycket som möjligt innan koden lyfts över till Prodex!

Ha en fin vecka
Micke 





   
