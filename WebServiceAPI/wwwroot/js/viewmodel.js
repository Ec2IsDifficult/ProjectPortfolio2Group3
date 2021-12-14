define(["knockout", "dataservice", "authservice", "userservice", "AppConfig", "Sammy"],
    function (ko, ds, auth, user, AppConfig, Sammy) {


        /**
         * Application configuration
         */

        let appName = AppConfig.appName;

        /**
         * Toggling the login/logout navbar
         */

        let loginOK = ko.observable(true);

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
            },
            {
                title: "Update Password",
                component: "user-update-password",
                hash: "#UpdatePassword",
            },
            {
                title: "Front page",
                component: "front-page",
                hash: "#FrontPage",
            },
            {
                title: "Title logic page",
                component: "title-logic-page",
                hash: "#Titles",
            },
            {
                title: "Person logic page",
                component: "person-logic-page",
                hash: "#People",
            }

        ];

        // Main view
        c = componentItems.find(item => item.component == "user-update-email");
        let currentView = ko.observable(c.component);

        // Main parameters
        let currentParams = ko.observable({});

        // Component: Login
        c = componentItems.find(item => item.component == "user-login");
        let loginPage = ko.observable(c.component);

        // Component: Update email
        c = componentItems.find(item => item.component == "user-update-email");
        let updateEmailComponent = ko.observable(c.component);
        
        // Component: Update password
        c = componentItems.find(item => item.component == "user-update-password");
        let updatePasswordComponent = ko.observable(c.component);

        

        /**
        * Connecting from model (logout) to data service
        */
        let logout = () => {
            console.log("Logging out");
            auth.imdb_auth.logout(function (status) {
                console.log(status);
                loginOK(true);
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


        /*let persons = ko.observableArray([]);


        ds.getAllPersons(data => {
            console.log(data.$values[0]);
            persons(data.$values[11]);
        });*/

        let selectedPerson = ko.observable('tt1954874');
        let personData = ko.observable();

        let getPerson = () => {
            ds.getPerson(selectedPerson(), function (data) {
                console.log(data);
                personData(data);
            })
        };

        let knownfor = ko.observable([]);

        let getKnownFor = () => {
            ds.knownFor(selectedPerson(), function (data) {
                console.log(data.$values);
                knownfor(data.$values);
            })
        };


        let coactors = ko.observable([]);

        let getCoActors = () => {
            ds.coactors(selectedPerson(), function (data) {
                console.log(data.$values);
                coactors(data.$values);
            })
        };


        let personsbyyear = ko.observable([]);

        let getPersonByYear = () => {
            ds.personYear(selectedPerson(), function (data) {
                console.log(data.$values);
                personsbyyear(data.$values);
            })
        };





        let cast = ko.observable([]);
        let getCast = () => {
            ds.getCast(selectedPerson(), function (data) {
                console.log(data);
                cast(data);
            })
        };



        let selectedTitle = ko.observable('tt1954874');

        let titleRating = ko.observable();

        let getTitleRating = () => {
            ds.getTitleRating(selectedPerson(), function (data) {
                console.log(data);
                titleRating(data);
            })
        };

        let crew = ko.observable([]);
        let getTitleCrew = async () => {
            await ds.getCrew(selectedPerson(), function (data) {
                console.log(data.crew)
                crew(data.crew);
            })
        };

        let title = ko.observable();
        //titles viewmodels
        let getSingleTitle = async () => {
            await ds.getTitle(selectedPerson(), async function (data) {
                console.log(data);
                title(data);
                if (data.awards !== null) {
                    await getTitlePoster(data.awards);
                }
            })
        };

        let getTitlePoster = async (_url) => {
            await ds.getPoster(_url);
        };



        let titlesbyyear = ko.observable([]);

        let getTitlesByYear = () => {
            ds.getTitlesByYear(selectedPerson(), function (data) {
                console.log(data.$values);
                titlesbyyear(data.$values);
            })
        };

        /*************************************************/

        let changeContent = menuItem => {
            console.log("Change view");
            currentParams({});
            window.location = menuItem.hash;
        };

        Sammy(function () {
            this.get('/#:view', function (eventContext) {

                let hashLink = eventContext.path.split("#");

                singleItem = componentItems.find(item => {
                    return item.hash == "#" + hashLink[1];
                });

                if (singleItem !== undefined && singleItem.length != 0) {
                    console.log("Sammy routing");
                    console.log(singleItem);
                    currentView(singleItem.component);
                }
            });

            this.get('', function () {
                this.app.runRoute('get', '/#Frontpage')
            });

        }).run();

        /*
         *
         * to use Sammy, in the component, call like this:
         * replace "page-event-name" with the component name

        vm.changeContent(vm.componentItems.find(item => item.component == "page-event-name"));

        <a href="#hashes"....></a>
        */

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
            titlesbyyear,
            getTitlesByYear,
            titleRating,
            getTitleRating,
            cast,
            getCast,


            appName,
            componentItems,

            changeContent,
            currentView,
            currentParams,

            loginPage,
            loginOK,

            updateEmailComponent,
            updatePasswordComponent,


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