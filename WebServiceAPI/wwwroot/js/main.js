

require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        text: "lib/requirejs/text",
        Sammy: "lib/sammy/lib/min/sammy-0.7.6.min",
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


    let component_name = ["user-recover", "user-register"];
    component_name.forEach(registerComponent);

    function registerComponent(component_name) {
        ko.components.register(component_name, {
            viewModel: { require: "components/" + component_name + "/" + component_name },
            template: {
                require: "text!components/" + component_name + "/" + component_name + ".html"
            }
        });
    }

});





require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});