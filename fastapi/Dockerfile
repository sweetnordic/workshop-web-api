FROM python:3.10
WORKDIR /code
COPY ./requirements.txt requirements.txt

RUN pip install --no-cache-dir --upgrade -r requirements.txt && pip install --no-cache-dir gunicorn

COPY ./app app

# Start Uvicorn with http
# CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "80"]

# Start Uvicorn with Usage of Proxy Headers for Ingress with TLS Termination
# CMD ["uvicorn", "app.main:app", "--proxy-headers", "--host", "0.0.0.0", "--port", "80"]

# Start Gunicorn with Uvicorn Workers
CMD [ "gunicorn", "app.main:app", "--workers", "2", "--worker-class", "uvicorn.workers.UvicornWorker", "--bind", "0.0.0.0:80"]

EXPOSE 80
