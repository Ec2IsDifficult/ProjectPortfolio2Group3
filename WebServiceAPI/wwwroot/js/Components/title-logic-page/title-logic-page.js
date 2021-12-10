define(["knockout", "dataservice"], function(ko, ds) {
    return function(params) {
        let leftArrow = ko.observable("left-arrow");
        let rightArrow = ko.observable("right-arrow");
        
        let classicMovies = ko.observableArray([]);
        
        let getClassics = () => {
            ds.getMoviesBetween(data => {classicMovies(data)}, 1959, 1959);
        }
        
        
        return {
            leftArrow:leftArrow,
            rightArrow:rightArrow,
            
            getClassics: getClassics,
            classicMovies: classicMovies,
        }
    }
})