define(["knockout", "dataservice"], function(ko, ds) {
    return function(params) {
        let leftArrow = ko.observable("left-arrow");
        let rightArrow = ko.observable("right-arrow");
        let titleCardList = ko.observable("title-card-list")
        
        //Should contain function go to classics
        /*let goToClassicsPage = () => {
            vm.changeContent(vm.componentItems.find(item => item.component === "classics-page"));
        }*/
        let goToClassicsPage = undefined;
        
        //Should contain function go to function by year
        //making a for loop 
        //check particular year to extend it into the future  
        //fill array until 1959
        let yearlySections = [
            {year: 1950}, {year: 1960}, {year: 1970}, {year: 1980}, {year: 1990}, {year: 2000}, {year: 2010}, {year: 2020}
        ];
        
        //Should contain function go to by genre
        let genres = ko.observableArray([]);
        ds.getAllGenres(data => genres(data));
        
        return {
            leftArrow:leftArrow,
            rightArrow:rightArrow,
            
            
            getMoviesBetween: ds.getMoviesBetween,
            titleCardList: titleCardList,
            goToClassicsPage:goToClassicsPage,
            
            
            yearlySections: yearlySections,
            genres:genres
        }
    }
})