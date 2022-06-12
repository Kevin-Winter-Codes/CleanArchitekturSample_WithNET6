





-----------------------------------------------------------------------


/*
*	MediatR verwendet die IRequest-Schnittstelle, 
*	um sowohl einen Befehl als auch eine Abfrage darzustellen. 
*	Für unseren Anwendungsfall erstellen wir separate Abstraktionen für Befehle und Abfragen. 
*/

1.) Application.Abstractions.Messaging.ICommand

-----------------------------------------------------------------------
2.) Application.Abstractions.Messaging.IQuery

Wir deklarieren den generischen Typ TResponsemit dem Schlüsselwort out, das angibt, dass es kovariant ist. 

Dadurch können wir einen stärker abgeleiteten Typ 
als den durch den generischen Parameter angegebenen verwenden. 

Doku Kovarianz:
Link->https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/
-----------------------------------------------------------------------
Warum machen wir uns die Mühe, benutzerdefinierte Schnittstellen für Befehle und Abfragen zu definieren?
Ist das nicht von MediatR IRequestSchnittstelle gut genug? 

Mit zusätzlichen Abstraktionen für Query und Command gibt uns der Ansatz, über den wir sprechen, 
viel mehr Flexibilität für die Zukunft. 

# Stellen Sie sich vor, Sie möchten Ihre Commands und Query mit zusätzlichen Funktionen anreichern?

## User Case!!!!
Hier ist ein einfaches Beispiel: 
Wir möchten, dass alle unsere Befehle idempotent sind. 

Idempotent bedeutet, dass sie nur einmal ausgeführt werden können. 

3.) IIdempotentCommand 
-----------------------------------------------------------------------



