define(["knockout", "dataservice", "viewmodel"], function(ko, ds, vm) {
    return function(params) {
        let leftArrow = ko.observable("left-arrow");
        let rightArrow = ko.observable("right-arrow");
        let titleCardList = ko.observable("title-card-list")
        
        
        //Should contain function go to classics
        let goToClassicsPage = () => {
            vm.changeContent(vm.componentItems.find(item => item.component === "classics-page"));
        }
        
        //Should contain function go to function by year
        //making a for loop 
        //check particular year to extend it into the future  
        //fill array until 1959
        let yearlySections = [
            {
                year1: 1950, year2: 1960
            }, 
            {
                year1: 1960, year2: 1970
            }, 
            {
                year1: 1970, year2: 1980
            },
                {year1: 1980, year2: 1990
            },
                {year1: 1990, year2: 2000
            }, 
                {year1: 2000, year2: 2010
            }, 
                {year1: 2010, year2: 2020
            }, 
                {year1: 2020, year2: 2020
            }
        ];
        
        // go to titlesByYearPage
        let goToTitlesByYearPage = (year) => {
            console.log(year)
            vm.changeContent(vm.componentItems.find(item => item.component === "by-year-pages"));
        }
        
        
        //Should contain function go to by genre
        let genres = ko.observableArray([]);
        ds.getAllGenres(data => genres(data.data));
        
        return {
            leftArrow:leftArrow,
            rightArrow:rightArrow,

            goToTitlesByYearPage: goToTitlesByYearPage,
            
            getMoviesBetween: ds.getMoviesBetween,
            getTitlesByYear: ds.getTitlesByYear,
            titleCardList: titleCardList,
            goToClassicsPage: goToClassicsPage,
            
            
            yearlySections: yearlySections,
            genres:genres,
        }
    }
})