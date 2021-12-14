define(["knockout", "dataservice"], function(ko, ds) {
   return function (params) {
       let titleCardList = ko.observable("title-card-list")
       
      
       
       return {
           titleCardList:titleCardList,
           getTitlesByYear:ds.getTitlesByYear,
           getMoviesBetween: ds.getMoviesBetween

       }
   } 
});