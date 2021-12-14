define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let username = ko.observable("ruc");
            let email = ko.observable("ruc");
            let password = ko.observable("ruc");

            let registerMessage = ko.observable("Fill the form below and submit");

            /**
             * Connecting from model (Register button) to data service
             */
            let register = () => {
                auth.imdb_auth.register(username(), email(), password(), function (result) {

                    switch (result.status) {
                        case 200:
                            result.text().then(function (text) {
                                registerMessage("Registered successfully.");
                                console.log(text);
                            });
                            break;

                        case 400:
                            result.text().then(function (text) {
                                registerMessage("Username already taken.");
                                console.log(text);
                            });
                            break;

                        default:
                            registerMessage("Unknown error");

                    }

                });
            }

            return {
                username,
                email,
                password,
                register,
                registerMessage
            }
        };
    });