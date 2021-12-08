define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let password = ko.observable("ruc");

            /**
             * Connecting from model (Recover password: change) to data service
             */
            let recover = () => {
                auth.imdb_auth.recover(password(), function (status) {
                    console.log(status);
                });
            }

            return {
                password,
                recover
            }
        };
    });