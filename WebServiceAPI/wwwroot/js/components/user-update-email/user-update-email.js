define(["knockout", "authservice", "bootstrap", "jquery"],
    function (ko, auth) {

        return function (params) {

            let email = ko.observable("ruc");

            let updateEmailMessage = ko.observable("");

            /**
             * Connecting from model (Update email: change) to data service
             */
            let updateEmail = () => {
                auth.imdb_auth.updateEmail(email(), function (status) {
                    if (status == "OK") {
                        $('#updateEmailModal').modal('hide');
                    } else {
                        updateEmailMessage(status);
                    }
                });
            }

            return {
                email,
                updateEmail,
                updateEmailMessage
            }
        };
    });