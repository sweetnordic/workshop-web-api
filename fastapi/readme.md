# FastAPI `python`

This Example with the FastAPI Framework and for data storage SQLAlchemy with a sqlite db.
It uses pydantic to validate the incoming payload.

FastAPI comes with Swagger / OpenAPI UI and ReDoc.

- Swagger: http://127.0.0.1:8000/docs
- ReDoc: http://127.0.0.1:8000/redoc

[OpenAPI Metadata](https://fastapi.tiangolo.com/tutorial/metadata/)

FastAPI also supports

- [GraphQL](https://fastapi.tiangolo.com/advanced/graphql/)
- [WebSockets](https://fastapi.tiangolo.com/advanced/websockets/)
- [Other SQL Databases](https://fastapi.tiangolo.com/tutorial/sql-databases/)
- [Static Files](https://fastapi.tiangolo.com/tutorial/static-files/)

## Prerequirements

- Python 3.10
- Virtual Environment
  - `python3 -m venv .venv`
- Python Packages
  - `pip install -r requirements.txt`
  - `pip install --upgrade -r requirements.txt`

## Debug with Hot Reload

Start uvicorn
`uvicorn app.main:app --host localhost --port 8000 --reload`

## Deployment as Docker

[Docu](https://fastapi.tiangolo.com/deployment/docker/)

## References

1. [Build a CRUD App with FastAPI and SQLAlchemy](https://codevoweb.com/build-a-crud-app-with-fastapi-and-sqlalchemy)
   1. [GitHub Repository](https://github.com/wpcodevo/fastapi_sqlalchemy)
