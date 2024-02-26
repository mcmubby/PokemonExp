# API Documentation

## Introduction

This API provides endpoints to manage Pokemons.
To get started, run `docker compose up` from `src/` directory
Once both services are up, navigate to [localhost:5000](http://localhost:5000/swagger/index.html) to access the swagger page or follow the details below for endpoint testing

## Base URL

The base URL for all endpoints is `/api/v1`.

## Pokemons

### Create a new pokemon

- **URL**: `/pokemons`
- **Method**: `POST`
- **Description**: Create a new pokemon.
- **Request Body**:
  - Content-Type: `application/json`
  - Schema:
    ```json
    {
        "number": integer,
        "name": string,
        "type1": string,
        "type2": string,
        "total": integer,
        "hp": integer,
        "attack": integer,
        "defense": integer,
        "specialAttack": integer,
        "specialDefense": integer,
        "speed": integer,
        "generation": integer,
        "legendary": boolean
    }
    ```
- **Response**:
  - Status Code: 201 - Created
  - Status Code: 400 - Bad Request

### Get a paginated list of all pokemons available on the database

- **URL**: `/pokemons`
- **Method**: `GET`
- **Description**: Get a paginated list of all pokemons available on the database.
- **Parameters**:
  - `page` (optional): The page number (default: 1)
  - `pageSize` (optional): The page size (default: 20)
- **Response**:
  - Status Code: 200 - OK
    - Content-Type: `application/json`
    - Schema:
      ```json
      {
          "pokemons": [
              {
                  "id": integer,
                  "number": integer,
                  "name": string,
                  "type1": string,
                  "type2": string,
                  "total": integer,
                  "hp": integer,
                  "attack": integer,
                  "defense": integer,
                  "specialAttack": integer,
                  "specialDefense": integer,
                  "speed": integer,
                  "generation": integer,
                  "legendary": boolean
              }
          ],
          "page": integer,
          "pageSize": integer,
          "totalCount": integer,
          "hasNextPage": boolean,
          "hasPreviousPage": boolean
      }
      ```

### Update a pokemon using system assigned id as key. Full payload required.

- **URL**: `/pokemons`
- **Method**: `PUT`
- **Description**: Update a pokemon using system assigned id as key. Full payload required.
- **Request Body**:
  - Content-Type: `application/json`
  - Schema:
    ```json
    {
        "id": integer,
        "number": integer,
        "name": string,
        "type1": string,
        "type2": string,
        "total": integer,
        "hp": integer,
        "attack": integer,
        "defense": integer,
        "specialAttack": integer,
        "specialDefense": integer,
        "speed": integer,
        "generation": integer,
        "legendary": boolean
    }
    ```
- **Response**:
  - Status Code: 200 - OK
  - Status Code: 400 - Bad Request

### Get all pokemons from a specific generation

- **URL**: `/pokemons/generation/{generation}`
- **Method**: `GET`
- **Description**: Get all pokemons from a specific generation. Records for generation 1 to 6 available.
- **Parameters**:
  - `generation` (required): The generation number (1 to 6)
  - `page` (optional): The page number (default: 1)
  - `pageSize` (optional): The page size (default: 20)
- **Response**:
  - Status Code: 200 - OK
    - Content-Type: `application/json`
    - Schema:
      ```json
      {
          "pokemons": [
              {
                  "id": integer,
                  "number": integer,
                  "name": string,
                  "type1": string,
                  "type2": string,
                  "total": integer,
                  "hp": integer,
                  "attack": integer,
                  "defense": integer,
                  "specialAttack": integer,
                  "specialDefense": integer,
                  "speed": integer,
                  "generation": integer,
                  "legendary": boolean
              }
          ],
          "page": integer,
          "pageSize": integer,
          "totalCount": integer,
          "hasNextPage": boolean,
          "hasPreviousPage": boolean
      }
      ```
  - Status Code: 404 - Not Found

### Get a pokemon using its system assigned id

- **URL**: `/pokemons/{id}`
- **Method**: `GET`
- **Description**: Get a pokemon using its system assigned id.
- **Parameters**:
  - `id` (required): The pokemon ID
- **Response**:
  - Status Code: 200 - OK
    - Content-Type: `application/json`
    - Schema:
      ```json
      {
          "id": integer,
          "number": integer,
          "name": string,
          "type1": string,
          "type2": string,
          "total": integer,
          "hp": integer,
          "attack": integer,
          "defense": integer,
          "specialAttack": integer,
          "specialDefense": integer,
          "speed": integer,
          "generation": integer,
          "legendary": boolean
      }
      ```
  - Status Code: 404 - Not Found

### Delete a pokemon using system assigned id as key.

- **URL**: `/pokemons/{id}`
- **Method**: `DELETE`
- **Description**: Delete a pokemon using system assigned id as key.
- **Parameters**:
  - `id` (required): The pokemon ID
- **Response**:
  - Status Code: 200 - OK
  - Status Code: 404 - Not Found

### Get pokemon(s) with the pokemon #

- **URL**: `/pokemons/number/{number}`
- **Method**: `GET`
- **Description**: Get pokemon(s) with the pokemon number.
- **Parameters**:
  - `number` (required): The pokemon number
- **Response**:
  - Status Code: 200 - OK
    - Content-Type: `application/json`
    - Schema:
      ```json
      [
          {
              "id": integer,
              "number": integer,
              "name": string,
              "type1": string,
              "type2": string,
              "total": integer,
              "hp": integer,
              "attack": integer,
              "defense": integer,
              "specialAttack": integer,
              "specialDefense": integer,
              "speed": integer,
              "generation": integer,
              "legendary": boolean
          }
      ]
      ```
  - Status Code: 404 - Not Found
