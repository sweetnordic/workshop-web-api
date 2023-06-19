FROM python:3.10-alpine

WORKDIR /code
COPY requirements.txt .

RUN pip install --no-cache-dir --upgrade -r requirements.txt

COPY app app

CMD [ "flask", "--app", "app.main", "run",  "--host", "0.0.0.0", "--port", "5000" ]

EXPOSE 5000
