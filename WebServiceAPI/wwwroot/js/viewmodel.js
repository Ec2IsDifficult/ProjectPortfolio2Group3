define(["knockout", "dataservice", "authservice", "userservice", "AppConfig", "Sammy"],
    function (ko, ds, auth, user, AppConfig, Sammy) {

        /**
         * Application configuration
         */

        let appName = AppConfig.appName;

        /**
         * Initialization
         */

        let componentItems = [
            {
                title: "Register",
                component: "user-register",
                hash: "#register",
            },
            {
                title: "Login",
                component: "user-login",
                hash: "#login"
            },
            {
                title: "Recover",
                component: "user-recover",
                hash: "#recover",
            },
            {
                title: "Update Email",
                component: "user-update-email",
                hash: "#email",
            }
        ];

        let currentView = ko.observable(componentItems[0].component);
        let currentParams = ko.observable({});

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

        let searchPhrase = ko.observable("Harry Potter");

        /**
         * Connecting from model (Rating a title) to data service
         */
        let rateTitle = () => {
            user.imdb_user.rate(tconst(), rate(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Get all reviews made by this user) to data service
         */
        let getReviews = () => {
            user.imdb_user.getReviews(function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (Review a title) to data service
         */
        let updateReviewTitle = () => {
            user.imdb_user.updateReviewTitle(tconst(), reviewTitle(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (User search phrase) to data service
         */
        let userSearchPhrase = () => {
            user.imdb_user.userSearchPhrase(searchPhrase(), function (status) {
                console.log(status);
            });
        }

        /**
         * Connecting from model (User load search phrase) to data service
         */
        let userLoadSearchHistory = () => {
            user.imdb_user.userLoadSearchHistory(function (status) {
                console.log(status);
                console.log(status[0]);
            });
        }

        /*************************************************/
        /**
         * Janik
         */

        /*
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
        */

        /*************************************************/

        let singleItem = componentItems.find(item => item.hash == "#login");

        Sammy(function () {
            this.get('#:view', function () {
                singleItem = componentItems.find(item => item.hash == "#" + this.params.view)
                if (singleItem !== undefined || singleItem.length != 0) {
                    currentView(singleItem.component);
                }
            });
        }).run(singleItem.hash);

        /**
        * Public functions.
        */
        return {
            appName,
            componentItems,

            currentView,
            currentParams,

            /* User Auth */
            //username,
            //email,
            //password,
            logout,

            /* User IMDB */
            tconst,
            rate,
            rateTitle,
            reviewTitle,
            getReviews,
            updateReviewTitle,

            /* User search */
            searchPhrase,
            userSearchPhrase,
            userLoadSearchHistory

        }
    });