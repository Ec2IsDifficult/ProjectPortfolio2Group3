define(["knockout", "authservice", "viewmodel"],
    function (ko, auth, vm) {

        return function () {

            let username = ko.observable("ruc1");
            let email = ko.observable("test@ruc.dk");
            let password = ko.observable("ruc");

            let loginMessage = ko.observable("");

            /**
             * Connecting from model (Login button) to data service
             */
            let login = () => {
                console.log("Login process");
                loginMessage("");
                auth.imdb_auth.login(username(), password(), function (status, token) {
                    if (status == "OK") {
                        vm.loginOK(false);
                        $('#loginModal').modal('hide');
                    } else {
                        loginMessage(status);
                    }
                });
            }

            console.log("Login component loaded");

            return {
                username,
                email,
                password,
                login,
                loginMessage
            }
        };
    });