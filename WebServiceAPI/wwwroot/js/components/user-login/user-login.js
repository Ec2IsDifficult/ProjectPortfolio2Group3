define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let username = ko.observable("ruc1");
            let email = ko.observable("test@ruc.dk");
            let password = ko.observable("ruc");

            /**
             * Connecting from model (Login button) to data service
             */
            let login = () => {
                console.log("Login process");
                auth.imdb_auth.login(username(), password(), function (status, token) {
                    console.log(status);
                    console.log(token);
                });
            }

            return {
                username,
                email,
                password,
                login
            }
        };
    });