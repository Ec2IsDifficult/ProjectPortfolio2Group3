define(["knockout", "dataservice", "authservice", "userservice"],
    function (ko, ds, auth, user) {

        let username = ko.observable("ruc1");
        let email = ko.observable("test@ruc.dk");
        let password = ko.observable("ruc");

        /**
         * Connecting from model (Register button) to data service
         */
        let register = () => {
            auth.imdb_auth.register(username(), email(), password(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Login button) to data service
         */
        let login = () => {
            auth.imdb_auth.login(username(), password(), function (status, token) {
                console.log(status);
                console.log(token);
            });
        }

        /**
         * Connecting from model (Recover password: change) to data service
         */
        let recover = () => {
            auth.imdb_auth.recover(password(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Recover password: change) to data service
         */
        let updateEmail = () => {
            auth.imdb_auth.updateEmail(email(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Recover password: change) to data service
         */
        let logout = () => {
            auth.imdb_auth.logout(function (status) {
                console.log(status);
            });
        }

        /*************************************************/

        let tconst = ko.observable("tt10850402");
        let rate = ko.observable("3");

        let reviewTitle = ko.observable("Best movie ever!");

        /**
         * Connecting from model (Rating a title) to data service
         */
        let rateTitle = () => {
            user.imdb_user.rate(tconst(), rate(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Rating a title) to data service
         */
        let getReviews = () => {
            user.imdb_user.getReviews(function (status) {
                console.log(status);
            });
        }

        /*************************************************/
        /**
         * Janik
         */

        let person = ko.observable();

        ds.getPerson(data => {
            person(data);
        });

        let persons = ko.observable([]);

        ds.getAllPersons(data => {
            persons(data);
        });


        let knownfor = ko.observable([]);

        ds.knownfor(data => {
            knownfor(data);
        });

        let coactors = ko.observable([]);

        ds.coactors(data => {
            coactors(data);
        });

        let personsbyyear = ko.observable([]);

        ds.year(data => {
            personsbyyear(data);
        });

        let alltitles = ko.observable([]);
        //titles viewmodels
        ds.getAllTitles(data => {
            alltitles(data);
        });

        let title = ko.observable();
        ds.getTitle(data => {
            title(data);
        });

        let cast = ko.observable([]);
        ds.getCast(data => {
            cast(data);
        });

        let crew = ko.observable([]);
        ds.getCrew(data => {
            crew(data);
        });

        let titleRating = ko.observable();
        ds.getTitleRating(data => {
            titleRating(data);
        });

        let titlesbyyear = ko.observable([]);
        ds.getTitlesByYear(data => {
            titlesbyyear(data);
        });

        /*************************************************/

        /**
        * Public functions.
        */
        return {
            /* User Auth */
            username,
            email,
            password,
            register,
            login,
            recover,
            updateEmail,
            logout,

            /* User IMDB */
            tconst,
            rate,
            rateTitle,
            reviewTitle,
            getReviews

        }
    });