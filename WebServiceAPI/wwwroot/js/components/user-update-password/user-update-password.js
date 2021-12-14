define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let password = ko.observable("ruc");

            let updatePasswordMessage = ko.observable("");

            /**
             * Connecting from model (Update email: change) to data service
             */
            let updatePassword = () => {
                auth.imdb_auth.recover(password(), function (status) {
                    if (status == "OK") {
                        $('#updatePasswordModal').modal('hide');
                    } else {
                        updatePasswordMessage(status);
                    }
                });
            }

            return {
                password,
                updatePassword,
                updatePasswordMessage
            }
        };
    });