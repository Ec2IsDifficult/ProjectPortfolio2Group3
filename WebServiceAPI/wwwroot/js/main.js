require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        text: "lib/requirejs/text",
        bootstrap: "../css/lib/bootstrap/dist/js/bootstrap.bundle.min",
        dataservice: "services/dataservices",
        authservice: "services/authservices",
        userservice: "services/userservices",
        ApiConfig: "config/ApiConfig",
        AppConfig: "config/AppConfig",
    }
});

/**
 * Component registration
 */
require(['knockout'], (ko) => {
    ko.components.register("user-login", {
        viewModel: { require: "components/user-login/user-login" },
        template: { require: "text!components/user-login/user-login.html" }
    });
    ko.components.register("title-card-list", {
        viewModel: { require: "components/title-card-list/title-card-list" },
        template: { require: "text!components/title-card-list/title-card-list.html" }
    });
    ko.components.register("person-card-list", {
        viewModel: { require: "components/person-card-list/person-card-list" },
        template: { require: "text!components/person-card-list/person-card-list.html" }
    });
    ko.components.register("front-page", {
        viewModel: { require: "components/front-page/front-page" },
        template: { require: "text!components/front-page/front-page.html" }
    });
});





require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});