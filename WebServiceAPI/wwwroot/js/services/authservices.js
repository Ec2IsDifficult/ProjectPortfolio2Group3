define(["ApiConfig"], (ApiConfig) => {

    let imdb_auth = (function () {

        /**
         * API Register
         * Returns status (200, 400)
         * Returns statusText
         * @param {string} username
         * @param {string} email
         * @param {string} password 
         */
        function register(username, email, password, callback) {

            let register_info = {
                username: username,
                email: email,
                password: password
            }

            let param = {
                method: "POST",
                body: JSON.stringify(register_info),
                headers: {
                    "Content-Type": "application/json"
                }
            }

            console.log("Calling register");

            fetch(ApiConfig.ApiUserRegister, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "200") {
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
         * API Login
         * Returns status (200, 400, 401)
         * Returns statusText and token
         * If status=200, then token is not empty
         * @param {string} username
         * @param {string} password 
         */
        function login(username, password, callback) {

            let login_info = { username: username, password: password }

            let param = {
                method: "POST",
                body: JSON.stringify(login_info),
                headers: {
                    "Content-Type": "application/json"
                }
            }

            console.log("Calling login");

            fetch(ApiConfig.ApiUserLogin, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "200") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            token = JSON.parse(text);
                            setCookie("token", token.token, 7);
                            callback(result.statusText, token.token);
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

                    // Login incorrect
                    if (result.status == "401") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            callback(text);
                        });
                    }

                });
        };

        /**
         * API Recover
         * Returns status (200, 400, 401)
         * Returns statusText
         * @param {string} password 
         */
        function recover(password, callback) {

            let register_info = {
                password: password
            }

            token = getCookie("token");

            let param = {
                method: "POST",
                body: JSON.stringify(register_info),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + token
                }
            }

            console.log("Calling recover");

            fetch(ApiConfig.ApiUserRecover, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "200") {
                        console.log(result.statusText);
                        callback(result.statusText);
                    }

                    // Bad request
                    if (result.status == "400") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            callback(text);
                        });
                    }

                    // Aunthorized
                    if (result.status == "401") {
                        console.log(result.statusText);
                        callback(result.statusText);
                    }
                });
        };

        /**
         * API Update Email
         * Returns status (200, 400, 401)
         * Returns statusText
         * @param {string} email 
         */
        function updateEmail(email, callback) {

            let register_info = {
                email: email
            }

            token = getCookie("token");

            let param = {
                method: "POST",
                body: JSON.stringify(register_info),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + token
                }
            }

            console.log("Calling update email");

            fetch(ApiConfig.ApiUserUpdateEmail, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "200") {
                        console.log(result.statusText);
                        callback(result.statusText);
                    }

                    // Bad request
                    if (result.status == "400") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            callback(text);
                        });
                    }

                    // Aunthorized
                    if (result.status == "401") {
                        console.log(result.statusText);
                        callback(result.statusText);
                    }
                });
        };

        /**
         * API Logout
         * Returns status (200, 400, 401)
         * Returns statusText
         * @param {string} email 
         */
        function logout(callback) {

            token = getCookie("token");

            let param = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + token
                }
            }

            console.log("Calling logout");

            fetch(ApiConfig.ApiUserLogout, param)
                .then(function (result) {

                    console.log(result.status);

                    // Success
                    if (result.status == "200") {
                        console.log(result.statusText);
                        result.text().then(function (text) {
                            console.log(text);
                            token = JSON.parse(text);
                            setCookie("token", token.token, 7);
                            callback(result.statusText, token.token);
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

                    // Aunthorized
                    if (result.status == "401") {
                        console.log(result.statusText);
                        callback(result.statusText);
                    }
                });
        };

        /**
         * Save the token in cookie
         * Sourced from https://www.w3schools.com/js/js_cookies.asp
         */
        function setCookie(cname, cvalue, exdays) {
            const d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            let expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

        /**
         * Sourced from https://www.w3schools.com/js/js_cookies.asp
         */
        function getCookie(cname) {
            let name = cname + "=";
            let decodedCookie = decodeURIComponent(document.cookie);
            let ca = decodedCookie.split(';');
            for (let i = 0; i < ca.length; i++) {
                let c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }

        /**
        * Public functions.
        */
        return {
            register: register,
            login: login,
            recover: recover,
            updateEmail: updateEmail,
            logout: logout,
            getCookie: getCookie
        }
    })();

    return {
        imdb_auth
    }
});