define(["knockout", "dataservice"], function(ko, ds) {
    return function(params) {
        
        let randPeople = ko.observableArray([]);
        
        ds.getRandomPeople(data => randPeople(data.$values), 4)
        
        return {
            randPeople: randPeople
        }
    }
});