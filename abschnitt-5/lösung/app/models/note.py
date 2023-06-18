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

    # def __repr__(self):
    #     return '<Note(name={self.title!r})>'.format(self=self)

class NoteSchema(Schema):
    title = fields.Str(required=True)
    content = fields.Str(allow_none=True)
    category = fields.Str(default='Common', allow_none=True)
    published = fields.Boolean(default=False, required=False)
    created_at = fields.Date()
    updated_at = fields.Date()
