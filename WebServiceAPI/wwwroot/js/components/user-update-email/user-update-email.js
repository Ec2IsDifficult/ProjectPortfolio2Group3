define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let email = ko.observable("ruc");

            /**
             * Connecting from model (Update email: change) to data service
             */
            let updateEmail = () => {
                auth.imdb_auth.updateEmail(email(), function (status) {
                    console.log(status);
                });
            }

            return {
                email,
                updateEmail
            }
        };
    });