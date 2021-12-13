define(["knockout", "dataservice"], function(ko, ds) {
    return function(params) {
        
        let randTitles = ko.observableArray([]);
        
        ds.getRandomTitles(data => randTitles(data), 6, 9);
        
        return {
            randTitles: randTitles
        }
    }
});