//import {publish} from "./services/pub-sub";

define(["knockout", "dataservice", "authservice", "userservice", "AppConfig", "Sammy", "pubsub"],
    function (ko, ds, auth, user, AppConfig, Sammy, Ps) {


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
            }
        ];

        let currentView = ko.observable(componentItems[0].component);
        let currentParams = ko.observable({});
        
        let searchResult = ko.observable("search-result")
        
        //let searchPhrase = document.getElementById("searchField");
        let search = () => {
            changeContent(componentItems.find(item => item.component === "search-result"));
            //Ps.publish("search_result_publish", searchPhrase.value);
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
        let personData = ko.observable();
        
        let getPerson = () => {
            ds.getPerson(selectedPerson(), function(data) {
            console.log(data);
            personData(data);
        })};

        let knownfor = ko.observable([]);
        let availableKnownFor = ko.observable();

        let getKnownFor = () => {
        ds.knownFor(selectedPerson(), function(data) {
            console.log(data);
            if(data.length > 0){
                availableKnownFor('True');
            }else{
                availableKnownFor('False');
            }
            knownfor(data);
        })};

        
        let coactors = ko.observable([]);
        let availableCoActors = ko.observable();

        let getCoActors = () => {
        ds.coactors(selectedPerson(), function(data) {
            console.log(data);
            if(data.length > 0){
                availableCoActors('True');
            }else{
                availableCoActors('False');
            }
            coactors(data);
        })};
        
        let professions = ko.observable();
        let getPrimeProfessions = () => {
            ds.primeProfessions(selectedPerson(), function(data) {
                console.log(data);
                let jobs = '';
                let i = 0;
                data.forEach( function(job) {
                    if(i === (data.length - 1)){
                        jobs += job.profession;
                    }else{
                    jobs += job.profession+', ';
                    i++;
                }});
                professions(jobs);
            })
        }
        
        let personsbyyear = ko.observable([]);

        let getPersonByYear = () => {
        ds.personYear(selectedPerson(), function(data) {
            console.log(data.$values);
            personsbyyear(data.$values);
        })};

        
        
        
        
        let cast = ko.observable([]);
        
        let getCast = () => {
        ds.getCast(selectedPerson(),function(data) {
            console.log(data.cast);
            cast(data.cast);
        })};
           


        let selectedTitle = ko.observable('tt1954874');

        let titleRating = ko.observable();
        let checkVotes = ko.observable('False');

        let getTitleRating = () => {
            ds.getTitleRating(selectedPerson(), function (data) {
                if(data.numVotes > 0){
                    checkVotes('True');
                }
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
            })};

        let getTitlePoster = async (_url) => {
            await ds.getPoster(_url);
        };

        //let posterHeight = ko.observable(document.getElementById("PosterDiv").clientHeight);
        let titlesbyyear = ko.observable([]);
        
        let getTitlesByYear = () => {
        ds.getTitlesByYear(selectedPerson(), function(data) {
            console.log(data.$values);
            titlesbyyear(data.$values);
        })};
        

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
                this.app.runRoute('get', '/#login')
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
            availableKnownFor,
            availableCoActors,
            selectedPerson,
            getPerson,
            personData,
            getKnownFor,
            knownfor,
            getCoActors,
            coactors,
            getPersonByYear,
            personsbyyear,
            getPrimeProfessions,
            professions,
            
            
            /*titles*/
           // posterHeight,
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
            checkVotes,
            
            
            appName,
            componentItems,

            changeContent,
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
            userSearchPhrase,
            userLoadSearchHistory,

            search,
            searchResult

        }
    });