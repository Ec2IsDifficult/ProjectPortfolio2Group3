define(["knockout", "dataservice"], function(ko, ds) {
    return function(params) {
        
        let randPeople = ko.observableArray([]);
        let args = Object.values(params).splice(1)
        params.func(data => randPeople(data), ...args);        
        
        return {
            randPeople: randPeople
        }
    }
});