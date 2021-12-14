define(["knockout", "viewmodel"], function(ko, vw){
    return function(params) {
        let test = ko.observableArray(params);
        console.log("I am also here")

        return {
            test
        }
    }    
});