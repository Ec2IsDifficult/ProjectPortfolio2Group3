//import {publish} from "./services/pub-sub";

define(["knockout", "dataservice", "authservice", "userservice", "AppConfig", "Sammy", "pubsub"],
    function (ko, ds, auth, user, AppConfig, Sammy, Ps) {


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
            },
            {
                title: "Classics Page",
                component: "classics-page",
                hash: "#Classics",
            },
            {
                title: "Search Result Page",
                component: "search-result",
                hash: "#SearchPage",
            },
            {
                title: "Titles By Year Page",
                component: "by-year-pages",
                hash: "#FromYear",
            }
            ,
            {
                title: "Search Result List",
                component: "search-result-list",
                hash: "#Search",
            },
            {
                title: "Title Page",
                component: "titles-page",
                hash: "#title"
            },
            {
                title: "Person Page",
                component: "person-page",
                hash: "#person"
            }
            
        ];

        // Main view
        c = componentItems.find(item => item.component == "user-update-email");
        let currentView = ko.observable(c.component);

        // Main parameters
        let currentParams = ko.observable({});
        
        let searchResult = ko.observable("search-result")
        
        //let searchPhrase = document.getElementById("searchField");
        let search = () => {
            changeContent(componentItems.find(item => item.component === "search-result"));
            //Ps.publish("search_result_publish", searchPhrase.value);
        }
        
        

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
        //'tt1954874'
        

  
        let personsbyyear = ko.observable([]);

        let getPersonByYear = () => {
            ds.personYear(selectedPerson(), function (data) {
                console.log(data.$values);
                personsbyyear(data.$values);
            })
        };





      

        //let posterHeight = ko.observable(document.getElementById("PosterDiv").clientHeight);
        let titlesbyyear = ko.observable([]);

        let getTitlesByYear = () => {
            ds.getTitlesByYear(selectedPerson(), function (data) {
                console.log(data.$values);
                titlesbyyear(data.$values);
            })
        };

        /*************************************************/

        let changeContent = (menuItem) => {
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
            getPersonByYear,
            personsbyyear,
            
            

            /*titles*/
           // posterHeight,
            
            titlesbyyear,
            getTitlesByYear,
            

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
            userSearchPhrase,
            userLoadSearchHistory,

            search,
            searchResult

        }
    });