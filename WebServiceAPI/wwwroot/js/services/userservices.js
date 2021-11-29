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
                });
        };

        /**
         * API Rate: Get reviews made by user
         * Returns status (201, 400, 401)
         * Returns statusText
         * @param {Function} callback
         */
        function getReviews(callback) {

            token = auth.imdb_auth.getCookie("token");

            let param = {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + token
                }
            }

            console.log("Calling: User services - Get reviews");

            fetch(ApiConfig.ApiUserGetReviews, param)
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
         * API Rate: Add/update a review for a title
         * Returns status (201, 400, 401)
         * Returns statusText
         * @param {Function} callback
         */
        function updateReviewTitle(tconst, review, callback) {

            let obj = {
                tconst: tconst,
                review: review
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

            console.log("Calling: User services - Add/update a review");

            fetch(ApiConfig.ApiUserGetReviews, param)
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
        * Public functions.
        */
        return {
            rate: rate,
            getReviews: getReviews
        }
    })();

    return {
        imdb_user
    }
});