define(["knockout", "dataservice"], function(ko, ds) {
    return function(params){

        let classicMovies = ko.observableArray([]);

        let getClassics = () => {
            ds.getMoviesBetween(data => {classicMovies(data)}, 1959, 1959);
        }
        
        return {
            getClassics:getClassics,
            classicMovies:classicMovies
        }
    }
})