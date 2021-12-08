define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let username = ko.observable("ruc");
            let email = ko.observable("ruc");
            let password = ko.observable("ruc");

            /**
             * Connecting from model (Register button) to data service
             */
            let register = () => {
                auth.imdb_auth.register(username(), email(), password(), function (status) {
                    console.log(status);
                });
            }

            return {
                username,
                email,
                password,
                register
            }
        };
    });