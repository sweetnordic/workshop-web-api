from app.models.note import NoteSchema, Note
from flask import Flask, jsonify, request

app = Flask(__name__)

@app.route("/")
def hello_world():
    return "Hello, World!"

## Notizen

notes = [
    Note('Meine erste Notiz', 'Dies ist meine erste Notiz', 'Common', True),
    Note('Meine zweite Notiz', '', 'Test', True),
    Note('Meine dritte Notiz', '', 'Common', True),
]

@app.route('/notes')
def get_notes():
    schema = NoteSchema(many=True)
    list = schema.dump(notes)
    return jsonify(list)

@app.route('/notes', methods=['POST'])
def post_note():
    note = NoteSchema().load(request.get_json())
    notes.append(note)
    return "", 204
