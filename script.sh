#!/bin/sh

docker network create sample
docker run -p5432:5432 --network sample -e POSTGRES_USER=sample -e POSTGRES_DB=sample -e POSTGRES_PASSWORD=sample -d --name some-postgres postgres:alpine
docker build --file Dockerfile6 . -t sample6
docker build --file Dockerfile3 . -t sample31

echo "Executing .NET 3.1"

docker run --rm --network sample -e "DATABASE_TYPE=Postgres" -e "DATABASE_HOST=some-postgres" -e "DATABASE_PORT=5432" -e "DATABASE_NAME=sample" -e "DATABASE_USER=sample" -e "DATABASE_PASS=sample" --name sample31 sample31


echo "Executing .NET 6.0"

docker run --rm --network sample -e "DATABASE_TYPE=Postgres" -e "DATABASE_HOST=some-postgres" -e "DATABASE_PORT=5432" -e "DATABASE_NAME=sample" -e "DATABASE_USER=sample" -e "DATABASE_PASS=sample" --name sample6 sample6

docker rm some-postgres -f