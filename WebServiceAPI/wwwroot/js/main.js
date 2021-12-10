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


    let component_auth = ["user-login", "user-recover", "user-register", "user-update-email"];

    let component_front_page = [
        "front-page", "title-card-list", "person-card-list", "navbar", "right-arrow", "left-arrow"
    ];

    let component_title_logic_page = [
        "title-logic-page"
    ];
    
    let component_person_logic_page = [
        "person-logic-page"
    ]
    
    let components = component_auth.concat(component_front_page, component_title_logic_page, component_person_logic_page);
    components.forEach(registerComponent);

    function registerComponent(component_name) {
        ko.components.register(component_name, {
            viewModel: {
                require: "Components/" + component_name + "/" + component_name
            },
            template: {
                require: "text!Components/" + component_name + "/" + component_name + ".html"
            }
        });
    }

});

require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});