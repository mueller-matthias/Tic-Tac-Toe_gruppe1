# Testkonzept

## Zug Klasse

### **1. Constructor_SetsPropertiesCorrectly** 

**Was wird getestet?**: Es wird getestet, ob die Eigenschaften Spieler, Row und Col korrekt gesetzt werden, wenn ein Zug-Objekt erstellt wird.  

**Wie wird getestet?**: zuerst wird eine Instanz von Spieler erstellt. danach wird Ein Zug mit den Werten für Row und Col initialisiert. zum schluss wird überprüft, ob die Eigenschaften des Zuges mit den übergebenen Werten übereinstimmen.  

**Warum wird getestet?**: Der Test stellt sicher das ein Zug-Objekt richtig initialisiert wird und die werte korrekt gespeichert wurden  

### **2. Constructor_SetsZeitstempelToCurrentTime**  

**Was wird getestet?**: Es wird getestet, ob das Zug Objekt einen zeitstempel setzt der in den richtigen Zeitrahmen fällt. 

**Wie wird getestet?**: zuerst wird der aktuelle zeitpunkt gespeichert, dan der zeitpunkt bei der erstellung des zuges und bevor geprüft wird ob er zeitstempel des zuges zwischen den beiden gespeicherten zeitpunkten liegt, speichert man nochmal den aktuellen zeitpunkt.

**Warum wird getestet?**: Der Test stellt sicher, dass der Zug den Zeitstempel korrekt setzt.

### **3. Constructor_AllowsZeroBasedIndices**  

**Was wird getestet?**: Es soll getestet werden ob ein Zug mit Row und Col als `0` erstellt werden kann.  

**Wie wird getestet?**: zuerst wird eine instanz von spieler erstellt und danach ein zug mit row und col = `0` erstellt. Zum schluss wird überprüft ob die gespeicherten Werte im zug richtig sind.

**Warum wird getestet?**: Der Test soll prüfen das er Zug nullbasierte eingaben unterstützt.

### **4. Constructor_AllowsNegativeIndices** 

**Was wird getestet?**: Es wird getestet, ob ein Zug mit negativen Werten für Row und Col erstellt werden kann.  

**Wie wird getestet?**: zuerst wird wieder eine Instanz von Spieler erstellt. und ein Zug mit row und col mit einem negativen zahlenwert. danach prüft man ob die gespeicherten werte im Zug Korrekt sind 

**Warum wird getestet?**: Der test ist vorallem für später falls das spiel ml in einem szenario negative werte annehmen soll. 

### **5. Constructor_SetsPlayerSymbolCorrectly**  

**Was wird getestet?**: Es wird getestet, ob das Symbol des Spielerskorrekt im Zug gespeichert wird.  

**Wie wird getestet?**: zuerst wird ein spieler erstellt mit dem symbol `'O'` und danach ein zug mit demselben symbol. überprüft wird ob das symbol des spielers im zug richtig ist.

**Warum wird getestet?**: Der Test stellt sicher, dass das `Zug`-Objekt das Symbol des Spielers korrekt speichert.
---

## GameBoardModel Klasse

### **1. GetCellTest**  

**Was wird getestet?**:  Es wird überprüft, ob eine Zelle auf dem Spielfeld korrekt ausgelesen wird.  

**Wie wird getestet?**: zuerst erstellt man ein GameBardModel Objekt mit grösse 3x3 und der wert einer bestimmten zelle wird abgefragt, der wert muss dann `'.'` sein (standardwert).

**Warum wird getestet?**: der Test Stellt sicher, dass das Spielfeld korrekt erstellt wird und der Standardwert richtig zurückgegeben wird

### **2. SetCellTest**  

**Was wird getestet?**: Es wird überprüft ob eine zelle richtig auf dem spielfeld gesetzt wird

**Wie wird getestet?**: zuerst erstellt man ein `GameBoardModel`-Objekt mit dem wert `'X'` auf einer bestimmten zelle. Danach wird gepröfft ob die Zelle den gewollten wert hat.

**Warum wird getestet?**: schaut das das setzen eines Wertes Funktioniert.


### **3. ValidateMoveTest_ValidMove**  

**Was wird getestet?**: Es wird geschaut ob ein gültiger Zug auch als gültig erkannt wird 

**Wie wird getestet?**: Zuerst wird ein leeres GameBoardModel wird erstellt. Dann wird überprüft ob ein gültiger zug auf einer freien Zelle als gültig erkannt wird.

**Warum wird getestet?**: Man muss schauen ds Gültige züge richtig erkannt werden.


### **4. ValidateMoveTest_InvalidMove**  

**Was wird getestet?**: Es wird geschaut, ob ein ungültiger Zug korrekt erkannt wird.  

**Wie wird getestet?**: Eine Zelle kriegt den Wert `'X'`, und es wird geprüft das wenn man versucht einen neuen wert auf das feld zu setzen, der Zug als ungültig erklärt wird

**Warum wird getestet?**: Schaut dass man nicht 2 züge auf ein Feld machen kann


### **5. PruefeGewinnerTest_WinningRow**  

**Was wird getestet?**: es wird geprüfft ob die Gewinnbedinung richtig erkannt wird.

**Wie wird getestet?**: zuesrt wird eine komplette Zeile mit `'x'` gefüllt und es wird geprüft das die Methode erkennt das die Gewinnbedingung erfüllt ist

**Warum wird getestet?**: Es wird geschaut das man sieht ob die gewinnbedingung funktioniert.


### **6. PruefeGewinnerTest_NoWin**  

**Was wird getestet?**: Es wird geprüft, ob das Spiel korrekt erkennt wenn es kein Gewinner gibt.

**Wie wird getestet?** Man verteilt die Symbole so das es kein Gewinner gibt un prüft ob die Methode das so erkennt. 

**Warum wird getestet?**: schaut das es nicht einen gewinner gibt, wenn es keinen geben sollte.


### **7. ValidateInputTest_ValidInput**  

**Was wird getestet?**: ess wird geschaut das eine richtige eingabe in zeilen und spaltewerte geteilt wird

**Wie wird getestet?**: eine Eingabe wie z.b `"b2"` wird getestet, die Methode gibt zeile und spalte zurück und es wird geschaut das die werte korrekt überliefert wurden 

**Warum wird getestet?**: Schaut das die Benutzereingaben richtig Interpretiert werden

### **8. ValidateInputTest_InvalidInput**  

**Was wird getestet?**: Es wird geprüft, ob eine ungültige Eingabe korrekt erkannt wird.  

**Wie wird getestet?**: Eine ungültige Eingabe wie `"z9"` wird getestet, danach wird überprüft ob die Methode die auch wirklich als falsch erkennt

**Warum wird getestet?**:Schaut das Fehlerhafte Eingaben Abgefangen werden.

---

## Game ControllerKlasse


### **1. InitialiseSpiel_SelectThreeByThreeBoard_ShouldSetupCorrectly**  

**Was wird getestet?**: Überprüft ob der GameController korrekt initialisiert wird wenn man ein 3x3-Spielfeld auswählt.  

**Wie wird getestet?**: Es wird ein `StringReader` mit der Eingabe `"3\n"` erstellt und an `Console.SetIn` gebunden, danach wird ein `GameController` initialisiert und es wird geprüft ob das gelungen ist.

**Warum wird getestet?**: Schaut ob das Spielfeld korrekt initialisiert wird wenn der Benutzer die Größe `3x3` auswählt.  


### **2. InitialiseSpiel_SelectFiveByFiveBoard_ShouldSetupCorrectly**  

**Was wird getestet?**  
- Überprüfung, ob der `GameController` korrekt initialisiert wird, wenn der Benutzer ein 5x5-Spielfeld auswählt.  

**Wie wird getestet?**: Es wird ein `StringReader` mit der Eingabe `"5\n"` erstellt und an `Console.SetIn` gebunden und ein `GameController` wird initialisiert. Danach mwird geprüft, ob der `GameController` erfolgreich instanziiert wurde. 

**Warum wird getestet?**: Schaut, dass das Spielfeld korrekt initialisiert wird, wenn der Benutzer die Größe `5x5` auswählt.  


### **3. InitialiseSpiel_SelectSevenBySevenBoard_ShouldSetupCorrectly**  

**Was wird getestet?**: Überprüfung, ob der `GameController` korrekt initialisiert wird, wenn der Benutzer ein 7x7-Spielfeld auswählt.  

**Wie wird getestet?**: Es wird ein `StringReader` mit der Eingabe `"7\n"` erstellt und an `Console.SetIn` gebunden danach wird ein `GameController` initialisiert und es wird geprüft ob dieser instanziert wurde.

**Warum wird getestet?**: Stellt sicher, dass das Spielfeld korrekt initialisiert wird, wenn der Benutzer die Größe `7x7` auswählt.  


### **4. IstUnentschieden_EmptyBoard_ShouldReturnFalse**  

**Was wird getestet?**: es wird überprüft, ob die Methode `IstUnentschieden` korrekt `false` zurückgibt, wenn das Spielfeld leer ist.  

**Wie wird getestet?**: Ein `GameController` mit wird initialisiert und die private Methode `IstUnentschieden` wird mittels Reflection aufgerufen. danach prüft es ob das Ergebnis `false` ist (leeres spielfeld kein unentschieden)

**Warum wird getestet?**: Sicherstellen, dass das Spiel korrekt erkennt das es kein unentschieden ist wen das feld nicht voll ist


### **5. InitialiseSpiel_InvalidBoardSize_ShouldRepromptUntilValidInput**  

**Was wird getestet?**: Überprüft das der `GameController` den Benutzer bei ungültigen Eingaben dazu auffordert, eine gültige Spielfeldgröße auszuwählen.  

**Wie wird getestet?**: Ein `StringReader` mit einer Reihe von ungültigen Eingaben (`"4\n0\n6\n3\n"`) wird erstellt und an `Console.SetIn` gebunden. Der `GameController` wird gestartet, und die Konsolenausgabe wird aufgezeichnet. Es wird überprüft, ob die ungültigen Eingaben korrekt abgefangen wurden und eine Eingabeaufforderung erscheint. 

**Warum wird getestet?**: Stellt sicher, dass der `GameController` bei ungültigen Eingaben die Eingabeaufforderung korrekt wiederholt, bis eine gültige Eingabe erfolgt.  
---

## spieler Klasse


### **1. Spieler_Name_ShouldBeCorrect**

**Was wird getestet?**: Überprüft ob der Name des Spielers korrekt gesetzt wird.  

**Wie wird getestet?**: Ein `Spieler` wird mit dem Namen "Max" und dem Symbol `'X'` erstellt. der name wird abgefragt und es wird überprüft ob er stimmt.

**Warum wird getestet?**: Zum testen, dass der Name des Spielers gespeichert und abgerufen werden kann.


### **2. Spieler_Symbol_ShouldBeCorrect**

**Was wird getestet?**: Es wird Überprüft, ob das Symbol des Spielers korrekt gesetzt wird.  

**Wie wird getestet?** Es wird ein Spieler mit dem Namen "Max" und dem Symbol `'X'` erstellt. Das symbol wird aufgerufen und es wird überprüft ob es `'X'` ist.

**Warum wird getestet?** Sicherstellen, dass das Symbol des Spielers korrekt gespeichert und abgerufen werden kann.  


### **3. Spieler_UndoFunction_ShouldNotBeNull**

**Was wird getestet?**: Überprüft ob die `Undo`-Funktion des Spielers nicht null ist.  

**Wie wird getestet?**: Ein Spieler wird mit dem Namen "Max" und dem Symbol `'X'` erstellt. Die `Undo`-Funktion wird abgefragt und es wird geprüft das diese nicht null ist  

**Warum wird getestet?**: um zu testen, dass die `Undo`-Funktion korrekt zugewiesen und nicht null ist.  

---

## SpielTimer Klasse


### **1. Constructor_InitializesStopwatch**

**Was wird getestet?**: Überprüft, ob der SpielTimer KOnstruktor den Timer korrekt initialisiert.  

**Wie wird getestet?**: Ein SpielTimer wird erstellt und die Methode Erhalten wird aufgerufen um den aktuellen Status zu prüfen 

**Warum wird getestet?**: Prüft das der Timer beim Erstellen des Objekts "00:00" ist.  


### **2. Starten_StartsTimer**

**Was wird getestet?**: Überprüft ob der Timer gestartet wird.  

**Wie wird getestet?**: es wird ein Timer-Objekt erstellt und die Methode Starten wird aufgerufen. Danach wartet der test 1 Sekunde und stoppt dann den Timer mit der Methode Stoppen. Im anschluss wird überprüft ob die zurückgegebene Zeit nicht mehr "00:00" beträgt.  

**Warum wird getestet?**: Es wird Getestet um sicherzustelle dass der Timer beim Start eine tatsächliche Zeit misst.  


### **3. Stoppen_StopsTimer**

**Was wird getestet?**: Überprüft ob der Timer korrekt gestoppt wird.  

**Wie wird getestet?**: Es wird ein SpielTimer erstellt und gestartet. Nach 1 Sekunde wird der Timer wider Gestoppt und die Zeit zurückgegebene zeit wid 2 mal abgefragt, das erste mal nach der ersten Pause und und dan zum zweiten mal nach einer pause von einer Sekunde. Anschliessend wird geprüft ob die zurückgegebene Zeit nach den 2 Pausen immernoch gleich ist.

**Warum wird getestet?**: Um sicherzugehen das der Timer auch wirklich gestoppt wird.


### **4. Erhalten_ReturnsFormattedTime**

**Was wird getestet?**: Überprüft ob die zurückgegebene Zeit im richtigen Format vorliegt.  

**Wie wird getestet?**: Ein `SpielTimer`-Objekt wird erstellt, gestartet und nach 1.5 Sekunden gestoppt. danach wird überprüft ob die Zeit in dem Richtigen Format ist 

**Warum wird getestet?**: Um Sicherzustellen das die zurückgegebene Zeit korrekt formatiert.


### **5. Zuruecksetzen_ResetsTimer**

**Was wird getestet?**: Überprüft ob die Methode Zuruecksetzen den Timer auch wirklich zurücksetzt.  

**Wie wird getestet?**: Ein SpielTimer-Objekt wird erstellt und gestartet. Nach einer Sekunde wird es wieder gestoppt. Die Zurückgegebene Zeit wird gespeichert und dan grad wieder mit der Methode zurücksetzen zurückgesetzt. der Timer wird erneut gestartet und nach eienr bestimmten zeit wieder gestoppt. es wird Geprüft ob die 2 Zeiten Unterschiedlich sind.

**Warum wird getestet?**: Man schaut dass der Timer mit der Methode Zuruecksetzen den timer auf den Anfangszustand zurücksetzt.


### **6. MultipleStartAndStop_WorksCorrectly**

**Was wird getestet?**: Überprüft ob das wiederholte Starten und Stoppen des Timers korrekt funktioniert.  

**Wie wird getestet?**: Ein Timer-Objekt wird erstellt und mehrfach gestartet und gestoppt danach wird geprüft ob die zeit am ende das richtige Format hat.

**Warum wird getestet?**: Gucken das der Timer korrekt funktioniert, wenn er mehrfach gestartet und gestoppt wird.

---

## UndoFunction Klasse


### **1. SpeichereZug_AddsZugToHistory**

**Was wird getestet?**: Überprüft ob ein Zug korrekt zur History hinzugefügt wird.  

**Wie wird getestet?**: zuerst werden ein UndoFunction-Objekt, ein Spieler-Objekt und einem Zug erstellt. Der Methode speichereZug wird ein Zug übergeben und danach wird der zuletzt gespeicherte Zug mit LadeLetztenZug abgerufen. Es wird überprüft ob die 2 Züge übereinstimmen.

**Warum wird getestet?**: Es wird sichergestellt dass der Zug korrekt gespeichert wird und beim Laden des letzten Zuges wieder korrekt abgerufen werden kann.  


### **2. LadeLetztenZug_ReturnsNullWhenNoZugeExist**

**Was wird getestet?**: Überprüft ob beim Versuch, einen Zug zu laden, der noch nicht gespeichert wurde, `null` zurückgegeben wird.  

**Wie wird getestet?**: Ein UndoFunction-Objekt wird erstellt es wird aber kein Zug gespeichert. Die Methode LadeLetztenZug wird aufgerufen und es wir überprüft ob der Wert `null` zurückgegeben wird.  

**Warum wird getestet?**: Es wird Sichergestellt dass das System korrekt aufgerufen wird, wenn noch keine Züge gespeichert sind.  


### **3. LadeLetztenZug_RemovesZugFromHistory**

**Was wird getestet?**: Es wird geschau ob die Methode LadeLetztenZug den Zug nach dem Laden entfernt.  

**Wie wird getestet?**: Zwei Züge werden in die UndoFunction gespeichert danach wird Der letzte Zug geladen und anschließend entfernt ausserdem wird der nächste Zug geladen. Anschliessend wird überprüft, ob die Züge in der richtigen Reihenfolge geladen werden und ob am schluss null rauskommt. 

**Warum wird getestet?**: um Sicherzustellen, dass Züge in der richtigen Reihenfolge gespeichert und beim Laden wieder in richtiger reihenfolge geladen werden.


### **4. MultipleZuege_LoadedInReverseOrder**

**Was wird getestet?**: Überprüft ob mehrere Züge richtig in umgekehrter Reihenfolge geladen werden.  

**Wie wird getestet?**: Drei Züge werden in die UndoFunction gespeichert und anschliessend wird jeder Zug geladen und überprüft.

**Warum wird getestet?**: Es wird geschaut dass die Methode LadeLetztenZug Züge immer in umgekehrter Reihenfolge zurückgibt (LIFO - Last In, First Out).  

---

## Zug Klasse


### **1. Constructor_SetsPropertiesCorrectly**

**Was wird getestet?**: Überprüfung, ob der Konstruktor der Zug-Klasse die Eigenschaften korrekt setzt.

**Wie wird getestet?**: Ein Spieler-Objekt sowie Zeilen- und Spaltenwerte werden erstellt, mit ihnen wird ein Zug instanziert. Anschliessend wird überprüft, ob die Eigenschaften `Spieler`, `Row` und `Col` korrekt gesetzt sind.  

**Warum wird getestet?**: ist da um zu schauen das der Konstruktor die richtigen Werte für den Spieler, die Zeile und die Spalte kriegt. 


### **2. Constructor_SetsZeitstempelToCurrentTime**

**Was wird getestet?**: Es wird getestet, ob der Zeitstempel des Zug-Objekts auf die aktuelle Zeit gesetzt wird.

**Wie wird getestet?**: zuerst wird ein Spieler-Objekt erstellt und der Zug wird instanziiert, Anschliessend wied der Zeitstempel des Zug-Objekts geprüft und mit der Zeit vor und nach der Instanziierung verglichen.

**Warum wird getestet?**: um zu schauen das der Zeitstempel korrekt auf die aktuelle Zeit gesetzt wird.


### **3. Constructor_AllowsZeroBasedIndices**

**Was wird getestet?**: Überprüft, ob der Konstruktor auch nullbasierte Indizes akzeptiert.

**Wie wird getestet?**: Ein Spieler-Objekt wird erstellt und der Zug wird mit `0, 0` erstellt. Danach wird geschaut, ob `Row` und `Col` korrekt auf `0` gesetzt sind.  

**Warum wird getestet?** Ist da um Sicherzustellen, dass der Konstruktor auch mit nullbasierten Indizes funktioniert 


### **4. Constructor_AllowsNegativeIndices**

**Was wird getestet?**: Überprüft, ob der Konstruktor auch negative werte akzeptiert.

**Wie wird getestet?**: zuesrt wird ein Spieler-Objekt erstellt und danach wird der Zug wird mit `-1, -2` instanziiert. Danach wird überprüft, ob `Row` und `Col` korrekt auf `-1` und `-2` gesetzt sind.  

**Warum wird getestet?**: es wird geschaut das der Konstruktor auch mit negativen werten funktioniert (manchmal wichtig in einigen spielmechaniken oder test)

### **5. Constructor_SetsPlayerSymbolCorrectly**

**Was wird getestet?**: prüft dass das Symbol des Spielers korrekt gesetzt wird.

**Wie wird getestet?**: Ein Spieler wird mit dem Symbol `'O'` erstellt und aus ihm wird dan ein Zug Instanziert. Danach überprüft man ob das Symbol des Spielers korrekt auf `'O'` gesetzt ist.  

**Warum wird getestet?**: ist da um sicherzustellen, dass das Symbol des Spielers korrekt gespeichert wird.  


