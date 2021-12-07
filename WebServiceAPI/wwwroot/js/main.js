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
});

require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});