# Testkonzept

## Zug Klasse

### **1. Constructor_SetsPropertiesCorrectly** 

**Was wird getestet?**  
- Es wird getestet, ob die Eigenschaften `Spieler`, `Row` und `Col` korrekt gesetzt werden, wenn ein `Zug`-Objekt erstellt wird.  

**Wie wird getestet?**  
- Eine Instanz von `Spieler` wird erstellt.  
- Ein `Zug`-Objekt wird mit diesem Spieler und den Werten für `Row` und `Col` initialisiert.  
- Es wird überprüft, ob die Eigenschaften des `Zug`-Objekts mit den übergebenen Werten übereinstimmen.  

**Warum wird getestet?**  
- Test stellt sicher, dass ein `Zug`-Objekt korrekt initialisiert wird und die übergebenen Werte korrekt gespeichert werden.  

### **2. Constructor_SetsZeitstempelToCurrentTime**  

**Was wird getestet?**  
- Es wird getestet, ob das `Zug`-Objekt beim Erstellen einen Zeitstempel setzt, der in den aktuellen Zeitrahmen fällt.  

**Wie wird getestet?**  
- Der aktuelle Zeitpunkt wird vor der Erstellung des `Zug`-Objekts gespeichert.  
- Ein `Zug`-Objekt wird erstellt.  
- Der aktuelle Zeitpunkt wird erneut gespeichert.  
- Es wird geprüft, ob der Zeitstempel des `Zug`-Objekts zwischen den beiden gespeicherten Zeitpunkten liegt.  

**Warum wird getestet?**  
- Dieser Test stellt sicher, dass das `Zug`-Objekt den Zeitstempel korrekt setzt, um den Zeitpunkt des Zuges festzuhalten.  

### **3. Constructor_AllowsZeroBasedIndices**  

**Was wird getestet?**  
- Es wird getestet, ob ein `Zug`-Objekt mit `Row` und `Col` als `0` erstellt werden kann.  

**Wie wird getestet?**  
- Eine Instanz von `Spieler` wird erstellt.  
- Ein `Zug`-Objekt wird mit `Row = 0` und `Col = 0` erstellt.  
- Es wird überprüft, ob die gespeicherten Werte im `Zug`-Objekt korrekt sind.  

**Warum wird getestet?**  
- Dieser Test stellt sicher, dass das `Zug`-Objekt nullbasierte Indizes unterstützt, die in vielen Spiellogiken verwendet werden.  

### **4. Constructor_AllowsNegativeIndices** 

**Was wird getestet?**  
- Es wird getestet, ob ein `Zug`-Objekt mit negativen Werten für `Row` und `Col` erstellt werden kann.  

**Wie wird getestet?**  
- Eine Instanz von `Spieler` wird erstellt.  
- Ein `Zug`-Objekt wird mit `Row = -1` und `Col = -2` erstellt.  
- Es wird überprüft, ob die gespeicherten Werte im `Zug`-Objekt korrekt sind.  

**Warum wird getestet?**  
- Dieser Test stellt sicher, dass das `Zug`-Objekt negative Werte akzeptiert, falls diese später in bestimmten Spielszenarien relevant sein sollten.  

### **5. Constructor_SetsPlayerSymbolCorrectly**  

**Was wird getestet?**  
- Es wird getestet, ob das Symbol des Spielers (`Symbol`) korrekt im `Zug`-Objekt gespeichert wird.  

**Wie wird getestet?**  
- Eine Instanz von `Spieler` mit einem bestimmten Symbol (`'O'`) wird erstellt.  
- Ein `Zug`-Objekt wird mit diesem Spieler erstellt.  
- Es wird überprüft, ob das `Symbol`-Attribut des Spielers im `Zug`-Objekt korrekt gesetzt ist.  

**Warum wird getestet?**  
- Dieser Test stellt sicher, dass das `Zug`-Objekt das Symbol des Spielers korrekt speichert, um eine eindeutige Zuordnung der Züge zu ermöglichen.  
---

## GameBoardModel Klasse


### **1. GetCellTest**  

**Was wird getestet?**  
- Es wird überprüft, ob eine Zelle auf dem Spielfeld korrekt ausgelesen wird.  

**Wie wird getestet?**  
- Ein `GameBoardModel`-Objekt mit einer Größe von 3x3 wird erstellt.  
- Der Wert einer bestimmten Zelle wird abgefragt.  
- Es wird geprüft, ob die Zelle den erwarteten Standardwert `'.'` enthält.  

**Warum wird getestet?**  
- Stellt sicher, dass das Spielfeld korrekt initialisiert wird und der Standardwert für leere Zellen richtig zurückgegeben wird.  


### **2. SetCellTest**  

**Was wird getestet?**  
- Es wird überprüft, ob eine Zelle auf dem Spielfeld korrekt gesetzt wird.  

**Wie wird getestet?**  
- Ein `GameBoardModel`-Objekt wird erstellt.  
- Eine bestimmte Zelle wird auf `'X'` gesetzt.  
- Anschließend wird geprüft, ob die Zelle den gesetzten Wert enthält.  

**Warum wird getestet?**  
- Stellt sicher, dass das Setzen eines Werts in einer Zelle korrekt funktioniert.  


### **3. ValidateMoveTest_ValidMove**  

**Was wird getestet?**  
- Es wird geprüft, ob ein gültiger Zug als solcher erkannt wird.  

**Wie wird getestet?**  
- Ein leeres `GameBoardModel` wird erstellt.  
- Es wird überprüft, ob ein Zug auf eine freie Zelle als gültig erkannt wird.  

**Warum wird getestet?**  
- Sicherstellung, dass Spieler nur erlaubte Züge machen können.  


### **4. ValidateMoveTest_InvalidMove**  

**Was wird getestet?**  
- Es wird geprüft, ob ein ungültiger Zug korrekt erkannt wird.  

**Wie wird getestet?**  
- Eine Zelle wird mit `'X'` belegt.  
- Es wird überprüft, ob das erneute Setzen an der gleichen Position als ungültig erkannt wird.  

**Warum wird getestet?**  
- Stellt sicher, dass ein Spieler keine bereits belegte Zelle überschreiben kann.  


### **5. PruefeGewinnerTest_WinningRow**  

**Was wird getestet?**  
- Es wird überprüft, ob eine Gewinnbedingung korrekt erkannt wird.  

**Wie wird getestet?**  
- Eine komplette Zeile wird mit `'X'` gefüllt.  
- Die Methode zur Gewinnerprüfung wird aufgerufen.  
- Es wird geprüft, ob der Gewinn korrekt erkannt wird.  

**Warum wird getestet?**  
- Stellt sicher, dass das Spiel korrekt erkennt, wenn ein Spieler gewinnt.  


### **6. PruefeGewinnerTest_NoWin**  

**Was wird getestet?**  
- Es wird geprüft, ob das Spiel korrekt erkennt, dass kein Spieler gewonnen hat.  

**Wie wird getestet?**  
- Eine zufällige Verteilung von Symbolen wird gesetzt.  
- Die Methode zur Gewinnerprüfung wird aufgerufen.  
- Es wird überprüft, dass kein Gewinner erkannt wird.  

**Warum wird getestet?**  
- Stellt sicher, dass die Gewinnprüfung nicht fälschlicherweise einen Gewinner meldet.  


### **7. ValidateInputTest_ValidInput**  

**Was wird getestet?**  
- Es wird geprüft, ob eine gültige Eingabe korrekt in Zeilen- und Spaltenwerte umgewandelt wird.  

**Wie wird getestet?**  
- Eine Eingabe wie `"b2"` wird getestet.  
- Die Methode gibt Zeile und Spalte zurück.  
- Es wird geprüft, ob die Werte korrekt interpretiert wurden (`(1,1)`).  

**Warum wird getestet?**  
- Stellt sicher, dass Benutzereingaben korrekt interpretiert werden.  


### **8. ValidateInputTest_InvalidInput**  

**Was wird getestet?**  
- Es wird geprüft, ob eine ungültige Eingabe korrekt erkannt wird.  

**Wie wird getestet?**  
- Eine ungültige Eingabe wie `"z9"` wird getestet.  
- Es wird überprüft, ob die Methode dies als ungültig erkennt.  

**Warum wird getestet?**  
- Stellt sicher, dass fehlerhafte Benutzereingaben korrekt abgefangen werden.  

---

## Game ControllerKlasse


### **1. InitialiseSpiel_SelectThreeByThreeBoard_ShouldSetupCorrectly**  

**Was wird getestet?**  
- Überprüfung, ob der `GameController` korrekt initialisiert wird, wenn der Benutzer ein 3x3-Spielfeld auswählt.  

**Wie wird getestet?**  
- Es wird ein `StringReader` mit der Eingabe `"3\n"` erstellt und an `Console.SetIn` gebunden.  
- Ein `GameController` wird initialisiert.  
- Es wird geprüft, ob der `GameController` erfolgreich instanziiert wurde.  

**Warum wird getestet?**  
- Stellt sicher, dass das Spielfeld korrekt initialisiert wird, wenn der Benutzer die Größe `3x3` auswählt.  


### **2. InitialiseSpiel_SelectFiveByFiveBoard_ShouldSetupCorrectly**  

**Was wird getestet?**  
- Überprüfung, ob der `GameController` korrekt initialisiert wird, wenn der Benutzer ein 5x5-Spielfeld auswählt.  

**Wie wird getestet?**  
- Es wird ein `StringReader` mit der Eingabe `"5\n"` erstellt und an `Console.SetIn` gebunden.  
- Ein `GameController` wird initialisiert.  
- Es wird geprüft, ob der `GameController` erfolgreich instanziiert wurde.  

**Warum wird getestet?**  
- Stellt sicher, dass das Spielfeld korrekt initialisiert wird, wenn der Benutzer die Größe `5x5` auswählt.  


### **3. InitialiseSpiel_SelectSevenBySevenBoard_ShouldSetupCorrectly**  

**Was wird getestet?**  
- Überprüfung, ob der `GameController` korrekt initialisiert wird, wenn der Benutzer ein 7x7-Spielfeld auswählt.  

**Wie wird getestet?**  
- Es wird ein `StringReader` mit der Eingabe `"7\n"` erstellt und an `Console.SetIn` gebunden.  
- Ein `GameController` wird initialisiert.  
- Es wird geprüft, ob der `GameController` erfolgreich instanziiert wurde.  

**Warum wird getestet?**  
- Stellt sicher, dass das Spielfeld korrekt initialisiert wird, wenn der Benutzer die Größe `7x7` auswählt.  


### **4. IstUnentschieden_EmptyBoard_ShouldReturnFalse**  

**Was wird getestet?**  
- Überprüfung, ob die Methode `IstUnentschieden` korrekt `false` zurückgibt, wenn das Spielfeld leer ist.  

**Wie wird getestet?**  
- Ein `GameController` mit einer 3x3-Spielfeldgröße wird initialisiert.  
- Die private Methode `IstUnentschieden` wird mittels Reflection aufgerufen.  
- Es wird überprüft, ob das Ergebnis `false` ist, da ein leeres Spielfeld kein Unentschieden darstellt.  

**Warum wird getestet?**  
- Sicherstellen, dass das Spiel korrekt erkennt, dass ein leeres Spielfeld nicht zu einem Unentschieden führt.  


### **5. InitialiseSpiel_InvalidBoardSize_ShouldRepromptUntilValidInput**  

**Was wird getestet?**  
- Überprüfung, ob der `GameController` den Benutzer bei ungültigen Eingaben dazu auffordert, eine gültige Spielfeldgröße auszuwählen.  

**Wie wird getestet?**  
- Ein `StringReader` mit einer Reihe von ungültigen Eingaben (`"4\n0\n6\n3\n"`) wird erstellt und an `Console.SetIn` gebunden.  
- Der `GameController` wird gestartet, und die Konsolenausgabe wird aufgezeichnet.  
- Es wird überprüft, ob die ungültigen Eingaben korrekt abgefangen und dem Benutzer eine entsprechende Aufforderung zur Eingabe angezeigt wird.  

**Warum wird getestet?**  
- Stellt sicher, dass der `GameController` bei ungültigen Eingaben die Eingabeaufforderung korrekt wiederholt, bis eine gültige Eingabe erfolgt.  
---

## Protokoll Klasse


### **1. GetInstanceTest**  

**Was wird getestet?**  
- Überprüfung, ob die `GetInstance()`-Methode von `Protokoll` immer dieselbe Instanz zurückgibt (Singleton-Verhalten).  

**Wie wird getestet?**  
- Es wird die `GetInstance()`-Methode zweimal aufgerufen, und die zurückgegebenen Instanzen werden miteinander verglichen.  
- Der Test prüft, ob beide Instanzen identisch sind.  

**Warum wird getestet?**  
- Sicherstellen, dass nur eine Instanz der `Protokoll`-Klasse existiert, was dem Singleton-Muster entspricht.  


### **2. ProtokolliereTest**  

**Was wird getestet?**  
- Überprüfung, ob ein Zug korrekt protokolliert wird.  

**Wie wird getestet?**  
- Ein Spieler (`testSpieler`) und ein Zug (`testZug`) werden erstellt.  
- Die `Protokollieren()`-Methode wird aufgerufen, um den Zug zu protokollieren.  
- Es wird geprüft, ob die Protokollierung erfolgreich durchgeführt wird (dies könnte durch Mocking oder Dateiüberprüfung erfolgen).  

**Warum wird getestet?**  
- Sicherstellen, dass Züge korrekt protokolliert werden.  


### **3. ProtokolliereSpielStartTest**  

**Was wird getestet?**  
- Überprüfung, ob der Spielstart korrekt protokolliert wird.  

**Wie wird getestet?**  
- Die Methode `ProtokolliereSpielStart()` wird mit einer Boardgröße (`boardSize`) aufgerufen.  
- Es wird geprüft, ob die Protokollierung des Spielstarts erfolgt.  

**Warum wird getestet?**  
- Sicherstellen, dass der Start eines Spiels korrekt protokolliert wird.  


### **4. ProtokolliereSpielEndeTest**  

**Was wird getestet?**  
- Überprüfung, ob das Spielende korrekt protokolliert wird.  

**Wie wird getestet?**  
- Ein Spieler (`gewinner`) wird erstellt.  
- Die Methode `ProtokolliereSpielEnde()` wird mit dem Gewinner aufgerufen.  
- Es wird überprüft, ob die Protokollierung des Spiels endet.  

**Warum wird getestet?**  
- Sicherstellen, dass das Ende eines Spiels korrekt protokolliert wird.  


### **5. ZeitProtokollierenTest**  

**Was wird getestet?**  
- Überprüfung, ob die Spielzeit korrekt protokolliert wird.  

**Wie wird getestet?**  
- Ein Zeitwert (`spielzeit`) wird erstellt.  
- Die Methode `ZeitProtokollieren()` wird mit der Spielzeit aufgerufen.  
- Es wird überprüft, ob die Protokollierung der Zeit erfolgt.  

**Warum wird getestet?**  
- Sicherstellen, dass die Spielzeit korrekt protokolliert wird.  


### **6. ConvertToChessNotationTest**  

**Was wird getestet?**  
- Überprüfung, ob die private Methode `ConvertToChessNotation()` korrekt funktioniert.  

**Wie wird getestet?**  
- Die private Methode `ConvertToChessNotation()` wird mittels Reflection aufgerufen.  
- Es wird geprüft, ob das Ergebnis der Umwandlung der Koordinaten `0, 1` korrekt in die Schachnotation `"a2"` umgewandelt wird.  

**Warum wird getestet?**  
- Sicherstellen, dass die Umwandlung der Koordinaten in die Schachnotation korrekt funktioniert.  


### **7. ProtokolliereUngueltigeEingabeTest**  

**Was wird getestet?**  
- Überprüfung, ob ungültige Eingaben korrekt protokolliert werden.  

**Wie wird getestet?**  
- Ein Spieler (`testSpieler`) und ein Zug (`testZug`) werden erstellt.  
- Die Methode `ProtokolliereUngueltigeEingabe()` wird mit dem Zug aufgerufen.  
- Es wird überprüft, ob die ungültige Eingabe protokolliert wird.  

**Warum wird getestet?**  
- Sicherstellen, dass ungültige Eingaben korrekt protokolliert werden.  


### **8. ProtokolliereBestaettigungTest**  

**Was wird getestet?**  
- Überprüfung, ob eine Bestätigung korrekt protokolliert wird.  

**Wie wird getestet?**  
- Ein Spieler (`testSpieler`) und ein Zug (`testZug`) werden erstellt.  
- Die Methode `ProtokolliereBestaetigung()` wird mit dem Zug aufgerufen.  
- Es wird überprüft, ob die Bestätigung des Zugs korrekt protokolliert wird.  

**Warum wird getestet?**  
- Sicherstellen, dass eine Bestätigung korrekt protokolliert wird.  


### **9. ProtokolliereNichtBestaettigungTest**  

**Was wird getestet?**  
- Überprüfung, ob eine Nicht-Bestätigung korrekt protokolliert wird.  

**Wie wird getestet?**  
- Ein Spieler (`testSpieler`) und ein Zug (`testZug`) werden erstellt.  
- Die Methode `ProtokolliereNichtBestaetigung()` wird mit dem Zug aufgerufen.  
- Es wird überprüft, ob die Nicht-Bestätigung des Zugs korrekt protokolliert wird.  

**Warum wird getestet?**  
- Sicherstellen, dass eine Nicht-Bestätigung korrekt protokolliert wird.  

---

## spieler Klasse


### **1. Spieler_Name_ShouldBeCorrect**

**Was wird getestet?**  
- Überprüfung, ob der Name des Spielers korrekt gesetzt wird.  

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird mit dem Namen "Max" und dem Symbol `'X'` erstellt.  
- Die Eigenschaft `Name` des Spielers wird abgefragt und überprüft, ob sie den Wert "Max" enthält.  

**Warum wird getestet?**  
- Sicherstellen, dass der Name des Spielers korrekt gespeichert und abgerufen werden kann.  


### **2. Spieler_Symbol_ShouldBeCorrect**

**Was wird getestet?**  
- Überprüfung, ob das Symbol des Spielers korrekt gesetzt wird.  

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird mit dem Namen "Max" und dem Symbol `'X'` erstellt.  
- Die Eigenschaft `Symbol` des Spielers wird abgefragt und überprüft, ob sie den Wert `'X'` enthält.  

**Warum wird getestet?**  
- Sicherstellen, dass das Symbol des Spielers korrekt gespeichert und abgerufen werden kann.  


### **3. Spieler_UndoFunction_ShouldNotBeNull**

**Was wird getestet?**  
- Überprüfung, ob die `Undo`-Funktion des Spielers nicht null ist.  

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird mit dem Namen "Max" und dem Symbol `'X'` erstellt.  
- Die `Undo`-Funktion des Spielers wird abgefragt und überprüft, ob sie nicht null ist.  

**Warum wird getestet?**  
- Sicherstellen, dass die `Undo`-Funktion (vermutlich für die Rückgängig-Funktionalität des Spiels) korrekt zugewiesen und nicht null ist.  

---

## SpielTimer Klasse


### **1. Constructor_InitializesStopwatch**

**Was wird getestet?**  
- Überprüfung, ob der `SpielTimer`-Konstruktor den Timer korrekt initialisiert.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt.  
- Die Methode `Erhalten()` wird aufgerufen, um den aktuellen Timer-Status zu überprüfen.  

**Warum wird getestet?**  
- Sicherstellen, dass der Timer beim Erstellen des Objekts korrekt initialisiert wird und die anfängliche Zeit "00:00" ist.  


### **2. Starten_StartsTimer**

**Was wird getestet?**  
- Überprüfung, ob der Timer korrekt gestartet wird.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt und die Methode `Starten()` wird aufgerufen.  
- Der Test wartet 1 Sekunde (`Thread.Sleep(1000)`) und stoppt dann den Timer mit `Stoppen()`.  
- Es wird überprüft, ob die zurückgegebene Zeit nicht mehr "00:00" ist.  

**Warum wird getestet?**  
- Sicherstellen, dass der Timer bei einem Start eine tatsächliche Zeit misst und diese nicht gleich zu "00:00" bleibt.  


### **3. Stoppen_StopsTimer**

**Was wird getestet?**  
- Überprüfung, ob der Timer korrekt gestoppt wird.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt und gestartet.  
- Der Timer wird nach 1 Sekunde gestoppt.  
- Die zurückgegebene Zeit wird zweimal abgefragt: einmal nach der ersten Pause und einmal nach einer zweiten Pause von 1 Sekunde.  
- Es wird überprüft, ob die zurückgegebene Zeit nach der ersten Pause und der zweiten Pause gleich bleibt.  

**Warum wird getestet?**  
- Sicherstellen, dass der Timer gestoppt wird und keine Zeit mehr fortschreitet, wenn der Timer gestoppt ist.  


### **4. Erhalten_ReturnsFormattedTime**

**Was wird getestet?**  
- Überprüfung, ob die zurückgegebene Zeit im richtigen Format vorliegt.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt, gestartet und nach 1.5 Sekunden gestoppt.  
- Es wird überprüft, ob die zurückgegebene Zeit dem Format `MM:SS` entspricht (z. B. "01:30").  

**Warum wird getestet?**  
- Sicherstellen, dass die zurückgegebene Zeit korrekt formatiert ist und dem vorgegebenen Zeitformat entspricht.  


### **5. Zuruecksetzen_ResetsTimer**

**Was wird getestet?**  
- Überprüfung, ob die Methode `Zuruecksetzen()` den Timer zurücksetzt.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt, gestartet und nach 1 Sekunde gestoppt.  
- Die zurückgegebene Zeit wird gespeichert und dann wird der Timer mit `Zuruecksetzen()` zurückgesetzt.  
- Der Timer wird erneut gestartet und nach 0.5 Sekunden gestoppt.  
- Es wird überprüft, ob die zweite zurückgegebene Zeit unterschiedlich zur ersten ist.  

**Warum wird getestet?**  
- Sicherstellen, dass der Timer mit `Zuruecksetzen()` korrekt auf den Anfangszustand zurückgesetzt wird und die Zeit von vorne beginnt.  


### **6. MultipleStartAndStop_WorksCorrectly**

**Was wird getestet?**  
- Überprüfung, ob das wiederholte Starten und Stoppen des Timers korrekt funktioniert.  

**Wie wird getestet?**  
- Ein `SpielTimer`-Objekt wird erstellt, mehrfach gestartet und gestoppt (jeweils nach 0.5 Sekunden).  
- Es wird überprüft, ob die zurückgegebene Zeit das richtige Format hat.  

**Warum wird getestet?**  
- Sicherstellen, dass der Timer korrekt funktioniert, wenn er mehrfach gestartet und gestoppt wird und dass die Zeit korrekt abgerufen wird.  

---

## UndoFunction Klasse


### **1. SpeichereZug_AddsZugToHistory**

**Was wird getestet?**  
- Überprüfung, ob ein Zug korrekt zum Verlauf (History) hinzugefügt wird.  

**Wie wird getestet?**  
- Ein `UndoFunction`-Objekt wird erstellt, zusammen mit einem `Spieler`-Objekt und einem `Zug`.  
- Der `SpeichereZug`-Methode wird der Zug übergeben, und danach wird der zuletzt gespeicherte Zug mit `LadeLetztenZug()` abgerufen.  
- Es wird überprüft, ob der gespeicherte Zug mit dem geladenen Zug übereinstimmt.  

**Warum wird getestet?**  
- Sicherstellen, dass der Zug korrekt gespeichert wird und beim Laden des letzten Zuges wieder korrekt abgerufen werden kann.  


### **2. LadeLetztenZug_ReturnsNullWhenNoZugeExist**

**Was wird getestet?**  
- Überprüfung, ob beim Versuch, einen Zug zu laden, der noch nicht gespeichert wurde, `null` zurückgegeben wird.  

**Wie wird getestet?**  
- Ein `UndoFunction`-Objekt wird erstellt, aber es wird kein Zug gespeichert.  
- Die Methode `LadeLetztenZug()` wird aufgerufen, und es wird überprüft, ob der Wert `null` zurückgegeben wird.  

**Warum wird getestet?**  
- Sicherstellen, dass das System korrekt aufgerufen wird, wenn noch keine Züge gespeichert sind und entsprechend `null` zurückgibt.  


### **3. LadeLetztenZug_RemovesZugFromHistory**

**Was wird getestet?**  
- Überprüfung, ob die Methode `LadeLetztenZug()` den Zug nach dem Laden entfernt (Stapelverhalten).  

**Wie wird getestet?**  
- Zwei Züge werden in die `UndoFunction` gespeichert.  
- Der letzte Zug wird geladen und anschließend entfernt, und der nächste Zug wird ebenfalls geladen.  
- Es wird überprüft, ob die Züge in der richtigen Reihenfolge geladen werden und ob nach dem Laden aller Züge `null` zurückgegeben wird.  

**Warum wird getestet?**  
- Sicherstellen, dass Züge in der Reihenfolge ihres Hinzufügens gespeichert und beim Laden in umgekehrter Reihenfolge abgerufen werden.  


### **4. MultipleZuege_LoadedInReverseOrder**

**Was wird getestet?**  
- Überprüfung, ob mehrere Züge korrekt in umgekehrter Reihenfolge geladen werden.  

**Wie wird getestet?**  
- Drei Züge werden in die `UndoFunction` gespeichert.  
- Jeder Zug wird geladen und überprüft, ob sie in der richtigen umgekehrten Reihenfolge geladen werden.  

**Warum wird getestet?**  
- Sicherstellen, dass die Methode `LadeLetztenZug()` Züge immer in umgekehrter Reihenfolge zurückgibt, da dies das typische Verhalten einer Undo-Funktion ist (LIFO - Last In, First Out).  

---

## Zug Klasse


### **1. Constructor_SetsPropertiesCorrectly**

**Was wird getestet?**  
- Überprüfung, ob der Konstruktor der `Zug`-Klasse die Eigenschaften des Objekts korrekt setzt (Spieler, Zeile und Spalte).

**Wie wird getestet?**  
- Ein `Spieler`-Objekt sowie Zeilen- und Spaltenwerte werden erstellt.  
- Ein `Zug` wird mit diesen Werten instanziiert.  
- Es wird überprüft, ob die Eigenschaften `Spieler`, `Row` und `Col` korrekt gesetzt sind.  

**Warum wird getestet?**  
- Sicherstellen, dass der Konstruktor die richtigen Werte für den Spieler, die Zeile und die Spalte initialisiert.  


### **2. Constructor_SetsZeitstempelToCurrentTime**

**Was wird getestet?**  
- Überprüfung, ob der `Zeitstempel` des `Zug`-Objekts auf die aktuelle Zeit gesetzt wird.

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird erstellt und der `Zug` wird instanziiert.  
- Der `Zeitstempel` des `Zug`-Objekts wird geprüft und mit der Zeit vor und nach der Instanziierung verglichen.  
- Es wird überprüft, dass der `Zeitstempel` des Zugs in diesem Zeitraum liegt.  

**Warum wird getestet?**  
- Sicherstellen, dass der `Zeitstempel` korrekt auf die aktuelle Zeit gesetzt wird, wenn der Zug erstellt wird.  


### **3. Constructor_AllowsZeroBasedIndices**

**Was wird getestet?**  
- Überprüfung, ob der Konstruktor auch nullbasierte Indizes akzeptiert.

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird erstellt und der `Zug` wird mit den Indizes `0, 0` instanziiert.  
- Es wird überprüft, ob `Row` und `Col` korrekt auf `0` gesetzt sind.  

**Warum wird getestet?**  
- Sicherstellen, dass der Konstruktor auch mit nullbasierten Indizes funktioniert, die häufig bei Arrays und Matrizen verwendet werden.  


### **4. Constructor_AllowsNegativeIndices**

**Was wird getestet?**  
- Überprüfung, ob der Konstruktor auch negative Indizes akzeptiert.

**Wie wird getestet?**  
- Ein `Spieler`-Objekt wird erstellt und der `Zug` wird mit den Indizes `-1, -2` instanziiert.  
- Es wird überprüft, ob `Row` und `Col` korrekt auf `-1` und `-2` gesetzt sind.  

**Warum wird getestet?**  
- Sicherstellen, dass der Konstruktor auch mit negativen Indizes funktioniert, was in einigen Spielmechaniken oder Testfällen von Bedeutung sein kann.  


### **5. Constructor_SetsPlayerSymbolCorrectly**

**Was wird getestet?**  
- Überprüfung, ob der `Symbol` des Spielers korrekt gesetzt wird.

**Wie wird getestet?**  
- Ein `Spieler`-Objekt mit dem Symbol `'O'` wird erstellt.  
- Ein `Zug` wird mit diesem Spieler instanziiert.  
- Es wird überprüft, ob das Symbol des Spielers korrekt auf `'O'` gesetzt ist.  

**Warum wird getestet?**  
- Sicherstellen, dass der `Symbol` des Spielers korrekt im `Zug`-Objekt gespeichert wird und zugänglich ist.  

---


