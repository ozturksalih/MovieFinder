import './App.css';
import { Container } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css';

import MovieSearch from './pages/MovieSearch';
function App() {
  return (
    <div className="App">
        <Container className="main">
            <MovieSearch/>
        </Container>
    </div>
  );
}

export default App;
