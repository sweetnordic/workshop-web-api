# Flask Web Api `python`

In diesem Abschnitt geht es um eine Web API mit Flask in python.

## Voraussetzungen

Neue virtuelle Umgebung aufbauen.
`python3 -m venv .venv`

Neue Umgebung aktivieren
`.venv/bin/activate`

Notwendige Pakete installieren

- `pip install Flask`

## Projektstruktur erstellen

Unterordner manuell erstellen für den Code beispielsweise `app` oder `src`.

Dort die `main.py` Datei erzeugen.
In der Datei tragen wir nun ein erste, kleine Anwendung ein.

```python
from flask import Flask
app = Flask(__name__)

@app.route("/")
def hello_world():
    return "Hello, World!"
```

Es wird eine neue Flask Anwendung erzeugt und eine Funktion bekommt über die get Attributsfunktion die Ausführbarkeit bzw. einen Endpunkt.

## Projekt starten

Im Terminal starten wir per uvicorn die Anwendung.
Falls anstelle von `app` der Ordnername `src` gewählt wurde, muss der Befehlt dementsprechend angepasst werden.

`flask --app main run`
