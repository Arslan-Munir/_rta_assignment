#!/bin/bash

# Load database connection info
source ../.env

# If psql is not installed, then exit
if ! command -v psql > /dev/null; then
  echo "PostgreSQL is required..."
  read
fi

echo "Creating Schema"

# Connect to the database, run the query, then disconnect
PGPASSWORD="$POSTGRES_PASSWORD" psql -t -A \
-h "$POSTGRES_HOST" \
-p "$POSTGRES_PORT" \
-d "$POSTGRES_DATABASE" \
-U "$POSTGRES_USERNAME" \
-f "_main.sql" \

echo "Schema run. Enter to quiet..."
read
