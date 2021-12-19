define(["ApiConfig", "authservice"], (ApiConfig, auth) => {

    /**
     * From Rasmus
     */
    let titlesUrl = "localhost:5001/api/titles/"
    let episodesUrl = "localhost:5001/api/episodes/"
    let genreUrl = "localhost:5001/api/genres/"
    let userUrl = "localhost:5001/api/url/"
    
    
    let searchTitles = (callback, searchPhrase) => {
        fetch(`${ApiConfig.ApiTitles}searchPhrase=${searchPhrase}`)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let getMoviesBetween = (callback, startYear, endYear, ApiPath = null) => {
        let path = "";
        if(ApiPath != null)
            path = ApiPath
        else
            path = ApiConfig.ApiTitles + "between/" + startYear + "/" + endYear
        fetch(path)
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

    let getMovieByGenre = (callback, moviename) => {
        fetch(genreUrl + moviename)
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
            fetch("api/v1/person/" + nconst)
                .then(response => response.json())
                .then(json => callback(json))
    };
    
    function knownFor(nconst, callback) {
    fetch("api/v1/person/"+nconst+"/knownfor")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    function primeProfessions(nconst, callback) {
        fetch("api/v1/person/"+nconst+"/primeProfessions")
            .then(response => response.json())
            .then(json => callback(json))
    };
    
    
    function coactors(nconst, callback) {
    fetch("api/v1/person/"+nconst+"/coactors")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    
    function personYear(year, callback) {
    fetch("api/v1/person/year/"+year)
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getPoster(url){
        console.log(await fetch(url));
        const response = await fetch(url);
        const blob = await response.blob();
        const _url = URL.createObjectURL(blob);
        let image = document.getElementById("Poster");
        image.setAttribute("src", _url);
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
    fetch("api/v1/titles/"+tconst)
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    function getCast(tconst, callback) {
    fetch("api/v1/titles/"+tconst+"/cast")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getCrew(tconst, callback) {
    fetch("api/v1/titles/"+tconst+"/crew")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getTitleRating (tconst, callback) {
    fetch("api/v1/titles/"+tconst+"/rating")
     .then(response => response.json())
     .then(json => callback(json))
    };
    
    async function getTitlesByYear (callback, year) {
    fetch(`${ApiConfig.ApiTitleByYear}${year}`)

     .then(response => response.json())
     .then(json => callback(json))
    };

    /**
    * API getUserBookmarkedTitles
    * Returns status (201, 400, 401, 405)
    * Returns statusText
    * @param {Function} callback
    */
    function getUserBookmarkedTitles(callback) {

        token = auth.imdb_auth.getCookie("token");

        let param = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }

        console.log("Calling: User services - Get bookmarked titles");

        fetch(ApiConfig.ApiUserBoookmarkedTitles, param)
            .then(function (result) {

                console.log(result.status);

                // Success
                if (result.status == "200") {
                    console.log(result.statusText);
                    result.text().then(function (text) {
                        console.log(text);
                        callback(JSON.parse(text));
                    });
                }

                // Bad request
                if (result.status == "400") {
                    console.log(result.statusText);
                    result.text().then(function (text) {
                        console.log(text);
                        callback(text);
                    });
                }

                // Unauthorized
                if (result.status == "401") {
                    console.log(result.statusText);
                    callback(result.statusText);
                }

                // Methods not allowed
                if (result.status == "405") {
                    console.log(result.statusText);
                    callback(result.statusText);
                }
            });
    };

    /**
    * API getUserBookmarkedTitles
    * Returns status (201, 400, 401, 405)
    * Returns statusText
    * @param {Function} callback
    */
    function getUserBookmarkedPerson(callback) {

        token = auth.imdb_auth.getCookie("token");

        let param = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }

        console.log("Calling: User services - Get bookmarked person");

        fetch(ApiConfig.ApiUserBoookmarkedPerson, param)
            .then(function (result) {

                console.log(result.status);

                // Success
                if (result.status == "200") {
                    console.log(result.statusText);
                    result.text().then(function (text) {
                        console.log(text);
                        callback(JSON.parse(text));
                    });
                }

                // Bad request
                if (result.status == "400") {
                    console.log(result.statusText);
                    result.text().then(function (text) {
                        console.log(text);
                        callback(text);
                    });
                }

                // Unauthorized
                if (result.status == "401") {
                    console.log(result.statusText);
                    callback(result.statusText);
                }

                // Methods not allowed
                if (result.status == "405") {
                    console.log(result.statusText);
                    callback(result.statusText);
                }
            });
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
        primeProfessions: primeProfessions,


        getUserRating: getUserRatings,
        getRandomTitles: getRandomTitles,
        getRandomPeople: getRandomPeople,
        searchTitles: searchTitles,

        getUserBookmarkedTitles,
        getUserBookmarkedPerson

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