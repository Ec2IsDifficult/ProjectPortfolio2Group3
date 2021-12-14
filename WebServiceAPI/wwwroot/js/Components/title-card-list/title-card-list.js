define(["knockout", "dataservice"], function (ko, ds) {
   return function(params) {   
       let randomTitles = ko.observableArray([]);
       
       let nextPage = ko.observable();
       let nextPageUrl = "";
       let prevPage = ko.observable();
       let prevPageUrl = ko.observable();
       
       let args = Object.values(params).splice(1)
       let execute = function(url) {params.func(data => {
           if (data.data) {
               randomTitles(data.data);
               nextPage(data.nextPage)
               prevPage(data.previousPage)
               nextPageUrl = data.nextPage;
               prevPageUrl = data.previousPage;
           }
           else {
               randomTitles(data)
           }
       }, ...args, url);}

       execute();
       let goToNextPage = () => {
           console.log(nextPageUrl)
           execute(nextPageUrl)
       }

       let goToPrevPage = () => {
           console.log(prevPageUrl)
           execute(prevPageUrl)
       }
       
       return {
           randomTitles: randomTitles,
           nextPage: nextPage,
           prevPage: prevPage,
           goToNextPage: goToNextPage,
           goToPrevPage: goToPrevPage
       }
   }    
});