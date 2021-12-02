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

        /*let persons = ko.observableArray([]);


        ds.getAllPersons(data => {
            console.log(data.$values[0]);
            persons(data.$values[11]);
        });*/

        let selectedPerson = ko.observable();
        let personData = ko.observable();
        
        let getPerson = () => {
            ds.getPerson(selectedPerson(), function(data) {
            console.log(data);
            personData(data);
        })};

        let knownfor = ko.observable([]);

        let getKnownFor = () => {
        ds.knownFor(selectedPerson(), function(data) {
            console.log(data.$values);
            knownfor(data.$values);
        })};

        
        let coactors = ko.observable([]);

        let getCoActors = () => {
        ds.coactors(selectedPerson(), function(data) {
            console.log(data.$values);
            coactors(data.$values);
        })};

        
        let personsbyyear = ko.observable([]);

        let getPersonByYear = () => {
        ds.personYear(selectedPerson(), function(data) {
            console.log(data.$values);
            personsbyyear(data.$values);
        })};

        
        let title = ko.observable();
        //titles viewmodels
        let getSingleTitle = () => {
        ds.getTitle(selectedPerson(), function(data) {
            console.log(data);
            title(data);
        })};
        
        /*
        let cast = ko.observable([]);
        ds.getCast(data => {
            cast(data);
        });
           */
        
        let crew = ko.observable([]);
        let getTitleCrew = () => {
        ds.getCrew(selectedPerson(), function(data) {
            console.log(data.crew.$values)
            crew(data.crew.$values);
        })};

        let titleRating = ko.observable();
        
        let getTitleRating = () => {
        ds.getTitleRating(selectedPerson(), function(data) {
            console.log(data);
            titleRating(data);
        })};

        let titlesbyyear = ko.observable([]);
        ds.getTitlesByYear(data => {
            titlesbyyear(data);
        });
        
        let getTitlesByYear = () => {
        ds.getTitlesByYear(selectedPerson(), function(data) {
            console.log(data.$values);
            titlesbyyear(data.$values);
        })};
        

        /*************************************************/

        /**
        * Public functions.
        */
        return {
            /*persons*/
            selectedPerson,
            getPerson,
            personData,
            getKnownFor,
            knownfor,
            getCoActors,
            coactors,
            getPersonByYear,
            personsbyyear,
            
            
            /*titles*/
            title,
            getSingleTitle,
            crew,
            getTitleCrew,
            titleRating,
            getTitleRating,
            titlesbyyear,
            getTitlesByYear,
            
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