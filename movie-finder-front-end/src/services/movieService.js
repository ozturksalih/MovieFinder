
import axios from "axios";

export default class MovieService{
    async getSearchedMovies(searchedValue){

        try {
            const response = await axios.get(`https://moviefinderbac-prod-moviefinder-4it03d.mo2.mogenius.io/api/Movies/getBySearch?searchedWord=${searchedValue}`);
            return response;
          } catch (error) {
            console.error(error);
          }

    }
}