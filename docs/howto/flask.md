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

`flask --debug --app main run`

## Datenmodel erstellen

Neuen Ordner `models` erstellen, dort die Datei `__init__.py` erstellen.

Als nächstes erstellen wir eine Klasse als Poco und eine Klass als Schema für das Datenmodel der Notizen.

Neue Datei `note.py` erstellen und mit folgenden Inhalt füllen.

```python
import datetime as dt
from marshmallow import Schema, fields

class Note(object):
    def __init__(self, title, content, category, published):
        self.title = title
        self.content = content
        self.category = category
        self.published = published
        self.created_at = dt.datetime.now()
        self.updated_at = dt.datetime.now()

    def __repr__(self):
        return '<Note(name={self.title!r})>'.format(self=self)

class NoteSchema(Schema):
    title = fields.Str(required=True)
    content = fields.Str(allow_none=True)
    category = fields.Str(default='Common', allow_none=True)
    published = fields.Boolean(default=False, required=False)
    created_at = fields.Date()
    updated_at = fields.Date()
```

## Docker

Datei `Dockerfile` erstellen und mit folgenden Inhalt füllen.

> Dieses Image startet dann den flask Development Server.

```dockerfile
FROM python:3.10-alpine

WORKDIR /code
COPY requirements.txt .

RUN pip install --no-cache-dir --upgrade -r requirements.txt

COPY app app

CMD [ "flask", "--app", "app.main", "run",  "--host", "0.0.0.0", "--port", "5000" ]

EXPOSE 5000
```
