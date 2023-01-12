# MovieFinder

Movie Finder is a web application that allows users to search for movies and view information about them. The back-end is written in ASP.NET Core 6 and it consumes a 3rd party API to fetch movie information. The front-end is written in React. The application is deployed at https://moviefinderfro-prod-moviefinder-4it03d.mo2.mogenius.io/

## Features

- Search for movies by name
- View information about the movie such as the image, release date, and name

## Technologies

- ASP.NET Core 6
- React
- Docker (for containerization)
- 3rd party API for movie information

## Deployment

The application is currently deployed to https://moviefinderfro-prod-moviefinder-4it03d.mo2.mogenius.io/

## Running the application locally

1. Clone the repository

git clone https://github.com/ozturksalih/MovieFinder.git

2. Build the containers

```docker-compose build```

3. Start the containers

```docker-compose up```

4. The application should now be running on `http://localhost:3000`

## Contributions

If you would like to contribute to the project, please fork the repository and submit a pull request with your changes.





