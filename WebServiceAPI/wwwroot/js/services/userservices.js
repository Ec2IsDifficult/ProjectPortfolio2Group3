define(["ApiConfig", "authservice"], (ApiConfig, auth) => {

    let imdb_user = (function () {

        /**
         * API Rate: Rate a movie
         * Returns status (201, 400)
         * Returns statusText
         * @param {string} tconst
         * @param {string} rating expected to be only integer 1-10
         */
        function rate(tconst, rating, callback) {

            let obj = {
                tconst: tconst,
                rating: rating
            }

            token = auth.imdb_auth.getCookie("token");

            let param = {
                method: "POST",
                body: JSON.stringify(obj),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + token
                }
            }

            console.log("Calling: User services - Rate a title");

            fetch(ApiConfig.ApiUserRate, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "201") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            callback(result.statusText);
                        });
                    }

                    // Bad request
                    // Username already exist
                    if (result.status == "400") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            callback(text);
                        });
                    }
                });
        };

        /**
        * Public functions.
        */
        return {
            rate: rate
        }
    })();

    return {
        imdb_user
    }
});