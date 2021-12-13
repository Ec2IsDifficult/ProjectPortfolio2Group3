define(["ApiConfig"], (ApiConfig) => {

    /**
     * From Rasmus
     */
    let titlesUrl = "localhost:5001/api/titles/"
    let episodesUrl = "localhost:5001/api/episodes/"
    let genreUrl = "localhost:5001/api/genres/"
    let userUrl = "localhost:5001/api/url/"
    let peopleUrl = "localhost:5001/api/person/"

    let getMoviesBetween = (callback, startYear, endYear) => {
        console.log(ApiConfig.ApiTitles + "between/" + startYear + "/" + endYear);
        fetch(ApiConfig.ApiTitles + "between/" + startYear + "/" + endYear)
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
    
    let getRandomTitles = async function(callback, amount, lowestRating) {
        await fetch(`${ApiConfig.ApiRandomTitles}${amount}/${lowestRating}`)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getRandomPeople = async function(callback, amount) {
        await fetch(`${ApiConfig.ApiRandomPeople}${amount}`)
            .then(response => response.json())
            .then(json => callback(json));
    }
    
    let getAllGenres = function(callback) {
        fetch(`${ApiConfig.ApiGenres}`)
            .then(response => response.json())
            .then(json => callback(json))
    }

    /**
     * From Janik
     */

    /*
    let getAllPersons = (callback) => {
    fetch("api/person")
     .then(response => response.json())
     .then(json => callback(json));
    };*/
    
    
    function getPerson(nconst, callback) {
            fetch("api/person/" + nconst)
                .then(response => response.json())
                .then(json => callback(json))
    };
    
    function knownFor(nconst, callback) {
    fetch("api/person/"+nconst+"/knownfor")
     .then(response => response.json())
     .then(json => callback(json))
        console.log("api/person/"+nconst+"/knownfor");
    };
    
    
    function coactors(name, callback) {
    fetch("api/person/"+name+"/coactors")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    
    function personYear (year, callback) {
    fetch("api/person/year/"+year)
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getPoster(url){
        const response = await fetch(url);
        const blob = await response.blob();
        const _url = URL.createObjectURL(blob);
        let image = document.getElementById("Poster");
        image.setAttribute("src", _url);
        image.setAttribute('class', 'img-fluid');
        image.setAttribute('alt','Responsive image');
        return image;
    };
    
    /*
    function getAllTitles (callback)  {
    fetch("api/titles")
     .then(response => response.json())
     .then(json => callback(json))
    };
     */
    
    async function getTitle (tconst,  callback) {
    fetch("api/titles/"+tconst)
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    function getCast(tconst, callback) {
    fetch("api/titles/"+tconst+"/cast")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getCrew(tconst, callback) {
    fetch("api/titles/"+tconst+"/crew")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    
    async function getTitleRating (tconst, callback) {
    fetch("api/titles/"+tconst+"/rating")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    
    async function getTitlesByYear (callback, year) {
    fetch(`${ApiConfig.ApiTitleByYear}${year}`)
     .then(response => response.json())
     .then(json => callback(json))
    };
    


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

        //getAllPersons: getAllPersons,
        getPerson: getPerson,
        knownFor: knownFor,
        coactors: coactors,
        personYear: personYear,
        getTitle: getTitle,
        getCrew: getCrew,
        getTitleRating: getTitleRating,
        getTitlesByYear: getTitlesByYear,
        getPoster: getPoster,
        getCast: getCast,
        

        getUserRating: getUserRatings,
        getRandomTitles: getRandomTitles,
        getRandomPeople: getRandomPeople,

        /* from Janik
        getPerson,
        getAllPersons,
        knownfor,
        coactors,
        year,
        getAllTitles,
        getTitle,
        getCast,
        getCrew,
        getTitleRating,
        getTitlesByYear
        */
    }
});