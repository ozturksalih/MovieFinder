import React, { useState } from 'react';
import { Input, Button, Card, Image, Grid } from 'semantic-ui-react';
import MovieService from "../services/movieService";

export default function MovieSearch() {
  const [searchTerm, setSearchTerm] = useState('');
  const [movies, setMovies] = useState([]);


  async function handleSearch(e) {
    e.preventDefault();
    try {
      let movieService = new MovieService()
      movieService.getSearchedMovies(searchTerm).then(result => setMovies(result.data))
    } catch (error) {
      console.error(error);
    }
  }


  return (

    <Grid>
      <Grid.Row>
        <Grid.Column>
          <form onSubmit={handleSearch} style={{ textAlign: 'center', margin: '2em 0' }}>
            <Input
              placeholder="search here"
              type="text"
              value={searchTerm}
              onChange={e => setSearchTerm(e.target.value)}
              style={{ width: '50%' }}
            />
            <Button type="submit" primary>Search</Button>
          </form>
        </Grid.Column>
      </Grid.Row>
      <Grid.Row>
        <Card.Group itemsPerRow={4}>
          {movies.map(movie => (
            <Card key={movie.id} style={{ width: '20%', margin: '1em' }}>
              <Image src={movie.imagePath} wrapped ui={false} />
              <Card.Content>
                <Card.Header>{movie.title}</Card.Header>
                <Card.Meta>Release Date: {movie.releaseDate}</Card.Meta>
              </Card.Content>

            </Card>
          ))}
        </Card.Group>
      </Grid.Row>
    </Grid>


  );
}