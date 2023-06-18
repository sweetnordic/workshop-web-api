# FastAPI WebAPI `python`

In diesem Abschnitt geht es um eine Web API mit [FastAPI](https://fastapi.tiangolo.com) in python.

## Voraussetzungen

Neue virtuelle Umbegung aufbauen.
`python3 -m venv .venv`

Neue Umgebung aktivieren
`.venv/bin/activate`

Notwendige Pakete installieren

- `pip install fastapi`
- `pip install uvicorn`

## Projektstruktur erstellen

Unterordner manuell erstellen für den Code beispielsweise `app` oder `src`.

Dort die `main.py` Datei erzeugen.
In der Datei tragen wir nun ein erste, kleine Anwendung ein.

```python
# main.py
from fastapi import FastAPI
app = FastAPI()

@app.get("/")
async def root():
 return { "greeting": "Hello world" }
```

Es wird eine neue FastAPI erzeugt und eine Funktion bekommt über die get Attributsfunktion die Ausführbarkeit bzw. einen Endpunkt.

## Projekt starten

Im Terminal starten wir per uvicorn die Anwendung.
Falls anstelle von `app` der Ordnername `src` gewählt wurde, muss der Befehlt dementsprechend angepasst werden.

`uvicorn app.main:app --host localhost --port 8000 --reload`

> Projekt starten mit Ordner `src`.
>
> `uvicorn src.main:app --host localhost --port 8000 --reload`

## Datenmodel erstellen

## API Controller erstellen

[Zurück zur Übersicht](README.md)
[Weiter zu Abschnitt 4 - ASP.NET Core Web API mit Anuglar.js SPA](abschnitt-4.md)
