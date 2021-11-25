require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        dataservice: "services/dataservice"
    }
});


require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});