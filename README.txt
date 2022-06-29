PROJEKTNAME: Soulslike Bossfight

TEAMMITGLIEDER
- Tabea Leibl [204105]
- Karen Hofele [204029]

PROJEKTLINK - GITHUB
https://github.com/khofele/Labor-Games-Bossfight

PROJEKTLINK - BUILD + CODE
https://studhsheilbronnde-my.sharepoint.com/:f:/g/personal/khofele_stud_hs-heilbronn_de/EvZwWWL8N2RAlgb_lkZ4BWUBqOqxd-4QSDtfAYqyBIlVFg?e=iLkeql

DEMOVIDEO
https://youtu.be/34A7yvJze9M

DOKUMENTATION (Links zu den Präsentationen, Trelloboard sowie Github können auch in der Dokumentation gefunden werden)
https://docs.google.com/document/d/1H2--uqEWYi4q0RO8O1paSUFVL46qGFqQ/edit?usp=sharing&ouid=117961953867140478498&rtpof=true&sd=true

BESONDERHEITEN DES PROJEKTS
Für das Starten des Spiels sind keine besonderen Voraussetzungen nötig. Die exe-Datei kann über den Link (siehe oben) gefunden und normal gestartet werden.
Die Steuerung kann im Menü eingesehen werden, sobald das Spiel gestartet wurde.

MÖGLICHE ISSUES
- Man kann sich mit Mühe mit dem Spieler in den Drachen sowie in die Steine am Rand der Arena reinglitchen.
    --> Falls man von alleine nicht mehr herauskommt, muss das Spiel neu gestartet werden.
- Der Drache hängt manchmal fest.
	--> Falls er von alleine nicht in eine andere Action übergeht, muss das Spiel neu gestartet werden.
- Der Character könnte bei Spielstart über dem Boden schweben. 
    --> Hier hilft es, Unity neu zu starten.
Der Character könnte sich am Drachen in die Luft glitchen.
    --> Das Spiel neu starten.
- Die Camera könnte im Boden hängen.
    --> Unity (eventuell mehrmals) neu starten oder notfalls Camera neu setzen (siehe Prefabs).
- Die Staminaregeneration setzt bei Abbruch einer Angriffskombo durch zu wenig Stamina nicht immer ein.
    --> Den Character bewegen.

BESONDERE LEISTUNGEN, HERAUSFORDERUNGEN UND GESAMMELTE ERFAHRUNGEN, WAS HAT AM MEISTEN ZEIT GEKOSTET?
- Aufbau der State Machine für den Character
    Eine Herausfroderung hier war, dass die States teils nicht abbrechbar sein dürfen (wie zum Beispiel
    Angriffe, die Rolle, oder Ähnliches). Die States wurden daher dementsprechend verbunden und zusätzlich
    durch Bool-Werte im Animator und if-Statements im Code abgesichert.
    Eine weitere Herausforderung stellte die Attack-Combo dar, da diese abbrechbar sein soll nach jedem
    State (also zum Beispiel nach zwei Attacken oder auch nur einer Attacke). Die Kombo sollte nur eine
    Möglichkeit darstellen, kein Muss. Diese Möglichkeit wurde im CharacterMovement-Skript 
    durch das Zählen der Zeit zwischen den Klicks des Spielers sowie der Anzahl dieser sowie korrekter
    Verknüpfungen in den Animatoren umgesetzt.

- Character-Animationen
    Es muss ein Wechsel der Animationen je nach Waffe geschehen, das Problem hierbei ist, dass der
    Animator keine Eingriffe in die Motion zulässt. Unsere Lösung für dieses Problem war, dass wir
    für jede Waffe einen eigenen Animation Controller erstellt haben, der je nach Waffe im
    CharController gesetzt wird.
    Außerdem stellte das Anpassen der Animationen für uns eine große Challenge dar (z.B. unpassende
    Beine oder Hände bei Animationen von Assets oder Mixamo). Die Lösung hierfür war die Verwendung
    von UMotion, in welchem wir kleine sowie größere Anpassungen vornehmen konnten sowie einzelne
    Animationen komplett selbst gestalten konnten.

- Character: Kleidungs-Glitches
    Bei den anfänglich ausgewählten Rüstungsteilen hatten wir das Problem, dass diese sich nicht
    korrekt an die Bewegungen des Characters anpassen konnten und daher bei jeder Bewegung dessen
    Haut zu sehen war. Für die Hose und Stiefel konnten wir dieses Problem durch ein neues Rigging am
    Skelett vom Character-Model lösen, für Torso und Helm jedoch waren neue Kleidungsstücke, die
    aufgeteilt sind, notwendig, sowie eine Feinjustierung der Animationen.

- Character Camera
    Die Kamera hat sich anfänglich überhaupt nicht so verhalten, wie wir es benötigen, und war schwierig
    einzustellen. Eine für uns zufriedenstellende Umsetzung war einfach nicht absehbar. Daher haben wir
    die Kamera komplett neu aufgesetzt und die Werte neu eingestellt und das Problem war gelöst.

- Staminakontrolle des Characters
    Der Character soll Stamina für die Ausführung von Angriffen, der Rolle sowie fürs Rennen benötigen.
    Hierfür wollten wir jedoch keine Magic Numbers im Animation Controller haben und auch nicht in Code
    sowie diesem jeweils den Wert anpassen. Des Weiteren waren eigene Staminawerte für jede Waffe unser
    Ziel. Diese Challenge haben wir schließlich durch einen eigenen Manager für Stamina und alles was 
    damit zu tun hat gelöst, welcher im CharacterMovement-Skript kontrolliert, 
    ob genug Stamina vorhanden ist, um eine Handlung auszuführen.

- Damage-System Character 
    Ein Konzept für das Damagetaking des Characters, das alle nötigen Komponenten der Interaktion
    mit dem Boss abdeckt, nahm viel Zeit in Anspruch.
    Ein Problem war, dass der Character direkt Schaden nahm, sobald er dem Boss nahe kam. Dies lösten
    wir durch eine Aktivierung der Boss-Collider der am aktuellen Angriff beteiligten Körperteile des
    Drachen, sodass diese nur dann die Collider des Characters triggern, er also nur dann einen Treffer
    registriert. Zusätzlich wird nur ein Hit pro Angriff gezählt, damit nicht jedes Körperteil einzeln
    Schaden nimmt. Die Boss-Collider werden nach jedem Angriff wieder deaktiviert. Zusätzlich bekamen
    Attacken wie das Feuerspeien des Drachen einen eigenen Collider für das Feuer, damit der Character 
    diese auch erkennt. 
    Damit der Character weiß, ob gerade eine Attacke vom Boss ausgeführt wird und wenn ja, welche und
    wie viel Schaden er von dieser schlussendlich bekommt, führten wir einen AttackManager für die Bossattacken
    ein, der die aktuelle Attacke sowie deren minimalen und maximal möglichen Schaden verwaltet und den Damage
    für den Character brechnet.
    Bekommt der Character zu viel Damage in kurzer Zeit, so wird er für kurze Zeit gestunnt.

- Behavior Tree/Boss-KI/Automatisiertes Verhalten
    Die Erstellung des Behavior Trees bzw. der Boss-KI hat sehr viel Zeit in Anspruch genommen und hat uns 
    das ganze Semester über beschäftigt. Vom Finden des Assets Behavior Bricks und das Einlesen in dieses und 
    Behavior Trees allgemein bis hin zur Erstellung der ganzen Skripte hinter den Actions und Conditions sowie 
    der Erstellung des Baumes selbst, vergingen viele Sprints. Ein automatisiertes Verhalten bzw. eine Boss-KI 
    zu erstellen, benötigte eine andere Denkweise wie in bisherigen Projekten, da man als Spieler keinen Einfluss 
    auf das Verhalten hat und alles von alleine funktionieren muss. Die visuelle Darstellung des Baumes im Editor 
    des Assets war sehr hilfreich und half immer wieder Denkfehler in Abläufen und Logiken aufzudecken. Vor allem 
    aber die Optimierung der Abläufe war hierbei aufwending. 
    Es war das erste Mal, dass wir in diesem Ausmaß mit komplett automatisiertem Verhalten gearbeitet haben und es 
    war dadurch mit eine der größten Challenges und Zeitfresser aber damit auch einer der größten Lernerfolge.

- Flugmechanik Boss + Timer 
    Die Flugmechanik, die mit Phase 2 hinzukommt, war die aufwendigste Fähigkeit des Bosses und hat von allen Attacken 
    am Meisten Zeit in Anspruch genommen. Die Besonderheit hierbei ist, dass der Drache sich im Gegensatz zu allen anderen 
    Fähigkeiten hierbei nicht auf dem Boden befindet. Dadurch sondert sich diese Mechanik ab und es musste sichergestellt 
    werden, dass diese Mechanik auch durch kein Auslösen einer anderen Attacke oder Animation unterbrochen wird. Es wurden 
    mehrere Checks an verschiedenen Stellen eingebaut, um sicherzugehen, dass der Boss durchgehend fliegt, sobald er sich in 
    der Luft befindet. Vom Beginn bis hin zur Optimierung und Fertigstellung dieser Attacke bzw. Mechanik gingen verglichen 
    mit anderen Attacken sehr viel Zeit. 

- Boss-Animationen bearbeiten/anpassen
    Um alle Attacken sowie die Flugmechanik auch visuell zu ermöglichen mussten Animationen teilweise angepasst bzw. verändert 
    werden und manche mussten komplett neu erstellt werden. Ein besonderes Problem, das sich durch den Drachen ergab, war das 
    vorhandene Animationen nicht gespiegelt werden konnten, da der Boss kein humanoider Charakter ist. Dadurch war die Anpassung 
    der Animationen zeitaufwendiger als geplant. Zudem musste zu allen Feueranimationen auch noch der jeweilige Partikeleffekt 
    hinzugefügt werden. Auch die Erstellung und Anpassung des Animator Controllers war aufwendig, da dieser für den Boss recht 
    groß geworden ist und es viele Transitions gibt.

- Damage System + Stun Boss 
    Die Erstellung eines Konzepts für das Damage-System und den Stun sowie die Umsetzung davon, benötigte ebenfalls ein paar Tage. 
    Die Optimierung und Anpassung war hierbei mit der größte Aufwand. Da es immer wieder zu Probleme kam, da das Damage Dealing des 
    Characters nicht ausgelöst wurde und der Boss keinen Schaden nehmen konnte.
    Die Idee den Stun beim Boss über einen Timer zu regeln, kam erst im Laufe des Projekts aber war für den Boss eine gute Möglichkeit, 
    da dies sehr gut automatisiert werden konnte und auch komplett im Damagable-Skript passieren kann. Auch hier kam wieder die veränderte 
    Denkweise zum Tragen, dass der Boss alle Fähigkeiten und Hintergrundprozesse, wie z.B. Damage erhalten, alleine abhandeln können muss.

- Menü und Szenenwechselsystem
    Das Menü war durch seine Komplexität eine Herausforderung. Es gibt viele Bestandteile und Komponenten, die sich gegenseitig 
    beeinflussen - sowohl im Hintergrund als auch visuell durch Anzeigen von z.B. Werten oder der Ausrüstung im Menü selbst. 
    Es musste zunächst ein Grundgerüst aus verschiedenen Skripten und Game Objects gebaut werden, um alle Funktionen und Interaktionen 
    umzusetzen. Dazu kam dann noch das System, um die gewählten Werte über den Szenenwechsel hinaus zu erhalten und dann in der GameScene 
    dem Character Controller zugänglich zu machen. Die Herausforderung war hierbei neben dem Erhalt der Werte auch eine gute Struktur, 
    um nur die wichtigen Werte zu erhalten aber auch damit sich diese Skripte gut in die bereits erstellte UI einpflegen lassen. Um das 
    Ganze dann auch im Game selbst anzuwenden, waren auch Änderungen im Character Controller nötig.

- Komplexität des Projekts
    Das Projekt wuchs von Sprint zu Sprint und es wurde immer komplexer, neue Features zu integrieren.
    Es sind sehr viele Skripte und Komponenten da, die verwaltet und koordiniert werden müssen.
    Hierfür mussten wir uns die Zeit gut einteilen, uns nicht über-, aber auch nicht unterschätzen
    sowie mit unvorhergesehenen Zwischenfällen wie auftretenden Bugs und Krankheit umgehen.

- Zusammenführung von Boss und Character in einer Szene
    Diese gestaltete sich als sehr anspruchsvoll. Zu Beginn hatten wir Merge-Konflikte beim 
    Mergen der Branches, in denen wir gearbeitet hatten. Die mühsam gesetzten Referenzen gingen verloren
    und wir mussten diese überall sorgsam neu setzen. Doch eine der größten Herausforderungen war,
    dass der Boss und der Character zusammenpassen müssen. Es muss sich gut anfühlen, gegen den Boss zu
    kämpfen und alles muss wie gewünscht funktionieren: vom Damage Dealing und der Hit Detection, den
    Angriffen und Aktionen bis hin zu den Animationen. Dies erreichten wir durch langes Probieren,
    Testen und Refactoren verschiedenster Komponenten unseres Spiels.

- Balancing
    Um ein zufriedenstellendes Spielergebnis zu erreichen, war viel Balancing notwendig. Es gibt sehr
    viele Stellschrauben, an denen gedreht werden kann und musste und sehr viele kleine Tweaks waren
    notwendig, um ein optimales Gameplay zu ermöglichen. Dies ging auch mit einem entsprechenden Zeitaufwand
    einher.

- Simple Tooltip-Asset
    Bei diesem Asset war das Problem, dass Texte nur im Inspektor gesetzt werden konnten, was sehr
    unschön ist und somit auch nicht für die aktuell ausgewählte Ausrüstung möglich ist, da sich hier
    der Text je nach ausgewähltem Teil während das Spiel läuft ändern muss. Die Lösung hierfür war,
    die Skripte manuell umzuschreiben, sodass ein Setzen der Texte im Code möglich ist.

VERWENDETE ASSETS UND QUELLEN
Assets:
    - https://assetstore.unity.com/packages/3d/characters/humanoids/humans/human-character-60016#description
    - https://assetstore.unity.com/packages/3d/props/clothing/armor/armor-pack-1-135427
    - https://assetstore.unity.com/packages/3d/props/weapons/weapons-armor-pbr-pack-1-44714
    - https://assetstore.unity.com/packages/3d/characters/creatures/dragons-45330
    - https://assetstore.unity.com/packages/tools/visual-scripting/behavior-bricks-74816
    - https://assetstore.unity.com/publishers/4986
    - https://assetstore.unity.com/packages/3d/props/potions-coin-and-box-of-pandora-pack-71778
    - https://assetstore.unity.com/packages/2d/fonts/fatality-fps-gaming-font-216954
    - https://assetstore.unity.com/packages/3d/small-cave-kit-49372
    - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/procedural-fire-141496
    - https://assetstore.unity.com/packages/tools/gui/simple-tooltip-155804
    - ProBuilder
    - Cinemachine
Szenenwechsel:
    - https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
    - https://gamedev.stackexchange.com/questions/185361/how-can-i-display-a-3d-object-and-my-player-on-a-canvas
    - https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    - https://stackoverflow.com/questions/54004114/cant-find-gameobject-in-new-scene-in-dontdestroyonload
Sounds:
    - https://www.youtube.com/watch?v=O4Xm_0EEE4A&list=PLq44zq7R2Kq6ASr8PGk1XHRzFfDwXC3eX&index=5
    - https://www.youtube.com/watch?v=n-vzpEA95hA&list=PLq44zq7R2Kq6ASr8PGk1XHRzFfDwXC3eX&index=21
- einzelne Animationen: https://www.mixamo.com/#/ 
- Waffen-Sounds: https://www.youtube.com/watch?v=q1xvPzEayaU
- Heal-Sound: in Elden Ring selbst aufgenommen
- Bossfight Menütitel: https://cooltext.com/Logo-Design-Epic-Stone
- Font Messages: https://www.dafont.com/assassin.font
- Skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633#description
- Icons: https://www.flaticon.com/

INSPIRATIONEN
- Finite State Machine: https://medium.com/c-sharp-progarmming/make-a-basic-fsm-in-unity-c-f7d9db965134
- Finite State Machine: https://www.youtube.com/watch?v=tjV7E9WITKQ
- Cinemachine: https://www.youtube.com/watch?v=537B1kJp9YQ
- Attack Combo Character: https://www.youtube.com/watch?v=gHaJUNiItmQ
- Combat System: https://www.youtube.com/watch?v=sPiVz1k-fEs
- Behavior Tree: https://medium.com/geekculture/how-to-create-a-simple-behaviour-tree-in-unity-c-3964c84c060e
- UMotion Manual: https://www.soxware.com/umotion-manual/UMotionManual.html
- Finite State Machine: https://github.com/MinaPecheux/UnityTutorials-FiniteStateMachines
- Behavior Tree: https://github.com/MinaPecheux/UnityTutorials-BehaviourTrees
- Behavior Tree: https://medium.com/geekculture/how-to-create-a-simple-behaviour-tree-in-unity-c-3964c84c060e
- Behavior Bricks Manual: http://bb.padaonegames.com/doku.php?id=start
- Cinemachine: https://www.youtube.com/watch?v=537B1kJp9YQ
- Infinity PBR Tutorials: https://infinitypbr.com/tutorials