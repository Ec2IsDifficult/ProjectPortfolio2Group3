require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        dataservice: "services/dataservices",
        authservice: "services/authservices",
        userservice: "services/userservices",
        ApiConfig: "config/ApiConfig"
    }
});


require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});