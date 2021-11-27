define([], () => {
    let titlesUrl = "localhost:5001/titles/"
    let episodesUrl = "localhost:5001/episodes/" 
    let genreUrl = "localhost:5001/genres/"
    let userUrl = "localhost:5001/url/"
    
    let getMoviesBetween = (callback, startYear, endYear) => {
        fetch(titlesUrl + "between/" + startYear + "/" + endYear)
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    let getAdultTitles = (callback) => {
        fetch(titlesUrl + "adult")
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    let getEpisodesForMovie = (callback, id) => {
        fetch(titlesUrl + id + "/episodes")
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    let getEpisode = (callback, id) => {
        fetch(episodesUrl + id)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getEpisodeCast = (callback, id) => {
        fetch(episodesUrl + id + "/cast")
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getEpisodeCrew = (callback, id) => {
        fetch(episodesUrl + id + "/crew")
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getEpisodeRating = (callback, id) => {
        fetch(episodesUrl + id + "/rating")
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getMovieByGenre = (callback, id) => {
        fetch(genreUrl + id)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getAllGenres = (callback) => {
        fetch(genreUrl)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getUser = (callback, id) => {
        fetch(userUrl + id)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getAllUsers = (callback, id) => {
        fetch(userUrl)
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    let getUserRatings = (callback, id) => {
        fetch(userUrl + id + "/ratings")
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    
    return {
        getMoviesBetween: getMoviesBetween,
        getAdultTitles: getAdultTitles,
        getEpisodesForMovie: getEpisodesForMovie,
        getEpisode: getEpisode,
        getEpisodeCast: getEpisodeCast,
        getEpisodeCrew: getEpisodeCrew,
        getEpisodeRating: getEpisodeRating,
        getMovieByGenre: getMovieByGenre,
        getAllGenres: getAllGenres,
        getUser: getUser,
        getAllUsers: getAllUsers,
        
        
        
        
               
                
        
    }
});